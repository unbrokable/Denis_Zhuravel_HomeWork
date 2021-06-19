using Application;
using Application.Interfaces;
using Application.Services;
using Domain.Interfaces;
using Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace Dapper_Practise
{
    public class Startup
    {
        public static IServiceProvider ConfigureService()
        {
            var provider = new ServiceCollection()
                .AddTransient<IUserService, UserService>()
                .AddScoped<IHasher, Hasher>()
                .AddTransient<IRepository,Repository>( i => {
                    var path = String.Concat(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName, @"\appsettings.json");
                    var sec = (new ConfigurationBuilder()
                     .AddJsonFile(path, true, true)
                     .Build()).GetSection("ConnectionStrings");
                    string connection = sec.GetSection("Connect").Value;
                    return new Repository(connection);    
                })
                .BuildServiceProvider();
                            
            return provider;
        }

    }
}
