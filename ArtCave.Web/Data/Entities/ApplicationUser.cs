using Microsoft.AspNetCore.Identity;

namespace ArtCave.Web.Data.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        // Change to non-nullable when countries are seeded in the database and the drop-down is implemented in the registration
        public int? CountryId { get; set; }

        public Stand? Stand { get; set; }
        public virtual Country? Country { get; set; }
    }
}