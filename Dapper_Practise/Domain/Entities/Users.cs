using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Users
    {
        public int User_Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public  string Gender { get; set;}
        public DateTime DateOfBirth { get; set; }
        public int? Country_Code { get; set; }
        public DateTime CreatedAt { get; set; }

    }
}
