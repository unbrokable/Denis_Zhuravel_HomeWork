using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Dz1
{
    enum FileType
    {
        Text, Movie, Image 
    }
    abstract class File:IComparable<File>
    {
        public string Name { get; set; }
        public string Extension { get; set; }
        public FileSize Size { get; set; }

        public File( string Name, string Extension, FileSize Size)
        {
            this.Extension = Extension;
            this.Size = Size;
            this.Name = Name;
        } 
        public int CompareTo([AllowNull] File other)
        {
            if (other == null) return 1;

            return Size.CompareTo(other.Size);
        }
        public override string ToString()
        {
            return $"{nameof(Name)}:{Name}\n\t{nameof(Extension)}:{Extension}\n\t{nameof(Size)}:{Size}\n";
        }

       
    }
   

 
}
