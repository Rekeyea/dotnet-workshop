using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace DataAccess;

public static class IdentityDataBuilder
{
    public static void ConfigureIdentityTables(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<IdentityUser>(b => {
            b.ToTable("Users");
        });
        modelBuilder.Entity<IdentityRole>(b => {
            b.ToTable("Roles");
        });
        modelBuilder.Entity<IdentityUserRole<string>>(b => {
            b.ToTable("UserRoles");
        });
        modelBuilder.Entity<IdentityUserToken<string>>(b => {
            b.ToTable("UserTokens");
        });

        modelBuilder.Entity<IdentityRoleClaim<string>>(b => {
            b.ToTable("RoleClaims");
        });
        modelBuilder.Entity<IdentityUserClaim<string>>(b => {
            b.ToTable("UserClaims");
        });
        modelBuilder.Entity<IdentityUserLogin<string>>(b => {
            b.ToTable("UserLogins");
        });
    }
}