using EF_Practise.Data.Entities;
using EFlecture.Core.Specifications;
using System.Linq;

namespace EF_Practise.Extensions
{
    static class FileSpecification
    {
        public static Specification<File> FilterByRestrictFilesForUser(int idUser)
        {
            return new Specification<File>(  i => !i.FilePermissions
                .Where(f => f.CanRead && f.CanWrite && idUser == f.UserId)
                .Select(f => f.FileId).Contains(i.Id)
                &&
                i.Directory.DirectoryPermissions
                .Where(p => p.UserId == idUser)
                .Where(p => !p.CanWrite && !p.CanRead)
                .Select(p => p.DirectoryId)
                .Contains(i.DirectoryId)
             );
        }
    }
}
