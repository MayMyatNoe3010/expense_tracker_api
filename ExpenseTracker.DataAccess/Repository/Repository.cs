using System;
using System.Linq.Expressions;
using ExpenseTracker.DataAccess.Data;
using ExpenseTracker.DataAccess.Repository.iRepository;
using ExpenseTracker.Models.Base;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTracker.DataAccess.Repository;

public class Repository<T> : IRepository<T> where T : class
{
    private readonly ApplicationDBContext _dbContext;
    private readonly DbSet<T> dbSet;

    public Repository(ApplicationDBContext dbContext)
    {
        _dbContext = dbContext;
        this.dbSet = _dbContext.Set<T>();
    }


    public async Task AddAsync(T entity)
    {
        await dbSet.AddAsync(entity);
        await _dbContext.SaveChangesAsync();
    }

    public async Task AddRangeAsync(IEnumerable<T> entities)
    {
        await dbSet.AddRangeAsync(entities);
        await _dbContext.SaveChangesAsync();
    }

    

    public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>>[]? filter = null, string? includeProperties = null)
    {
        IQueryable<T> query = dbSet;
        if (filter != null)
        {
            foreach (var f in filter) query = query.Where(f);
        }
        if (!string.IsNullOrEmpty(includeProperties))
        {
            foreach (var includeProp in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProp);
            }
        }
        return await query.ToListAsync();
    }

    public async Task<PaginatedObject<T>> GetAllWithPaginationAsync(int page = 1, int pageSize = 10, string? searchTerm = null, Expression<Func<T, bool>>[]? filter = null, string? includeProperties = null)
    {
        IQueryable<T> query = dbSet;

        if (filter != null)
        {
            foreach (var f in filter) query = query.Where(f);
        }

        if (!string.IsNullOrEmpty(includeProperties))
        {
            foreach (var includeProp in includeProperties
                .Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProp);
            }
        }

        // Uncomment and modify the following line if needed for search functionality
        // if (!string.IsNullOrEmpty(searchTerm))
        // {
        //     query = query.Where(s => EF.Functions.Like(s.Name, $"%{searchTerm}%"));
        // }

        return await PaginatedObject<T>.GetPagedListAsync(query, page, pageSize);
    }
    public async Task<T> GetAsync(Expression<Func<T, bool>>[] filter, string? includeProperties = null, bool tracked = false)
    {
        IQueryable<T> query;

        if (tracked)
        {
            query = dbSet;
        }
        else
        {
            query = dbSet.AsNoTracking();
        }

        if (filter != null)
        {
            foreach (var f in filter) query = query.Where(f);
        }

        if (!string.IsNullOrEmpty(includeProperties))
        {
            foreach (var includeProp in includeProperties
                .Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProp);
            }
        }

        return await query.FirstOrDefaultAsync();
    }

    public async Task<T> DeleteAsync(int id)
    {
        var entity = dbSet.Find(id);
        if (entity == null)
        {
            throw new ArgumentException($"Entity with id {id} not found.");
        }
        await RemoveAsync(entity);
        return entity;
    }
    public async Task RemoveAsync(T entity)
    {
        dbSet.Remove(entity);
        await _dbContext.SaveChangesAsync();
    }
    public async Task RemoveRangeAsync(IEnumerable<T> entities)
    {
        dbSet.RemoveRange(entities);
        await _dbContext.SaveChangesAsync();
    }
}
