using System;
using System.Linq.Expressions;
using ExpenseTracker.DataAccess.Repository.iRepository;
using ExpenseTracker.Models;
using ExpenseTracker.Services.IServices;

namespace ExpenseTracker.Services;

public class CategoryServices : ICategoryServices
{
    private readonly IUnitOfWork _unitOfWork;

    public CategoryServices(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Transaction?> AddAsync(Transaction item)
    {
        await _unitOfWork.TransactionRepository.AddAsync(item);
        await _unitOfWork.SaveAsync();
        return item;
    }


    public async Task<Transaction?> DeleteAsync(int id)
    {
        Transaction deletedTransaction = await _unitOfWork.TransactionRepository.DeleteAsync(id);
        return deletedTransaction;
    }

    public Task<IEnumerable<Transaction>?> GetAllAsync(Expression<Func<Transaction, bool>>[]? filter = null, string? includeProperties = null)
    {
        throw new NotImplementedException();
    }

    public Task<Transaction?> GetAsync(Expression<Func<Transaction, bool>>[]? filter = null, string? includeProperties = null)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Transaction>?> GetByPageAsync(int draw, int start, int length)
    {
        throw new NotImplementedException();
    }

    public Task<Transaction?> UpdateAsync(Transaction item)
    {
        throw new NotImplementedException();
    }
}
