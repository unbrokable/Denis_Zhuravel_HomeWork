using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace Dz1
{
    interface IParser<out T>
    {
        T Parse(string content);
    }
   class Parser : IParser< Dictionary<FileType, List<File>> >
    {
       Dictionary<FileType, IParser<File>> parsers;
       public Parser(Dictionary<FileType, IParser<File>> parsers)
        {
            this.parsers = parsers;
        }

       public Dictionary<FileType, List<File>> Parse(string content)
       {
            Dictionary<FileType, List<File>> files = new Dictionary<FileType, List<File>>();
            var lines = content.Split('\n');
            for(int j = 0; j < lines.Length; j++)
            {
                try
                {
                FileType type = (FileType)Enum.Parse(typeof(FileType), lines[j].Split(':')[0]);
                switch (type)
                {
                    case FileType.Image:
                        AddValuDictionary(type, lines[j]);
                        break;
                    case FileType.Movie:
                        AddValuDictionary(type, lines[j]);
                        break;
                    case FileType.Text:
                        AddValuDictionary(type, lines[j]);
                        break;
                    default:
                        break;
                } }
               catch { }
               
            }
            return files;
            void AddValuDictionary(FileType type , string line )
            {
                Func<string, File> parse;
                    if (parsers.ContainsKey(type))
                    {
                        parse = parsers[type].Parse;
                    }
                    else
                    {
                        return;
                    }
                        
                    if (files.ContainsKey(type))
                    {
                            files[type].Add(parse(line));
                    }
                    else files.Add(type, new List<File>(new File[] { parse(line) }));
            }
        }


        
    }
}
