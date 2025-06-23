using System;

namespace ExpenseTracker.Models.Dtos.Response;

public class CategoryResponse : BaseResponse
{
    public string Name { get; set; }
    public string Icon { get; set; }
    public string Color { get; set; }
}
