using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace Dz1
{
    class ParserImg : IParser<ImgFile>
    {
        public ImgFile Parse(string line)
        {
            var description = line.Substring(line.IndexOf(':') + 1).Split(';').Select(i => i.Trim()).ToList();
            string Name = description[0].Split('(', StringSplitOptions.RemoveEmptyEntries)[0];
            string Extension = Name.Split('.', StringSplitOptions.RemoveEmptyEntries).LastOrDefault();
            FileSize Size = new ParserFileSize().Parse(description[0].Split(new char[] { '(', ')' }, StringSplitOptions.RemoveEmptyEntries)[1]);
            string Resolution = description.LastOrDefault();
            return new ImgFile(Name, Extension, Size, Resolution);
        }
    }
}
