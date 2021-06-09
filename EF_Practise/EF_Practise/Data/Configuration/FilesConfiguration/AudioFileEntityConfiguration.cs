using EF_Practise.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EF_Practise.Data.Configuration
{
    class AudioFileEntityConfiguration : IEntityTypeConfiguration<AudioFile>
    {
        public void Configure(EntityTypeBuilder<AudioFile> builder)
        {
            builder.Property(i => i.Duration).HasColumnType("bigint");
        }
    }
}
