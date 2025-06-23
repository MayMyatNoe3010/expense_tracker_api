using System;
using System.Linq.Expressions;
using ExpenseTracker.Models.Base;

namespace ExpenseTracker.DataAccess.Repository.iRepository;

public interface IRepository<T>
    where T : class
{
    Task<IEnumerable<T>> GetAllAsync(
        Expression<Func<T, bool>>[]? filter = null,
        string? includeProperties = null
    );
    
    Task<PaginatedObject<T>> GetAllWithPaginationAsync(
        int page = 1,
        int pageSize = 10,
        string? searchTerm = null,
        Expression<Func<T, bool>>[]? filter = null,
        string? includeProperties = null
    );
    Task<T> GetAsync(
        Expression<Func<T, bool>>[] filter,
        string? includeProperties = null,
        bool tracked = false
    );
    Task AddAsync(T entity);
    Task AddRangeAsync(IEnumerable<T> entities);
    Task<T> DeleteAsync(int id);
    Task RemoveAsync(T entity);
    Task RemoveRangeAsync(IEnumerable<T> entities);
    

}
