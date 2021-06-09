using EF_Practise.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EF_Practise.Data.Configuration
{
    class DirectoryEntityConfiguration : IEntityTypeConfiguration<Directory>
    {
        public void Configure(EntityTypeBuilder<Directory> builder)
        {
            builder.HasKey(i => i.Id);
            builder.Property(i => i.Title).HasMaxLength(30).IsRequired();
            builder.HasOne(i => i.ParentDirectory)
                .WithMany(i => i.Directories)
                .HasForeignKey(i => i.ParentDirectoryId);
                
        }

    }
}
