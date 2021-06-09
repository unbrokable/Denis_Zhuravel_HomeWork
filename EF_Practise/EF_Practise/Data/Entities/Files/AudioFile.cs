using System;
using System.Collections.Generic;
using System.Text;

namespace EF_Practise.Data.Entities
{
    class AudioFile : File
    {
        public int Bitrate { get; set; }
        public int SampleRate { get; set; }
        public int ChannelCount { get; set; }
        public TimeSpan Duration { get; set; }
    }
}
