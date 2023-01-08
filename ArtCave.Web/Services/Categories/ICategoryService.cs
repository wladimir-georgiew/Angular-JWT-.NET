using ArtCave.Web.Data.Entities;
using ArtCave.Web.DTO.Admin.Categories;
using ArtCave.Web.Services.BaseCrud;

namespace ArtCave.Web.Services.Categories
{
    public interface ICategoryService : IBaseCrudOperations<Category>
    {
        Category MapToCategory(CreateCategoryRequest dto);
    }
}
