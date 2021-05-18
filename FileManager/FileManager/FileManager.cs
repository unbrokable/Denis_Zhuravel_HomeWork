using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;
namespace FileManager
{
    class FileManager
    {
        Dictionary<string, IReader> readers;
        IReader defaultReader;
        string curdirectory;

        public FileManager(string curdirectory, Dictionary<string, IReader> readers, IReader defaultReader)
        {
            this.readers = readers;
            this.curdirectory = curdirectory;
            this.defaultReader = defaultReader;
        }

        public void RunManager()
        {
            GetDirectoryInfo();
            while (true)
            {
                Console.WriteLine("Write command");
                var userCommand = Console.ReadLine();
                try
                {
                    switch (userCommand.Trim())
                    {
                        case "exit":
                            return;
                        case "cd ..":
                            ComeBack();
                            break;
                        case "cd open":
                            ReadFile();
                            break;
                        default:
                            if (!userCommand.StartsWith("cd "))
                            {
                                throw new ArgumentException("Cant file comand");
                            }
                            Next(userCommand.Skip(2).Aggregate(new StringBuilder(),(a,b) => a.Append(b)).ToString().Trim());
                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Erorr {e.Message}");
                }

            }
        }

        public void GetDirectoryInfo()
        {
            string[] files = Directory.GetFiles(curdirectory);
            string[] directories = Directory.GetDirectories(curdirectory);
            Console.WriteLine($"_________________{curdirectory}___________________");
            Console.WriteLine("Files");
            foreach (var item in files)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("Directories");
            foreach (var item in directories)
            {
                Console.WriteLine(item);
            }
        }

        public void Next(string folder)
        {
            if (Directory.Exists(String.Concat(curdirectory, folder, @"\")))
            {
                curdirectory = String.Concat(curdirectory, folder, @"\");
                GetDirectoryInfo();
            }
            else if (File.Exists(String.Concat(curdirectory, folder)))
            {
                curdirectory = String.Concat(curdirectory, folder);
                Console.WriteLine("It is file. Are you want to read it?(cd open)");
            }
            else
            {
                Console.WriteLine("Cant find next directory");
            }
        }

        public void ComeBack()
        {
            if (File.Exists(curdirectory))
            {
                curdirectory = String.Concat(Directory.GetParent(curdirectory).FullName, @"\");
                GetDirectoryInfo();
            }
            else if (Directory.GetParent(curdirectory) != null)
            {
                curdirectory = String.Concat(Directory.GetParent(curdirectory.Remove(curdirectory.Length - 1)).FullName, @"\");
                GetDirectoryInfo();
            }
        }

        public void ReadFile()
        {
            string exstantion = Path.GetExtension(curdirectory).Replace(".", "");
            if (Directory.Exists(curdirectory))
            {
                Console.WriteLine("Can't read directory");
            }
            else if (readers.ContainsKey(exstantion))
            {
                Console.WriteLine(readers[exstantion].Read(curdirectory));
            }
            else
            {
                Console.WriteLine(defaultReader.Read(curdirectory));
            }
        }
    }
}
