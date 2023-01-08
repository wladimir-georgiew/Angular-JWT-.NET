using System.ComponentModel.DataAnnotations;

namespace ArtCave.Web.Data.Entities
{
    public class Stand
    {
        public Stand()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        [Key]
        public string Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public int MaxItemsCount { get; set; } = 5;

        [Required]
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }
        public virtual ICollection<Item> Items { get; set; } = new HashSet<Item>();
    }
}
