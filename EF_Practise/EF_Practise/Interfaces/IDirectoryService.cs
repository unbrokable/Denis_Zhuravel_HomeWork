using EF_Practise.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Practise.Interfaces
{
    interface IDirectoryService
    {
        Task<DirectoryInfoDTO> GetFilesAndDirectoriesAsync(int directoryId, int userId);
        Task<FilesAmountDTO> GetTotalNumberOfFilesAsync(int directoryId,int userId);
        Task<string> GetReportDistinctFilesAsync();
    }
}
