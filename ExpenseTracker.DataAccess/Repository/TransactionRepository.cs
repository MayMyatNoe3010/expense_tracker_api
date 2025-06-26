using System;
using ExpenseTracker.DataAccess.Data;
using ExpenseTracker.DataAccess.Repository.iRepository;
using ExpenseTracker.Models;

namespace ExpenseTracker.DataAccess.Repository;

public class TransactionRepository  : Repository<Transaction>, ITransactionRepository
{
    private readonly ApplicationDBContext _db;

    public TransactionRepository(ApplicationDBContext db) : base(db)
    {
        _db = db;
    }

    public void Update(Transaction transaction)
    {
        _db.Transactions.Update(transaction);
    }

}
