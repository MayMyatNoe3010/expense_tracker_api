using System;
using System.Linq.Expressions;
using ExpenseTracker.DataAccess.Repository.iRepository;
using ExpenseTracker.Models;
using ExpenseTracker.Services.IServices;

namespace ExpenseTracker.Services;

public class ExpenseServices : IExpenseServices
{
    private readonly IUnitOfWork _unitOfWork;

    public ExpenseServices(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Expense?> AddAsync(Expense item)
    {
        await _unitOfWork.ExpenseRepository.AddAsync(item);
        await _unitOfWork.SaveAsync();
        return item;
    }


    public async Task<Expense?> DeleteAsync(int id)
    {
        Expense deletedExpense = await _unitOfWork.ExpenseRepository.DeleteAsync(id);
        return deletedExpense;
    }

    public Task<IEnumerable<Expense>?> GetAllAsync(Expression<Func<Expense, bool>>[]? filter = null, string? includeProperties = null)
    {
        throw new NotImplementedException();
    }

    public Task<Expense?> GetAsync(Expression<Func<Expense, bool>>[]? filter = null, string? includeProperties = null)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Expense>?> GetByPageAsync(int draw, int start, int length)
    {
        throw new NotImplementedException();
    }

    public Task<Expense?> UpdateAsync(Expense item)
    {
        throw new NotImplementedException();
    }
}
