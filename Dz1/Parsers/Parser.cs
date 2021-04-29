using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace Dz1
{
    interface IParser<T>
    {
        T Parse(string content);
    }
   class Parser : IParser< Dictionary<FileType, List<File>> >
    {

       public Dictionary<FileType, List<File>> Parse(string content)
       {
            Dictionary<FileType, List<File>> Files = new Dictionary<FileType, List<File>>();
            var lines = content.Split('\n');
            for(int j = 0; j < lines.Length; j++)
            {
                try
                {

                
                FileType type = (FileType)Enum.Parse(typeof(FileType), lines[j].Split(':')[0]);
                switch (type)
                {
                    case FileType.Image:
                        AddValuDictionary(type, lines[j], new ParserImg().Parse);
                        break;
                    case FileType.Movie:
                        AddValuDictionary(type, lines[j], new ParserVideo().Parse);
                        break;
                    case FileType.Text:
                        AddValuDictionary(type, lines[j], new ParserText().Parse);
                        break;
                    default:
                        break;
                } }
               catch { }
               
            }
            return Files;
            void AddValuDictionary(FileType type , string i, Func<string,File>  Parse)
            {
                        if (Files.ContainsKey(type))
                        {
                            Files[type].Add(Parse(i));
                        }
                        else Files.Add(type, new List<File>(new File[] { Parse(i) }));
            }
        }


        
    }
}
