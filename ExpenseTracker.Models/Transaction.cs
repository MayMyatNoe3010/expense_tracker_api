using System;
using System.ComponentModel.DataAnnotations.Schema;
using ExpenseTracker.Models.Base;

namespace ExpenseTracker.Models;

public class Transaction : BaseModel
{
    public double Amount { get; set; }
    public string Title { get; set; }
    public int CategoryId { get; set; }
    public Category? Category { get; set; }
    public TransactionType TransactionType { get; set; }
    
}
