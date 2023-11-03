using EF_GenericRepository_2Database_repository.Models;
using System.Collections.Generic;

namespace EF_GenericRepository_2Database_repository.Repositories
{
    public interface IRepository<T> where T : IEntity
    {
        Task<T> CreateAsync(T entity);
        Task<List<T>> GetAllAsync();
        Task<T> GetAsync(long id);
        Task RemoveAsync(long id);
        Task UpdateAsync(T entity);
    }
}
