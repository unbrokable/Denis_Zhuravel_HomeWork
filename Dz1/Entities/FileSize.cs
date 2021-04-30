using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Dz1
{  
    
    enum FileSizeType {
            B = 1, MB = 1024, GB = 1048576
    }
 
    class FileSize:IComparable<FileSize>
    {
        public FileSizeType Type { get; set; }
        public int Length { get; set; }
        
        public FileSize(FileSizeType type, int length)
        {
            this.Type = type;
            this.Length = length;
        }
        
        public override string ToString()
        {
            return $"{Length}{Type.ToString()}";
        }

        public int CompareTo([AllowNull] FileSize other)
        {

            if (other == null) return 1;
            int amountOfBytesThis = CountBytes(Type ,Length);
            int amountOfBytesOther = CountBytes(other.Type, other.Length);

            return (amountOfBytesThis).CompareTo(amountOfBytesOther);

            int CountBytes(FileSizeType type, int length) => Convert.ToInt32(type) * length; 
        }
    }
}
