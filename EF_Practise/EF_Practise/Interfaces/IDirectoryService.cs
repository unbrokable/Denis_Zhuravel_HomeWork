using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EF_Practise.Interfaces
{
    interface IDirectoryService
    {
        IQueryable<int> GetRestrictFiles(int userId);
        string GetFilesAndDirectories(int directoryId, int userId);
        string GetTotalNumberOfFiles(int directoryId,int userId);
        string GetReportDistinctFiles();
    }
}
