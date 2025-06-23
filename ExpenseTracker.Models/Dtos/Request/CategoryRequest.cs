using System;

namespace ExpenseTracker.Models.Dtos.Request;

public class CategoryRequest
{
    public string Name { get; set; }
    public string Icon { get; set; }
    public string Color { get; set; }
}
