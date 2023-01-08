using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ArtCave.Web.Data.Entities
{
    [Index(nameof(Name), IsUnique = true)]
    public class Tag
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        public virtual ICollection<Item> Items { get; set; } = new HashSet<Item>();
    }
}
