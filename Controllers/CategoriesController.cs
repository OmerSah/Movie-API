using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebProjectAPI.Services;

namespace WebProjectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {

        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            this._categoryService = categoryService;
        }


        // GET: api/Categories
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_categoryService.GetAll());
        }
    }
}
