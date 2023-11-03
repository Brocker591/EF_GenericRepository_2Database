using EF_GenericRepository_2Database_repository.Models;
using Microsoft.EntityFrameworkCore;


namespace EF_GenericRepository_2Database_repository.Repositories
{
    public class RepositoryAsync<T> : IRepository<T> where T : class, IEntity
    {
        private readonly MyDbContext _clockitContext;

        public RepositoryAsync(MyDbContext clockitContext)
        {
            _clockitContext = clockitContext;
        }


        public async Task<T> CreateAsync(T entity)
        {
            _clockitContext.Set<T>().Add(entity);
            await _clockitContext.SaveChangesAsync();
            return entity;
        }

        public async Task<List<T>> GetAllAsync()
        {
            var existingEntities = await _clockitContext.Set<T>().OrderBy(entity => entity.Id).ToListAsync();
            return existingEntities;
        }

        public async Task<T> GetAsync(long id)
        {
            var existingEntity = await _clockitContext.Set<T>().FindAsync(id);
            return existingEntity;
        }

        public async Task RemoveAsync(long id)
        {
            await _clockitContext.Set<T>().Where(entity => entity.Id == id).ExecuteDeleteAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _clockitContext.Set<T>().Update(entity);
            await _clockitContext.SaveChangesAsync();
        }
    }
}
