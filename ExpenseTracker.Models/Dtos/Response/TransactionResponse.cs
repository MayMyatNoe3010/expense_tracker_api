using System;

namespace ExpenseTracker.Models.Dtos.Response;

public class TransactionResponse : BaseResponse
{
    public double Amount { get; set; }
    public string Title { get; set; }
    public CategoryResponse? Category { get; set; }
    public TransactionType TransactionType { get; set; }
}
