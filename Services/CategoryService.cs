using Microsoft.EntityFrameworkCore;
using WebProjectAPI.Data;
using WebProjectAPI.Data.Models;
using WebProjectAPI.Services.GenericService;

namespace WebProjectAPI.Services
{
    public class CategoryService : GenericService<Category>, ICategoryService
    {
        public CategoryService(DataContext context) : base(context)
        {
        }

        public Task<List<Category>> GetAllByMovieId(int movieId)
        {
            return _dbContext
                .Categories
                .Where(c => c.Movies.Any(m => m.Id == movieId))
                .ToListAsync();
        }

        public Task deleteRelation(int categoryId, int movieId)
        {
            return _dbContext.Database.ExecuteSqlRawAsync(
                               "DELETE FROM CategoryMovie WHERE MoviesId = {0} AND CategoriesId = {1}", movieId, categoryId
                );
        }

        public Task addRelation(int categoryId, int movieId)
        {
            return _dbContext.Database.ExecuteSqlRawAsync(
                "INSERT INTO CategoryMovie (MoviesId, CategoriesId) VALUES ({0}, {1})", movieId, categoryId
                );
        }
    }
}
