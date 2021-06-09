using System;
using System.Collections.Generic;
using System.Text;

namespace EF_Practise.Data.Entities
{
    class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }

        public virtual ICollection<DirectoryPermission> DirectoryPermissions { get; set; }
        public virtual ICollection<FilePermission> FilePermissions { get; set; }

    }
}
