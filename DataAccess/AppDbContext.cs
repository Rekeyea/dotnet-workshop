using Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DataAccess;

public class AppDbContext : IdentityDbContext<IdentityUser>
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Product> Products { get; set; }

    public DbSet<Client> Clients { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new ProductConfiguration());
        modelBuilder.ApplyConfiguration(new ClientConfiguration());
        modelBuilder.ConfigureIdentityTables();
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var entries = ChangeTracker
            .Entries()
            .Where(x => x.Entity is Entity);

        foreach (var e in entries)
        {
            var entity = e.Entity as Entity;
            if (entity is not null)
            {
                entity.ModifiedTime = DateTime.UtcNow;
                switch (e.State)
                {
                    case EntityState.Added:
                        entity.CreatedTime = DateTime.UtcNow;
                        break;
                    case EntityState.Deleted:
                        entity.DeletedTime = DateTime.Now;
                        entity.IsDeleted = true;
                        e.State = EntityState.Modified;
                        break;
                }
            }
        }

        return base.SaveChangesAsync(cancellationToken);
    }
}