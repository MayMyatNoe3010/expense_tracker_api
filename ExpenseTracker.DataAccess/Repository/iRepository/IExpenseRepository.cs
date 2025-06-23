using System;
using ExpenseTracker.Models;

namespace ExpenseTracker.DataAccess.Repository.iRepository;

public interface IExpenseRepository: IRepository<Expense>
{
    void Update(Expense expense);
}
