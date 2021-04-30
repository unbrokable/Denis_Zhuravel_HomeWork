using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace Dz1
{
    class FileControl
    {
       IParser<Dictionary<FileType, List<File>>> parser;
       Dictionary<FileType, List<File>> files ;
       IComparer<File> comparer; 

       public FileControl (Parser parser, IComparer<File> comparer)
        {
            this.parser = parser;
            this.comparer = comparer;
        }
        public void Parse(string content)
        {
            files = parser.Parse(content);
            Sort();
        }
        public void Sort()
        {
            foreach (var item in files)
            {
                files[item.Key].Sort(comparer);
            }
        }

        public override string ToString()
        {
            StringBuilder @string = new StringBuilder();
            foreach (var item in files)
            {
                @string.Append("Text".CompareTo(item.Key.ToString()) == 0? "Text files":String.Concat( item.Key , "s")).Append("\n"); 
                foreach(var file in files[item.Key])
                {
                    file.ToString().Split('\n').ToList()
                           .ForEach(i =>@string.Append('\t' +i +'\n') );
                }
            }
            return @string.ToString();
        }


    }
}
