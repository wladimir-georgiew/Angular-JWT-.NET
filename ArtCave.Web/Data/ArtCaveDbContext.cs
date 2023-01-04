using ArtCave.Data.Entities;
using ArtCave.Web.Data.Seeders;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace ArtCave.Web.Data
{
    public class ArtCaveDbContext : IdentityDbContext<ApplicationUser>
    {
        public ArtCaveDbContext(DbContextOptions<ArtCaveDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new RoleConfigurationSeeder());
        }
    }
}
