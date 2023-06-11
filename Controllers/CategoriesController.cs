using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebProjectAPI.Data.Models;
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

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_categoryService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<Category> GetById(int id)
        {
            return await _categoryService.GetById(id);
        }

    }
}
