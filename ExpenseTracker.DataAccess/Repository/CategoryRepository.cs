using System;
using ExpenseTracker.DataAccess.Data;
using ExpenseTracker.DataAccess.Repository.iRepository;
using ExpenseTracker.Models;

namespace ExpenseTracker.DataAccess.Repository;

public class CategoryRepository : Repository<Category>, ICategoryRepository
{
    private readonly ApplicationDBContext _db;
    public CategoryRepository(ApplicationDBContext db) : base(db)
    {
        _db = db;
    }
    public void Update(Category category)
    {
        _db.Categories.Update(category);
    }
}
