using WebProjectAPI.Data;
using WebProjectAPI.Data.Models;
using WebProjectAPI.Services.GenericService;

namespace WebProjectAPI.Services
{
    public class MovieService: GenericService<Movie>, IMovieService
    {
        public MovieService(DataContext dbContext) : base(dbContext)
        {
        }
    }
}
