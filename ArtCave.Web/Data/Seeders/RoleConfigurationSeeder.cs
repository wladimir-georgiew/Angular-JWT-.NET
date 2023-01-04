using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace ArtCave.Web.Data.Seeders
{
    public class RoleConfigurationSeeder : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
                new IdentityRole
                {
                    Name = Constants.Constants.IdentityRoles.FreeUser,
                    NormalizedName = Constants.Constants.IdentityRoles.FreeUser.ToUpper()
                },
                new IdentityRole
                {
                    Name = Constants.Constants.IdentityRoles.Customer,
                    NormalizedName = Constants.Constants.IdentityRoles.Customer.ToUpper()
                },
                new IdentityRole
                {
                    Name = Constants.Constants.IdentityRoles.Admin,
                    NormalizedName = Constants.Constants.IdentityRoles.Admin.ToUpper()
                }
            );
        }
    }
}
