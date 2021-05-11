using System;
using System.Collections.Generic;
using System.Text;

namespace Dz1
{
    class VideoFile : File
    {
        public string Resolution { get; set; }
        public string Length { get; set; }
        public VideoFile(string name, string extension, FileSize size, string resolution, string length) : base(name, extension, size)
        {
            this.Resolution = resolution;
            this.Length = length;
        }
        public override string ToString()
        {
            return base.ToString() + $"\t{nameof(Length)}:{Length}\n\t{nameof(Resolution)}:{Resolution}\n";
        }
    }
}
