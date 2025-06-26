using System;

namespace ExpenseTracker.DataAccess.Repository.iRepository;

public interface IUnitOfWork
{
    ITransactionRepository TransactionRepository { get; }
    ICategoryRepository CategoryRepository { get; }
    Task SaveAsync();
}
