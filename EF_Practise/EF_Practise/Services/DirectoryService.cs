using EF_Practise.Data.Entities;
using EF_Practise.DTOs;
using EF_Practise.Extensions;
using EF_Practise.Interfaces;
using EFlecture.Core.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Practise
{
    class DirectoryService : IDirectoryService
    {
        private readonly IRepository repository;
        public DirectoryService(IRepository repository)
        {
            this.repository = repository;
        }

        public async  Task<DirectoryInfoDTO> GetFilesAndDirectoriesAsync(int directoryId, int userId)
        {
            var specForFiles = new Specification<File>(i => i.DirectoryId == directoryId).And(FileSpecification.FilterByRestrictFilesForUser(userId));
            var specForParent = new Specification<Directory>(i => i.ParentDirectoryId == directoryId);
           
            var directory = new DirectoryInfoDTO    
            { 
                Files =  (await repository.GetAsync<File>(specForFiles)).Select( i => new FileDTO { Name = i.Title}),
                Directories = (await repository.GetAsync<Directory>(specForParent)).Select(i => new DirectoryDTO { Name = i.Title})
            };
            return directory;
        }

        public async Task<string> GetReportDistinctFilesAsync()
        {
            var files = ( await repository.GetAsync<TextFile>(new Specification<TextFile>(i => true))).Select(i => new { i.Title, Type = "TextFile"})
                .Union((await repository.GetAsync<ImageFile>(new Specification<ImageFile>(i => true))).Select(i => new { i.Title, Type = "ImageFile" }))
                .Union((await repository.GetAsync<AudioFile>(new Specification<AudioFile>(i => true))).Select(i => new { i.Title, Type = "AudioFile" }))
                .Union((await repository.GetAsync<VideoFile>(new Specification<VideoFile>(i => true))).Select(i => new { i.Title, Type = "VideoFile" }))
                .GroupBy(i => i.Type).Select( i => new { i.Key, Amount = i.Count() }).ToList();
            StringBuilder @string = new StringBuilder();
            @string.AppendLine("|Type of File\t|Amount\t|");
            foreach (var item in files)
            {
                @string.AppendLine($"|{item.Key}\t|{item.Amount}\t|");
            }         
            return @string.ToString();
        }

        public async Task<FilesAmountDTO> GetTotalNumberOfFilesAsync(int directoryId, int userId)
        {
            var dir = await repository.FindAsync<Directory>(new Specification<Directory>(i => i.Id == directoryId));
            var specificationForFile = new Specification<File>(i => i.DirectoryId == directoryId);
            await GetFiles(dir);
            var files =await  repository.GetAsync<File>(specificationForFile);
            var filesForUser = (await repository.GetAsync<FilePermission>(new Specification<FilePermission>(i => i.UserId == userId && i.CanRead && i.CanWrite))).Select(i => i.FileId).Where(i => files.Select(i => i.Id).Contains(i)).Count();
            return new FilesAmountDTO { ForUser = filesForUser, Total = files.Count()};

            async Task GetFiles(Directory directory)
            {
                if (directory is null)
                {
                    return;
                }
                specificationForFile = specificationForFile.Or(new Specification<File>(i => i.DirectoryId == directory.Id));
                var dirNext = await repository.GetAsync<Directory>(new Specification<Directory>(i => i.ParentDirectoryId == directory.Id));
                foreach (var item in dirNext)
                {
                   await GetFiles(item);
                }

            }
        }
    }
}
