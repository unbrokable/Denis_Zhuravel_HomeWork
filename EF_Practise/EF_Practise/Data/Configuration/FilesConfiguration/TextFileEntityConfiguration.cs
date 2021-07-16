using EF_Practise.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;


namespace EF_Practise.Data.Configuration
{
    class TextFileEntityConfiguration : IEntityTypeConfiguration<TextFile>
    {
        public void Configure(EntityTypeBuilder<TextFile> builder)
        {
            
        }
    }
}
