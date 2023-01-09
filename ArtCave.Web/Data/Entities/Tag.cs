using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ArtCave.Web.Data.Entities
{
    // The point of the Tags is when the user is entering the website, he will be prompt the list of Tags (for example dark, shiny, nature, religious, anime, 3d, etc..) and when a customer is adding an item to his stand, he will also add these tags to his item. Then, based on the user preference, we will show items to his liking.
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
