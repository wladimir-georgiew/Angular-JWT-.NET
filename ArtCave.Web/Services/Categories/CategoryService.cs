using ArtCave.Web.Data;
using ArtCave.Web.Data.Entities;
using ArtCave.Web.DTO.Admin.Categories;
using ArtCave.Web.Services.BaseCrud;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace ArtCave.Web.Services.Categories
{
    public class CategoryService : BaseCrudOperations<Category>, ICategoryService
    {
        private readonly ArtCaveDbContext _context;
        private readonly IMapper _mapper;

        public CategoryService(ArtCaveDbContext context, IMapper mapper)
            : base(context)
        {
            _context = context;
            _mapper = mapper;
        }

        public override async Task<Category?> AddAsync(Category category)
        {
            if (_context.Categories.Any(x => x.Name == category.Name))
            {
                return null;
            }

            return await base.AddAsync(category);
        }

        public Category MapToCategory(CreateCategoryRequest dto)
        {
            return _mapper.Map<Category>(dto);
        }
    }
}
