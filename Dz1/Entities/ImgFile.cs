using System;
using System.Collections.Generic;
using System.Text;

namespace Dz1
{
    class ImgFile : File
    {
        public string Resolution { get; set; }
        public ImgFile(string name, string extension, FileSize size, string resolution) : base(name, extension, size)
        {
            this.Resolution = resolution;
        }
        public override string ToString()
        {
            return base.ToString() + $"\t{nameof(Resolution)}:{Resolution}\n";
        }
    }
}
