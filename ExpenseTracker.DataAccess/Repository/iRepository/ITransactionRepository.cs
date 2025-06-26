using System;
using ExpenseTracker.Models;

namespace ExpenseTracker.DataAccess.Repository.iRepository;

public interface ITransactionRepository: IRepository<Transaction>
{
    void Update(Transaction transaction);
}
