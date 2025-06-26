using System;

namespace ExpenseTracker.Models.Dtos.Request;

public class TransactionRequest

{
    public string Title { get; set; }
    public decimal Amount { get; set; }
    public int CategoryId { get; set; }
    public TransactionType TransactionType { get; set; }
}

