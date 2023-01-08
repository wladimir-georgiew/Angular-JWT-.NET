using ArtCave.Web.Data.Entities;
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

        public DbSet<Category> Categories { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<Stand> Stands { get; set; }
        public DbSet<Tag> Tags { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
