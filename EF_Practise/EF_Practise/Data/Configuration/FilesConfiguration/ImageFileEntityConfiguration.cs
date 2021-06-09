using EF_Practise.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EF_Practise.Data.Configuration
{
    class ImageFileEntityConfiguration : IEntityTypeConfiguration<ImageFile>
    {
        public void Configure(EntityTypeBuilder<ImageFile> builder)
        {
    
            builder.Property(i => i.Title).HasMaxLength(30);
        }
    }
}
