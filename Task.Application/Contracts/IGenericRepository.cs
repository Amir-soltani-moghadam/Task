using System.Linq.Expressions;

namespace Task.Application.Contracts
{
    public interface IGenericRepository<T> where T : class
    {

        Task<T> GetAsync(int Id, params Expression<Func<T, object>>[] includes);
        Task<IReadOnlyList<T>> GetAllAsync(params Expression<Func<T, object>>[] includes);
        IQueryable<T> Query(params Expression<Func<T, object>>[] includes);
        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task<T> DeleteAsync(T entity);
        Task<bool> ExistAsync(Expression<Func<T, bool>> predicate);

    }
}
