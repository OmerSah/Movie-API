using Microsoft.EntityFrameworkCore;
using WebProjectAPI.Data;
using WebProjectAPI.Data.Models;
using WebProjectAPI.Services.GenericService;

namespace WebProjectAPI.Services
{
    public class ActorService: GenericService<Actor>, IActorService
    {
        public ActorService(DataContext dbContext) : base(dbContext)
        {
        }

        public Task<List<Actor>> GetAllByMovieId(int movieId)
        {
            return _dbContext
                .Actors
                .Where(a => a.Movies.Any(m => m.Id == movieId))
                .ToListAsync();
        }

        public Task deleteRelation(int actorId, int movieId)
        {
            return _dbContext.Database.ExecuteSqlRawAsync(
                               "DELETE FROM ActorMovie WHERE ActorsId = {0} AND MoviesId = {1}",
                                              actorId, movieId);
        }

        public Task addRelation(int actorId, int movieId)
        {
            return _dbContext.Database.ExecuteSqlRawAsync(
                                              "INSERT INTO ActorMovie (ActorsId, MoviesId) VALUES ({0}, {1})",
                                                                                           actorId, movieId);
        }
    }
}
