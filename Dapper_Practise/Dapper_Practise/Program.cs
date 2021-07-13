using Application.Interfaces;
using Application.Services;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace Dapper_Practise
{
    class Program
    {
        static void Main(string[] args)
        {
           var container = Startup.ConfigureService();
            var userService = (IUserService)container.GetService(typeof(IUserService));
            userService.CreateData();      
            try
            {
                Console.WriteLine(userService.GetUserByEmail("d@gmail.com"));
                userService.EncryptUserByEmail("d@gmail.com");
                userService.GetUserByEmail("d@gmail.com");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            
            Console.ReadKey();
        }
    }
}
