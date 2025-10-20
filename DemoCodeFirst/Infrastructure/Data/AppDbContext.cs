using DemoCodeFirst.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DemoCodeFirst.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //cấu hình quan hệ 1-nhiều (Category - Product)
            modelBuilder.Entity<Category>()
                .HasMany(c => c.Products)
                .WithOne(p => p.Category)
                .HasForeignKey(p => p.CategoryId);

            modelBuilder.Entity<Product>()
                .Property(p => p.Id)
                .HasDefaultValueSql("uuid_generate_v4()");
            modelBuilder.Entity<Category>()
                .Property(c => c.Id)
                .HasDefaultValueSql("uuid_generate_v4()");
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var entries = ChangeTracker
                .Entries<AuditableEntity>();
            foreach (var entry in entries)
            {
                //if (entry.State == EntityState.Added)
                //{
                //    entry.Entity.CreatedBy = "System"; // Thay thế bằng người dùng thực tế
                //    entry.Entity.CreatedDateOnUtc = DateTime.UtcNow;
                //}
                //else if (entry.State == EntityState.Modified)
                //{
                //    entry.Entity.LastModifiedBy = "System"; // Thay thế bằng người dùng thực tế
                //    entry.Entity.LastModifiedDateOnUtc = DateTime.UtcNow;
                //}

                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedDateOnUtc = DateTime.UtcNow;
                        entry.Entity.CreatedBy = "System"; // Thay "System" bằng user hiện tại nếu có
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModifiedDateOnUtc = DateTime.UtcNow;
                        entry.Entity.LastModifiedBy = "System"; // Thay "System" bằng user hiện tại nếu có
                        break;
                }
            }
            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
