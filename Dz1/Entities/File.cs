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
    class ComparerFileBySize : Comparer<File>
    {
        public override int Compare([AllowNull] File x, [AllowNull] File y)
        {
            if (x == null && y == null)
            {
                return 0;
            }
            else if (x == null)
            {
                return -1;
            }
            else if (y == null)
            {
                return 1;
            }
            return x.Size.CompareTo(y.Size);
        }
    }
    abstract class File
    {
        public string Name { get; set; }
        public string Extension { get; set; }
        public FileSize Size { get; set; }

        public File( string name, string extension, FileSize size)
        {
            this.Extension = extension;
            this.Size = size;
            this.Name = name;
        } 

        public override string ToString()
        {
            return $"{nameof(Name)}:{Name}\n\t{nameof(Extension)}:{Extension}\n\t{nameof(Size)}:{Size}\n";
        }

       
    }
   

 
}
