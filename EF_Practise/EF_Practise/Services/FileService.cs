
using EF_Practise.Interfaces;
using EFlecture.Core.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using EF_Practise.Data.Entities;

namespace EF_Practise.Services
{
    class FileService : IFileService
    {
        protected readonly IRepository repository;
        private readonly IDirectoryService directoryService;

        public FileService(IRepository repository, IDirectoryService directoryService)
        {
            this.repository = repository;
            this.directoryService = directoryService;
        }

        public IEnumerable<File> GetAvailableFileReadInDirectory(int userId, int directoryId)
        {
            var specForDirectory = new Specification<File>(i => i.DirectoryId == directoryId);
            return repository.Get<File>(specForDirectory)
                .Where(i => directoryService.GetRestrictFiles(userId).Contains(i.Id)).ToList();
        }

        public IEnumerable<string> GetFullPathOfFiles(int directoryId)
        {
            var curDirSpec = new Specification<Directory>(i => i.Id == directoryId);
            var curDir = repository.Find<Directory>(curDirSpec);
            var filesAndDirectories = repository.Get<File>(new Specification<File>(i => i.DirectoryId == directoryId)).Select(i => String.Concat(i.Title, ".", i.Extention)).ToList();
            filesAndDirectories.Union(repository.Get<Directory>(new Specification<Directory>(i => i.ParentDirectoryId == directoryId)).Select(i => i.Title).ToList());
            List<string> path = new List<string>();
            while (curDir != null)
            {
                path.Add(curDir.Title);
                curDir = repository.Find<Directory>(new Specification<Directory>(i => i.Id == curDir.ParentDirectoryId));
            }
            path.Reverse();
            return filesAndDirectories.Select(i => String.Concat(String.Join(@"\", path), @"\", i)).ToList();
        }
    }
}
