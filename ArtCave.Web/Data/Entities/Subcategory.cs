using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ArtCave.Web.Data.Entities
{
    [Index(nameof(Name), IsUnique = true)]
    public class Subcategory
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public int CategoryId { get; set; }

        public virtual Category? Category { get; set; }
    }
}
