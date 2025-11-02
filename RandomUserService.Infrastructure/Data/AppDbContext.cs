using Microsoft.EntityFrameworkCore;
using RandomUserService.Core.Entities;

namespace RandomUserService.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(u => u.Id);

                entity.Property(u => u.Title)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(u => u.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(u => u.LastName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(u => u.Gender)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(u => u.Email)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(u => u.ExternalId)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(u => u.Timestamp)
                    .IsRequired();
            });
        }
    }
}