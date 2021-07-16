using System;
using System.Collections.Generic;
using System.Text;

namespace EF_Practise.Data.Entities
{
    class File
    {
        public int Id { get; set; }

        public int DirectoryId { get; set; }
        public virtual Directory Directory { get; set; }

        public string Title { get; set; }
        public string Extention { get; set; }
        public decimal Size { get; set; }

        public virtual ICollection<FilePermission> FilePermissions { get; set; }
    
    }
}
