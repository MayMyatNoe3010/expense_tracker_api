using System;
using ExpenseTracker.DataAccess.Data;
using ExpenseTracker.DataAccess.Repository.iRepository;
using ExpenseTracker.Models;

namespace ExpenseTracker.DataAccess.Repository;

public class ExpenseRepository  : Repository<Expense>, IExpenseRepository
{
    private readonly ApplicationDBContext _db;

    public ExpenseRepository(ApplicationDBContext db) : base(db)
    {
        _db = db;
    }

    public void Update(Expense expense)
    {
        _db.Expenses.Update(expense);
    }

}
