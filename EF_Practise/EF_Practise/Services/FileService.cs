
using EF_Practise.Interfaces;
using EFlecture.Core.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using EF_Practise.Data.Entities;
using EF_Practise.Extensions;
using EF_Practise.DTOs;
using System.Threading.Tasks;

namespace EF_Practise.Services
{
    class FileService : IFileService
    {
        protected readonly IRepository repository;

        public FileService(IRepository repository)
        {
            this.repository = repository;
        }

        public async Task<IEnumerable<FileDTO>> GetAvailableFileReadInDirectoryAsync(int userId, int directoryId)
        {
            var specForDirectory = new Specification<File>(i => i.DirectoryId == directoryId);
            return (await repository.GetAsync<File>(specForDirectory.And(FileSpecification.FilterByRestrictFilesForUser(userId))))
                .Select(i => new FileDTO { Name = i.Title})
                .ToList();
        }

        public async Task<IEnumerable<string>> GetFullPathOfFilesAsync(int directoryId)
        {
            var curDirSpec = new Specification<Directory>(i => i.Id == directoryId);
            var curDir =await repository.FindAsync<Directory>(curDirSpec);
            var filesAndDirectories = (await repository.GetAsync<File>(new Specification<File>(i => i.DirectoryId == directoryId)))
                .Select(i => String.Concat(i.Title, ".", i.Extention)).ToList();
            filesAndDirectories.Union((await repository.GetAsync<Directory>(new Specification<Directory>(i => i.ParentDirectoryId == directoryId)))
                .Select(i => i.Title).ToList());
            List<string> path = new List<string>();
            while (curDir != null)
            {
                path.Add(curDir.Title);
                curDir = await repository.FindAsync<Directory>(new Specification<Directory>(i => i.Id == curDir.ParentDirectoryId));
            }
            path.Reverse();
            return filesAndDirectories.Select(i => String.Concat(String.Join(@"\", path), @"\", i)).ToList();
        }
    }
}
