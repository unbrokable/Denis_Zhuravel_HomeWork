using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Dz1
{  
    
    enum FileSizeType {
            B, MB, GB
    }
    class FileSize:IComparable<FileSize>
    {
        public FileSizeType Type { get; set; }
        public int Length { get; set; }
        
        public FileSize(FileSizeType type, int Length)
        {
            this.Type = type;
            this.Length = Length;
        }
        
        public override string ToString()
        {
            return $"{Length}{Type.ToString()}";
        }

        public int CompareTo([AllowNull] FileSize other)
        {

            if (other == null) return 1;
            double convertToBCur = Math.Pow(1024, (int)(Type - FileSizeType.B));
            double convertToBOther = Math.Pow(1024, (int)(other.Type - FileSizeType.B));

            return (Length * (convertToBCur == 0 ? 1: convertToBCur) ).CompareTo(other.Length * (convertToBOther== 0 ? 1 : convertToBOther) );

        }
    }
}
