using System;
using System.Collections.Generic;
using System.Text;

namespace EF_Practise.DTOs
{
    class FilesAmountDTO
    {
        public int ForUser { get; set; }
        public int Total { get; set; }

        public override string ToString()
        {
            return $"Total files: {Total} For user: {ForUser}";
        }
    }
}
