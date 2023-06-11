using WebProjectAPI.Data;
using WebProjectAPI.Data.Models;
using WebProjectAPI.Services.GenericService;

namespace WebProjectAPI.Services
{
    public class ProducerService: GenericService<Producer>, IProducerService
    {
        public ProducerService(DataContext context) : base(context)
        {
        }
    }
}
