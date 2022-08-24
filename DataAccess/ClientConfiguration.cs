using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess;

public class ClientConfiguration : IEntityTypeConfiguration<Client>
{
    public void Configure(EntityTypeBuilder<Client> builder)
    {
        builder.ToTable("Clients");
        // Add Soft Delete Filter
        builder.HasQueryFilter(p => !p.IsDeleted);

        builder.HasData(new Client[]{
            new Client { Id= 1, Name = "Emi", Surname = "Con", CreatedTime = new DateTime(2022, 08, 18), ModifiedTime = new DateTime(2022, 08, 18) }
        });
    }
}