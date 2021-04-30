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
            string name = description[0].Split('(', StringSplitOptions.RemoveEmptyEntries)[0];
            string extension = name.Split('.', StringSplitOptions.RemoveEmptyEntries).LastOrDefault();
            FileSize size = new ParserFileSize().Parse(description[0].Split(new char[] { '(', ')' }, StringSplitOptions.RemoveEmptyEntries)[1]);
            string resolution = description.LastOrDefault();
            return new ImgFile(name, extension, size, resolution);
        }
    }
}
