using EF_Practise.Data;
using EF_Practise.Data.Entities;
using EF_Practise.Interfaces;
using System;
using System.Collections.Generic;

namespace EF_Practise
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = Startup.ConfigureService();
            SetData((ApplicationContext)container.GetService(typeof(ApplicationContext)));
            var fileService = (IFileService)container.GetService(typeof(IFileService));
            var directoryService = (IDirectoryService)container.GetService(typeof(IDirectoryService));
            var res = fileService.GetAvailableFileReadInDirectory(1, 1);

            Console.WriteLine("Task 5");
            foreach (File item in fileService.GetAvailableFileReadInDirectory(1, 1))
            {
                Console.WriteLine(item.Title);
            }
            Console.WriteLine("Task 6");
            Console.WriteLine(directoryService.GetFilesAndDirectories(1,1));
            Console.WriteLine("Task 7");
            foreach (var item in fileService.GetFullPathOfFiles(4))
            {
                Console.WriteLine(item);
            }
            
            Console.WriteLine("Task 9");
            Console.WriteLine(directoryService.GetTotalNumberOfFiles(1,1));
            Console.WriteLine("Task 10");
            Console.WriteLine(directoryService.GetReportDistinctFiles());
            Console.ReadKey();
        }
        static public void SetData(ApplicationContext context)
        {
            context.Directories.Add(
                new Directory
                {

                    Title = "MainDir",
                    Directories =
                    new List<Directory>()
                    {
                        new Directory{  Title = "AfterMain1"},
                        new Directory{  Title = "AfterMain2"},
                        new Directory{

                            Title = "AfterMain3",
                            Files = new List<File>
                            {
                                new ImageFile { Title = "Image", Extention = "jpg", Width = 1000, Size = 1021,Height = 1239},
                                new TextFile {Title = "Text", Extention = "txt", Size = 1212, Content = "EW RWERWEARWZCSC" }
                            }
                        }
                    },
                    Files = new List<File>
                    {
                        new AudioFile { SampleRate = 1, ChannelCount = 12, Bitrate = 111, Extention = "mp3", Size = 100, Title ="MainFileAudio", Duration = new TimeSpan(1,10,0) },
                        new VideoFile {Extention = "mp4", Duration = new TimeSpan(1,12,0), Title = "MainAudio", Height = 1910, Width = 1080 }

                    }
                }
            );
            context.Users.AddRange(
                new User { Email = "someemail1", PasswordHash = "qeqwe", UserName = "Name1" },
                new User { Email = "someemail2", PasswordHash = "qeqwe", UserName = "Name2" },
                new User { Email = "someemail3", PasswordHash = "qeqwe", UserName = "Name3" }
            );
            context.SaveChanges();
            context.FilePermissions.AddRange(
                new FilePermission { UserId = 1, FileId = 1, CanWrite = true, CanRead = true },
                new FilePermission { UserId = 1, FileId = 2, CanWrite = false, CanRead = false },
                new FilePermission { UserId = 2, FileId = 1, CanWrite = true, CanRead = false },
                new FilePermission { UserId = 3, FileId = 4, CanWrite = true, CanRead = false }
            );
            context.DirectoryPermissions.AddRange(
                new DirectoryPermission { UserId = 1, DirectoryId = 1, CanRead = false, CanWrite = false },
                new DirectoryPermission { UserId = 2, DirectoryId = 2, CanRead = false, CanWrite = false }
            );
            context.SaveChanges();
        }
    }
}
