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

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
           : base(options)
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationContext).Assembly);
        }
    }
}
