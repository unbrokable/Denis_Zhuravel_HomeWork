using EF_Practise.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EF_Practise.Data.Configuration
{
    class VideoFileEntityConfiguration : IEntityTypeConfiguration<VideoFile>
    {
        public void Configure(EntityTypeBuilder<VideoFile> builder)
        {
            builder.Property(i => i.Duration).HasColumnType("bigint");
        }
    }
}
