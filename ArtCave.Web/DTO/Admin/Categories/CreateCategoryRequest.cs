using System.ComponentModel.DataAnnotations;

namespace ArtCave.Web.DTO.Admin.Categories
{
    public class CreateCategoryRequest
    {
        [Required]
        public string CategoryName { get; set; } = string.Empty;
    }
}
