using EF_Practise.Data.Entities;
using EF_Practise.Interfaces;
using EFlecture.Core.Specifications;
using System;
using System.Linq;
using System.Text;

namespace EF_Practise
{
    class DirectoryService : IDirectoryService
    {
        private readonly IRepository repository;
        public DirectoryService(IRepository repository)
        {
            this.repository = repository;
        }

        public string GetFilesAndDirectories(int directoryId, int userId)
        {
            var specForFiles = new Specification<File>(i => !GetRestrictFiles(userId).Contains(i.Id) && i.DirectoryId == directoryId);
            var specForParent = new Specification<Directory>(i => i.ParentDirectoryId == directoryId);
           
            var data = new { Files = repository.Get<File>(specForFiles), Directories = repository.Get<Directory>(specForParent)};

            var @string = new StringBuilder();
            @string.AppendLine("______Files________");
            foreach (var item in data.Files)
            {
                @string.AppendLine(item.Title);
            }
            @string.AppendLine("______Directories________");
            foreach (var item in data.Directories)
            {
                @string.AppendLine(item.Title);
            }
            return @string.ToString();
        }

        public string GetReportDistinctFiles()
        {
            var files = repository.Get<TextFile>(new Specification<TextFile>(i => true)).Select(i => new { i.Title, Type = "TextFile"})
                .Union(repository.Get<ImageFile>(new Specification<ImageFile>(i => true)).Select(i => new { i.Title, Type = "ImageFile" }))
                .Union(repository.Get<AudioFile>(new Specification<AudioFile>(i => true)).Select(i => new { i.Title, Type = "AudioFile" }))
                .Union(repository.Get<VideoFile>(new Specification<VideoFile>(i => true)).Select(i => new { i.Title, Type = "VideoFile" }))
                .GroupBy(i => i.Type).Select( i => new { Key = i.Key, Amount = i.Count() }).ToList();
            StringBuilder @string = new StringBuilder();
            @string.AppendLine("|Type of File\t|Amount\t|");
            foreach (var item in files)
            {
                @string.AppendLine($"|{item.Key}\t|{item.Amount}\t|");
            }         
            return @string.ToString();
        }

        public string GetTotalNumberOfFiles(int directoryId, int userId)
        {
            var dir = repository.Find<Directory>(new Specification<Directory>(i => i.Id == directoryId));
            var specificationForFile = new Specification<File>(i => i.DirectoryId == directoryId);
            GetFiles(dir);
            var files = repository.Get<File>(specificationForFile);
            var filesForUser = repository.Get<FilePermission>(new Specification<FilePermission>(i => i.UserId == userId && i.CanRead && i.CanWrite)).Select(i => i.FileId).Where(i => files.Select(i => i.Id).Contains(i)).Count();
            return $"Files: {files.Count()} For user: {filesForUser}";

            void GetFiles(Directory directory)
            {
                if (directory is null)
                {
                    return;
                }
                specificationForFile = specificationForFile.Or(new Specification<File>(i => i.DirectoryId == directory.Id));
                var dirNext = repository.Get<Directory>(new Specification<Directory>(i => i.ParentDirectoryId == directory.Id));
                foreach (var item in dirNext)
                {
                    GetFiles(item);
                }

            }
        }

        public IQueryable<int> GetRestrictDirectories(int userId)
        {
            return repository.Get<DirectoryPermission>(new Specification<DirectoryPermission>(i => !i.CanRead && !i.CanWrite && userId == i.UserId))
                           .Select(i => i.DirectoryId);
        }

        public IQueryable<int> GetRestrictFiles(int userId)
        {
            var restrictCatalogFile = repository.Get<File>(
                        new Specification<File>(j =>
                            GetRestrictDirectories(userId)
                           .Contains(j.DirectoryId)
                    )).Select(i => i.Id);
            var restrictFiles = repository.Get<FilePermission>(new Specification<FilePermission>(i => i.CanRead && i.CanWrite && userId == i.UserId))
                .Select(i => i.FileId);

            return restrictCatalogFile.Except(restrictFiles);
        }

    }
}
