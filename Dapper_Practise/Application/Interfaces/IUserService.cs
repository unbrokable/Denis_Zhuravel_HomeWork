using Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interfaces
{
    public interface IUserService
    {
        UserDTO GetUserByEmail(string email);
        void EncryptUserByEmail(string email);
        void CreateData();
    }
}
