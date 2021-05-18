using System;
using System.Collections.Generic;
using System.IO;

namespace FileManager
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, IReader> readers = new Dictionary<string, IReader>()
            {
                {"xml",new ReaderXml() },
                {"json", new ReaderJson() },
                {"txt", new ReaderText()}
            };
            FileManager fileManager = new FileManager(@"c:\", readers, new ReaderAnorher());
            fileManager.RunManager();

        }
    }
}
