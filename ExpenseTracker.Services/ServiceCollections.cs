using System;
using ExpenseTracker.DataAccess.Repository.iRepository;
using ExpenseTracker.Services.IServices;

namespace ExpenseTracker.Services;

public class ServiceCollections : IServiceCollections
{
    public IExpenseServices ExpenseServices { get; private set; }
    public ICategoryServices CategoryServices { get; private set; }
    public ServiceCollections(IUnitOfWork unitOfWork)
    {
        ExpenseServices = new ExpenseServices(unitOfWork);
        CategoryServices = new CategoryServices(unitOfWork);
    }

}
