using WebProjectAPI.Data;
using WebProjectAPI.Data.Models;
using WebProjectAPI.Services.GenericService;

namespace WebProjectAPI.Services
{
    public class CategoryService: GenericService<Category>, ICategoryService
    {
        public CategoryService(DataContext context) : base(context)
        {
        }
    }
}
