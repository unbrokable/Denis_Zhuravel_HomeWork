using BLL;
using BLL.Abstractions.Interfaces;
using BLL.Services;
using ConsoleApp8.Interfaces;
using Core.Models;
using DAL.Abstractions.Interfaces;
using DAL.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp8
{
    public class Startup
    {
        public static IServiceProvider ConfigureService()
        {
            var provider = new ServiceCollection()
                            .AddScoped<IUserService, UserService>()
                            .AddScoped<IRepository<User>, UserRepository>()
                            .AddScoped<IUserManager, UserManager>()
                            .AddScoped<IAutoMapperBLLConfiguration, AutoMapperBLLConfiguration>()
                            .BuildServiceProvider();
            return provider;
        }

    }
}
