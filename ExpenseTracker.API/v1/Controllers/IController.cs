using System;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseTracker.API.v1.Controllers;
public interface IController<TRequest, TEntity, TResponse>
    where TRequest : class
    where TEntity : class
    where TResponse : class
{
    Task<IActionResult> GetById(int id);
    Task<IActionResult> GetAll();
    Task<IActionResult> Add(TRequest request);
    Task<IActionResult> Update(TRequest request);
    Task<IActionResult> Delete(int id);
}

