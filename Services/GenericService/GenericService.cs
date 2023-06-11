using Microsoft.EntityFrameworkCore;
using WebProjectAPI.Data;
using WebProjectAPI.Data.Models.Base;

namespace WebProjectAPI.Services.GenericService
{
    public class GenericService<TEntity> : IGenericService<TEntity>
    where TEntity : class, IEntity
    {
        protected readonly DataContext _dbContext;

        public GenericService(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<TEntity> GetAll()
        {
            return _dbContext.Set<TEntity>().AsNoTracking();
        }

        public async Task<TEntity> GetById(int id)
        {
            return await _dbContext.Set<TEntity>()
                        .AsNoTracking()
                        .FirstOrDefaultAsync(e => e.Id == id)
                        ?? throw new Exception("Entity not found.");
        }

        public async Task<List<TEntity>> GetByIds(List<int> ids)
        {
            List<TEntity> entities = new List<TEntity>();
            foreach (var id in ids)
            {
                entities.Add(await GetById(id));
            }
            return entities;
        }   
        public async Task<TEntity> Create(TEntity entity)
        {
            await _dbContext.Set<TEntity>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<TEntity> Update(int id, TEntity entity)
        {
            _dbContext.Set<TEntity>().Update(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task Delete(int id)
        {
            var entity = await GetById(id);
            _dbContext.Set<TEntity>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

    }
}
