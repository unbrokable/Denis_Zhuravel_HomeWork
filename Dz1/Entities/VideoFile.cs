using System;
using System.Collections.Generic;
using System.Text;

namespace Dz1
{
    class VideoFile : File
    {
        public string Resolution { get; set; }
        public string Length { get; set; }
        public VideoFile(string Name, string Extension, FileSize Size, string Resolution, string Length) : base(Name, Extension, Size)
        {
            this.Resolution = Resolution;
            this.Length = Length;
        }
        public override string ToString()
        {
            return base.ToString() + $"\t{nameof(Length)}:{Length}\n";
        }
    }
}
