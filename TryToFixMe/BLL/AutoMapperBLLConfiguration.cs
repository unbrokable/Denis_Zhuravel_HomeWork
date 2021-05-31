using AutoMapper;
using BLL.Abstractions.Interfaces;
using BLL.DTOs;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class AutoMapperBLLConfiguration : IAutoMapperBLLConfiguration
    {
        private IMapper _mapper = new MapperConfiguration(
            i =>
            {
                i.CreateMap<User, UserDTO>();
                i.CreateMap<UserDTO, User>();
            }).CreateMapper();

        public IMapper GetMapper()
        {
            return _mapper;
        }
    }
}
