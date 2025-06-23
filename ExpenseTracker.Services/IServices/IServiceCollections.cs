using System;

namespace ExpenseTracker.Services.IServices;

public interface IServiceCollections
{
     IExpenseServices ExpenseServices { get; }
     ICategoryServices CategoryServices { get; }

}
