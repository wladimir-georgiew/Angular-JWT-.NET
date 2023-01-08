using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArtCave.Web.Data.Entities
{
    public class Item
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }

        [Required]
        public string StandId { get; set; } = string.Empty;

        [Required]
        public int CategoryId { get; set; }

        [Required]
        public DateTime Created { get; set; } = DateTime.UtcNow;

        public string Description { get; set; } = string.Empty;

        public virtual Stand? Stand { get; set; }
        public virtual Category? Category { get; set; }
        public virtual ICollection<Photo> Photos { get; set; } = new HashSet<Photo>();
        public virtual ICollection<Tag> Tags { get; set; } = new HashSet<Tag>();
    }
}
