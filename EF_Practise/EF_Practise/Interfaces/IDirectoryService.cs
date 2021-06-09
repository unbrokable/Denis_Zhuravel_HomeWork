using System;
using System.Collections.Generic;
using System.Text;

namespace EF_Practise.Interfaces
{
    interface IDirectoryService
    {
        string GetFilesAndDirectories(int directoryId);
        string GetTotalNumberOfFiles(int directoryId,int userId);
        string GetReportDistinctFiles();
    }
}
