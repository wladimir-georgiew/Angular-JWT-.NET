using System.ComponentModel.DataAnnotations;

namespace ArtCave.Web.Data.Entities
{
    //https://learn.microsoft.com/en-us/answers/questions/682240/best-practice-for-saving-image-in-database.html
    public class Photo
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public byte[] Bytes { get; set; } = new byte[0];

        [Required]
        public int ItemId { get; set; }


        public virtual Item? Item { get; set; }
    }
}
