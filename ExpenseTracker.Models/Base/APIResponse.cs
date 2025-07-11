using System;

namespace ExpenseTracker.Models.Base;

public class APIResponse<T> where T : class
{
    public bool Status {get;set;}
    public string? Message { get; set; }
    public T? Data { get; set; }

}
