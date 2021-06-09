using EF_Practise.Data.Entities;
using EF_Practise.Interfaces;
using EFlecture.Core.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EF_Practise.Services
{
    class FileService : IFileService
    {
        protected readonly IRepository repository;
        public FileService(IRepository repository)
        {
            this.repository = repository;
        }

        public IEnumerable<File> GetAvailableFileReadInDirectory(int userId, int directoryId)
        {
            var specForDirectory = new Specification<File>(i => i.DirectoryId == directoryId);
            var specForUser = new Specification<FilePermission>(i => i.UserId == userId && i.CanRead);

           return repository.Get<File>(specForDirectory)
                .Where( i => repository.Get<FilePermission>(specForUser).Select(i =>i.FileId).Contains(i.Id)).ToList(); 
        }

        public IEnumerable<string> GetFullPathOfFiles(int directoryId)
        {
            throw new NotImplementedException();
        }
    }
}
