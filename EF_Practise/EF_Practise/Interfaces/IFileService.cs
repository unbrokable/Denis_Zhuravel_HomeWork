using EF_Practise.Data.Entities;
using EF_Practise.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Practise.Interfaces
{
    interface IFileService
    {
        Task<IEnumerable<FileDTO>> GetAvailableFileReadInDirectoryAsync(int userId, int directoryId);
        Task<IEnumerable<string>> GetFullPathOfFilesAsync(int directoryId);
    }
}
