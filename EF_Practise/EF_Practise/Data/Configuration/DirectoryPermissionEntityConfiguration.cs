using EF_Practise.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EF_Practise.Data.Configuration
{
    class DirectoryPermissionEntityConfiguration : IEntityTypeConfiguration<DirectoryPermission>
    {
        public void Configure(EntityTypeBuilder<DirectoryPermission> builder)
        {
            builder.HasKey(i => new { i.DirectoryId, i.UserId });

            builder.HasOne(i => i.User)
                .WithMany(i => i.DirectoryPermissions)
                .HasForeignKey(i => i.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(i => i.Directory)
                .WithMany(i => i.DirectoryPermissions)
                .HasForeignKey(i => i.DirectoryId)
                .OnDelete(DeleteBehavior.Cascade);


            builder.Property(i => i.CanWrite);
            builder.Property(i => i.CanRead);
        }
    }
}
