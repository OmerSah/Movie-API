using WebProjectAPI.Data.Models;
using WebProjectAPI.Services.GenericService;

namespace WebProjectAPI.Services
{
    public interface IUserService: IGenericService<User>
    {
        string GetMyName();
        Task<User> GetByUsername(string username);
    }
}
