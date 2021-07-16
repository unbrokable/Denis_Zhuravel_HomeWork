using System;
using System.Collections.Generic;
using System.Text;

namespace EF_Practise.Data.Entities
{
    class ImageFile: File
    {
        public int Height { get; set; }
        public int Width { get; set; }
    }
}
