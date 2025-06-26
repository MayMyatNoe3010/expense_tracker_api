using System;
using ExpenseTracker.Models.Base;

namespace ExpenseTracker.Models;

public class Category : BaseModel
{
    public string Name { get; set; } = string.Empty;
    public string Icon { get; set; } = string.Empty; // Store MaterialIcon name or Unicode
    public string Color { get; set; } = "#808080";//Hex Color
    public ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
}
