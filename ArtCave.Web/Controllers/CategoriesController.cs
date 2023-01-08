using ArtCave.Web.DTO.Admin.Categories;
using ArtCave.Web.Services.Categories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ArtCave.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }


        [HttpPost("add")]
        [ProducesResponseType(200, Type = typeof(int))]
        //[Authorize]
        public async Task<ActionResult> AddCategory(CreateCategoryRequest categoryRequest)
        {
            var category = _categoryService.MapToCategory(categoryRequest);
            var res = await _categoryService.AddAsync(category);

            return Ok(res.Id);
        }

    }
}
