using WebProjectAPI.Data.Models;
using WebProjectAPI.Services.GenericService;

namespace WebProjectAPI.Services
{
    public interface ICategoryService : IGenericService<Category>
    {
        public Task<List<Category>> GetAllByMovieId(int movieId);
        public Task deleteRelation(int categoryId, int movieId);
        public Task addRelation(int categoryId, int movieId);
    }
}
