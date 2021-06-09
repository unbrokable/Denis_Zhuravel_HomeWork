using EF_Practise.Data.Entities;
using EF_Practise.Interfaces;
using EFlecture.Core.Specifications;
using System;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Microsoft.EntityFrameworkCore.Internal;

namespace EF_Practise
{
    class DirectoryService : IDirectoryService
    {
        private readonly IRepository repository;
        public DirectoryService(IRepository repository)
        {
            this.repository = repository;
        }

        public string GetFilesAndDirectories(int directoryId)
        {
            //change
            var specForDirectory = new Specification<Directory>(i => i.Id == directoryId);
            var specForParent = new Specification<Directory>(i => i.ParentDirectoryId == directoryId);
            var curDir = repository.Find<Directory>(specForDirectory);
            var data = new { Files = curDir.Files, Directories = repository.Get<Directory>(specForParent)};

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
            throw new NotImplementedException();
        }

        public string GetTotalNumberOfFiles(int directoryId, int userId)
        {
            throw new NotImplementedException();
        }
    }
}
