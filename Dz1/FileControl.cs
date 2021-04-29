using System;
using System.Collections.Generic;
using System.Text;

namespace Dz1
{
    class FileControl
    {
       public IParser<Dictionary<FileType, List<File>>> parser;
       Dictionary<FileType, List<File>> Files = new Dictionary<FileType, List<File>>();

       public FileControl (Parser parser)
        {
            this.parser = new Parser();
        }
        public void Parse(string content)
        {
            Files = parser.Parse(content);
            Sort();
        }
        public void Sort()
        {
            foreach (var item in Files)
            {
                Files[item.Key].Sort();
            }
        }

        public override string ToString()
        {
            StringBuilder @string = new StringBuilder();
            foreach (var item in Files)
            {
                @string.Append("Text".CompareTo(item.Key.ToString()) == 0? ("Text files"):(item.Key + "s") +"\n");
                for (int i = 0; i < Files[item.Key].Count; i++ )
                {
                    var temp = Files[item.Key][i].ToString().Split('\n');
                    for (int j =0; j < temp.Length; j++ )
                    {
                        @string.Append('\t' +temp[j] +'\n');
                    }
                   
                }
            }
            return @string.ToString();
        }


    }
}
