using System;
using System.Collections.Generic;
using System.Text;

namespace Dz1
{
    class TextFile : File
    {
        public string Content { get; set; }
        public TextFile(string name, string extension, FileSize size, string content) : base(name, extension, size)
        {
            this.Content = content;
        }
        public override string ToString()
        {
            return base.ToString() + $"\t{nameof(Content)}:{Content}\n";
        }

    }
}
