using EF_Practise.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;


namespace EF_Practise.Interfaces
{
    interface IFileService
    {
        IEnumerable<File> GetAvailableFileReadInDirectory(int userId, int directoryId);
        IEnumerable<string> GetFullPathOfFiles(int directoryId);
    }
}
