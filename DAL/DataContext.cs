using Domain.Models;

using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public sealed class DataContext : DbContext
    {
        public DbSet<UserModel> Users { get; set; }
        public DbSet<DocumentModel> Documents { get; set; }
        public DbSet<UserDocumentModel> UserDocuments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        { 
            optionsBuilder.UseNpgsql(@"Host=localhost;Port=5432;Username=postgres;Password=1488;Database=test_extensions;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserModel>(builder => builder.Property(model => model.Id).ValueGeneratedOnAdd());

            modelBuilder.Entity<DocumentModel>(builder => builder.Property(model => model.Id).ValueGeneratedOnAdd());

            modelBuilder.Entity<UserDocumentModel>(builder =>
            {
                builder.Property(model => model.Id).ValueGeneratedOnAdd();

                builder
                    .HasOne(model => model.Document)
                    .WithMany(model => model.Users)
                    .HasForeignKey(model => model.DocumentId);

                builder
                    .HasOne(model => model.User)
                    .WithMany(model => model.Documents)
                    .HasForeignKey(model => model.UserId);
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}