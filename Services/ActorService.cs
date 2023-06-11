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
    }
}
