using System;

namespace ExpenseTracker.Models.Dtos.Request;

public class ExpenseRequest
{
    public string Title { get; set; }
    public decimal Amount { get; set; }
    public int CategoryId { get; set; }
}

