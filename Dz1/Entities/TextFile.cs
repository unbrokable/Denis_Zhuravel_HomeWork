using System;
using System.Collections.Generic;
using System.Text;

namespace Dz1
{
    class TextFile : File
    {
        public string Content { get; set; }
        public TextFile(string Name, string Extension, FileSize Size, string Content) : base(Name, Extension, Size)
        {
            this.Content = Content;
        }
        public override string ToString()
        {
            return base.ToString() + $"\t{nameof(Content)}:{Content}\n";
        }

    }
}
