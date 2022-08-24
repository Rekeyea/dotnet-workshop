using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("Products");

        // Add Soft Delete Filter
        builder.HasQueryFilter(p => !p.IsDeleted);

        var time = new DateTime(2022, 08, 18, 0, 0, 0, DateTimeKind.Utc);
        builder.HasData(new Product[]{
            new Product { Id= 1, Name = "Prod 1", Description = "Desc Prod 1", Value = 1000, CreatedTime = time, ModifiedTime = time },
            new Product { Id= 2, Name = "Prod 2", Description = "Desc Prod 2", Value = 1300, CreatedTime = time, ModifiedTime = time },
            new Product { Id= 3, Name = "Prod 3", Description = "Desc Prod 3", Value = 100, CreatedTime = time, ModifiedTime = time },
            new Product { Id= 4, Name = "Prod 4", Description = "Desc Prod 4", Value = 100.4M, CreatedTime = time, ModifiedTime = time },
            new Product { Id= 5, Name = "Prod 5", Description = "Desc Prod 5", Value = 2030.50M, CreatedTime = time, ModifiedTime = time },
            new Product { Id= 6, Name = "Prod 6", Description = "Desc Prod 6", Value = 2000, CreatedTime = time, ModifiedTime = time }
        });
    }
}