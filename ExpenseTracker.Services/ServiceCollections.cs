using System;
using ExpenseTracker.DataAccess.Repository.iRepository;
using ExpenseTracker.Services.IServices;

namespace ExpenseTracker.Services;

public class ServiceCollections : IServiceCollections
{
    public ITransactionServices TransactionServices { get; private set; }
    public ICategoryServices CategoryServices { get; private set; }
    public ServiceCollections(IUnitOfWork unitOfWork)
    {
        TransactionServices = new TransactionServices(unitOfWork);
        CategoryServices = new CategoryServices(unitOfWork);
    }

}
