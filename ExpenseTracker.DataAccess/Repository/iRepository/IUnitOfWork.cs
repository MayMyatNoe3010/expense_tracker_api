using System;

namespace ExpenseTracker.DataAccess.Repository.iRepository;

public interface IUnitOfWork
{
    IExpenseRepository ExpenseRepository { get; }
    ICategoryRepository CategoryRepository { get; }
    Task SaveAsync();
}
