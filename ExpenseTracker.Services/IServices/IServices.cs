using System;
using System.Linq.Expressions;

namespace ExpenseTracker.Services.IServices;

public interface IServices<T> where T:class
{
    Task<IEnumerable<T>?> GetAllAsync(Expression<Func<T, bool>>[]? filter = null, string? includeProperties = null);
    Task<T?> GetAsync(Expression<Func<T, bool>>[]? filter = null, string? includeProperties = null);
    Task<T?> AddAsync(T item);
    Task<T?> UpdateAsync(T item);
    Task<T?> DeleteAsync(int id);
    Task<IEnumerable<T>?> GetByPageAsync(int draw, int start, int length);
}
