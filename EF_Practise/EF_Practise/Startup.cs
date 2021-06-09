using EF_Practise.Data;
using EF_Practise.Interfaces;
using EF_Practise.Repositories;
using EF_Practise.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
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
                           .AddSingleton<ApplicationContext>()
                           .BuildServiceProvider(); 

            return provider;
        }
    }
}
