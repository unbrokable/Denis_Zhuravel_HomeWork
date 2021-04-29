using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Linq;
namespace Dz1
{
    class ParserFileSize : IParser<FileSize>
    {
        public FileSize Parse(string content)
        {
            
            string copy = content;
            FileSizeType type = (FileSizeType)Enum.Parse(typeof(FileSizeType), Regex.Replace(copy, "[0-9]",String.Empty)) ;
            int Length = Convert.ToInt32(Regex.Replace(copy, "[A-Za-z]", String.Empty).Trim());
            return new FileSize(type,Length);
        }
    }
}
