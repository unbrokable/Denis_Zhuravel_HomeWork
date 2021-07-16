using EF_Practise.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace EF_Practise.Data.Configuration
{
    class FileEntityConfiguration : IEntityTypeConfiguration<File>
    {
        public void Configure(EntityTypeBuilder<File> builder)
        {
            builder.HasKey(i => i.Id);
            builder.Property(i => i.Title).HasMaxLength(30);
        }
    }
}
