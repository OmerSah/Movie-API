using WebProjectAPI.Data.Models;
using WebProjectAPI.Services.GenericService;

namespace WebProjectAPI.Services
{
    public interface IActorService : IGenericService<Actor>
    {
        public Task<List<Actor>> GetAllByMovieId(int movieId);
        public Task deleteRelation(int actorId, int movieId);
        public Task addRelation(int actorId, int movieId);
    }
}
