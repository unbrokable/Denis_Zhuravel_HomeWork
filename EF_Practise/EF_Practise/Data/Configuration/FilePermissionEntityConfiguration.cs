using EF_Practise.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EF_Practise.Data.Configuration
{
    class FilePermissionEntityConfiguration : IEntityTypeConfiguration<FilePermission>
    {
        public void Configure(EntityTypeBuilder<FilePermission> builder)
        {
            builder.HasKey(i => new { i.FileId, i.UserId });
            builder.HasOne(i => i.User)
                .WithMany(i => i.FilePermissions)
                .HasForeignKey(i => i.UserId)
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(i => i.File)
                .WithMany(i => i.FilePermissions)
                .HasForeignKey(i => i.FileId);

            builder.Property(i => i.CanWrite);
            builder.Property(i => i.CanRead);

        }
    }
}
