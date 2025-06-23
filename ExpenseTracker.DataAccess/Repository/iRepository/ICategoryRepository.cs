using System;
using ExpenseTracker.Models;

namespace ExpenseTracker.DataAccess.Repository.iRepository;

public interface ICategoryRepository: IRepository<Category>
{
    void Update(Category category);
}
