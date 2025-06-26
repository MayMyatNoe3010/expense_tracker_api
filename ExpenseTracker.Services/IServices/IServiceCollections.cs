using System;

namespace ExpenseTracker.Services.IServices;

public interface IServiceCollections
{
     ITransactionServices TransactionServices { get; }
     ICategoryServices CategoryServices { get; }

}
