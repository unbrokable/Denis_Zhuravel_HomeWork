using System;
using System.Collections.Generic;
using System.Text;

namespace EF_Practise.DTOs
{
    class DirectoryInfoDTO
    {
        public IEnumerable<FileDTO> Files { get; set; }
        public IEnumerable<DirectoryDTO> Directories { get; set;}

        public override string ToString()
        {
            var @string = new StringBuilder();
            @string.AppendLine("Files");
            foreach (var item in Files)
            {
                @string.AppendLine(item.Name);
            }
            @string.AppendLine("Directories");
            foreach (var item in Directories)
            {
                @string.AppendLine(item.Name);
            }
            return @string.ToString();
        }
    }
}
