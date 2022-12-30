using ArtCave.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

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

            // Add seed
        }
    }
}
