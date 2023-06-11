using System.Security.Principal;
using WebProjectAPI.Data.Models.Base;

namespace WebProjectAPI.Services.GenericService
{
    public interface IGenericService<TEntity>
        where TEntity : class, IEntity
    {
        IQueryable<TEntity> GetAll();

        Task<TEntity> GetById(int id);

        Task<List<TEntity>> GetByIds(List<int> id);

        Task<TEntity> Create(TEntity entity);

        Task<TEntity> Update(int id, TEntity entity);

        Task Delete(int id);
    }
}
