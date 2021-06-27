using EF_Practise.Data;
using EF_Practise.Interfaces;
using EF_Practise.Repositories;
using EF_Practise.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace EF_Practise
{
    class Startup
    {
        public static IServiceProvider ConfigureService()
        {
            var provider = new ServiceCollection()
                           .AddTransient<IDirectoryService, DirectoryService>()
                           .AddTransient<IFileService, FileService>()
                           .AddTransient<IRepository, Repository>()
                           .AddDbContext<ApplicationContext>(
                            opt =>
                            {
                                var path = String.Concat(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName, @"\appsettings.json");
                                string connection = (new ConfigurationBuilder()
                                    .AddJsonFile(path, true, true)
                                    .Build())
                                    .GetSection("ConnectionStrings")
                                    .GetSection("Connect").Value;
                                opt.UseSqlServer(connection);
                            })
                           .BuildServiceProvider(); 

            return provider;
        }
    }
}
