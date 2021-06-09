using System;
using System.Collections.Generic;
using System.Text;

namespace EF_Practise.Data.Entities
{
    class Directory
    {
        public int Id { get; set; }
        public int? ParentDirectoryId { get; set; }
        public Directory ParentDirectory { get; set; }
        public string  Title { get; set; }

        public virtual ICollection<DirectoryPermission> DirectoryPermissions { get; set; }
        public virtual ICollection<Directory> Directories { get; set; }
        public virtual ICollection<File> Files { get; set; }
    }
}
