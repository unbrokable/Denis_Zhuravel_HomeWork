using BLL.Abstractions.Interfaces;
using BLL.DTOs;
using Core.Models;
using DAL.Abstractions.Interfaces;
using System.Collections.Generic;

namespace BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> _repository;
        private readonly IAutoMapperBLLConfiguration _mapper;
        public UserService(IRepository<User> repository , IAutoMapperBLLConfiguration mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public List<UserDTO> LoadRecords<UserDTO>()
        {
            var users = _mapper.GetMapper().Map<List<User>, List<UserDTO>>(_repository.LoadRecords());
            return users;
        }
    }
}