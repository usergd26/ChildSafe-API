using ChildSafe.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ChildSafe.Domain
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<School> Schools { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<AppUser>(entity =>
            {

                entity.Property(u => u.Name)
                      .IsRequired()
                      .HasMaxLength(100);

                entity.Property(u => u.Email)
                      .IsRequired()
                      .HasMaxLength(100);

                entity.HasIndex(u => u.Email)
                       .IsUnique();
            });

            modelBuilder.Entity<School>(entity =>
            {
                entity.Property(s => s.Name)
                      .IsRequired()
                      .HasMaxLength(100);
                entity.Property(s => s.Address)
                      .IsRequired()
                      .HasMaxLength(200);
                entity.Property(s => s.Email)
                      .IsRequired()
                      .HasMaxLength(100);
                entity.Property(s => s.PhoneNumber)
                      .IsRequired()
                      .HasMaxLength(15);
                entity.HasOne(s => s.User)
                      .WithMany(u => u.Schools)
                      .HasForeignKey(s => s.AdminId)
                      .OnDelete(DeleteBehavior.Restrict);
                entity.HasQueryFilter(x => !x.IsDeleted);
            });


            modelBuilder.Entity<Student>(entity =>
            {
                entity.Property(s => s.Name)
                      .IsRequired()
                      .HasMaxLength(100);
                entity.HasOne(s => s.User)
                      .WithMany(u => u.Students)
                      .HasForeignKey(s => s.ParentId)
                      .OnDelete(DeleteBehavior.Restrict);
                entity.HasQueryFilter(x => !x.IsDeleted);
            });
        }

    }
}
