using System;
using System.Collections.Generic;
using System.Text;

namespace EF_Practise.Data.Entities
{
    class FilePermission
    {
        public int FileId { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
        public File File { get; set; }

        public bool CanRead { get; set; }
        public bool CanWrite { get; set; }
    }
}
