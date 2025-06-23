using System;

namespace ExpenseTracker.Models.Dtos.Response;

public class BaseResponse
{
    public int Id { get; set; }
    public string? Note { get; set; }
    public DateTime? CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
}
