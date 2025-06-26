using System;
using ExpenseTracker.DataAccess.Data;
using ExpenseTracker.DataAccess.Repository.iRepository;

namespace ExpenseTracker.DataAccess.Repository;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDBContext _db;
    public ITransactionRepository TransactionRepository { get; private set; }
    public ICategoryRepository CategoryRepository { get; private set; }
    public UnitOfWork(ApplicationDBContext db)
    {
        _db = db;
        TransactionRepository = new TransactionRepository(_db);
        CategoryRepository = new CategoryRepository(_db);
    }

    public async Task SaveAsync()
    {
        await _db.SaveChangesAsync();
    }
}
