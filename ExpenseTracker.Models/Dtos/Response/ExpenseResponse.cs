using System;

namespace ExpenseTracker.Models.Dtos.Response;

public class ExpenseResponse : BaseResponse
{
    public double Amount { get; set; }
    public string Title { get; set; }
    public CategoryResponse? Category { get; set; }
}
