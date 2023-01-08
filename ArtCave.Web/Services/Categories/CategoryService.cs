using ArtCave.Web.Data;
using ArtCave.Web.Data.Entities;
using ArtCave.Web.DTO.Admin.Categories;
using ArtCave.Web.Services.BaseCrud;
using AutoMapper;

namespace ArtCave.Web.Services.Categories
{
    public class CategoryService : BaseCrudOperations<Category>, ICategoryService
    {
        private readonly IMapper _mapper;

        public CategoryService(ArtCaveDbContext context, IMapper mapper)
            : base(context)
        {
            _mapper = mapper;
        }

        public Category MapToCategory(CreateCategoryRequest dto)
        {
            return _mapper.Map<Category>(dto);
        }
    }
}
