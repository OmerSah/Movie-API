using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using WebProjectAPI.Data;
using WebProjectAPI.Data.Models;
using WebProjectAPI.Services.GenericService;

namespace WebProjectAPI.Services
{
    public class UserService : GenericService<User>, IUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserService(IHttpContextAccessor httpContextAccessor, DataContext context) : base(context)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public Task<User> GetByUsername(string username)
        {
            return _dbContext.Users.FirstOrDefaultAsync(x => x.Username == username);
        }

        public string GetMyName()
        {
            var result = string.Empty;
            if (_httpContextAccessor.HttpContext != null)
            {
                result = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Name);
            }
            return result;
        }

        
    }
}
