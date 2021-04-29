using System;
using System.Collections.Generic;
using System.Text;

namespace Dz1
{
    class ImgFile : File
    {
        public string Resolution { get; set; }
        public ImgFile(string Name, string Extension, FileSize Size, string Resolution) : base(Name, Extension, Size)
        {
            this.Resolution = Resolution;
        }
        public override string ToString()
        {
            return base.ToString() + $"\t{nameof(Resolution)}:{Resolution}\n";
        }
    }
}
