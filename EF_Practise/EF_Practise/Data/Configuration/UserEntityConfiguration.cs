using EF_Practise.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EF_Practise.Data.Configuration
{
    class UserEntityConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(i => i.Id);
            builder.Property(i => i.Email).HasMaxLength(30).IsRequired();
            builder.Property(i => i.UserName).HasMaxLength(30).IsRequired();
            builder.Property(i => i.PasswordHash).HasMaxLength(30).IsRequired();
        }
    }
}
