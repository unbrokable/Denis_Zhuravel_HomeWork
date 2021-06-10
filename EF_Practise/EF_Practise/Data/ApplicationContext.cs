using EF_Practise.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace EF_Practise.Data
{
    class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<DirectoryPermission> DirectoryPermissions { get; set; }
        public DbSet<FilePermission> FilePermissions { get; set; }
        public DbSet<Directory> Directories { get; set; }

        public DbSet<File> Files { get; set; }
        public DbSet<AudioFile> AudioFiles { get; set; }
        public DbSet<ImageFile> ImageFiles { get; set; }
        public DbSet<TextFile> TextFiles { get; set; }
        public DbSet<VideoFile> VideoFiles { get; set; }

        public ApplicationContext()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
           : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("data source=localhost;initial catalog=EF_Practise;Trusted_Connection=True;multipleactiveresultsets=True;");
            }

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationContext).Assembly);
        }
    }
}
