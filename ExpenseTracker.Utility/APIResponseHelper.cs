using System;
using ExpenseTracker.Models.Base;
using Microsoft.AspNetCore.Mvc;
namespace ExpenseTracker.Utility;

public static class APIResponseHelper
{
    public static async Task<IActionResult> HandleCreate<TRequest, TEntity, TResponse>(
        TRequest request,
        Func<TRequest, TEntity> mapToEntity,
        Func<TEntity, Task<TEntity>> saveAsync,
        Func<TEntity, TResponse> mapToResponse
    ) where TResponse : class
    {
        try
        {
            if (request == null)
            {
                return new BadRequestObjectResult(new APIResponse<TResponse>
                {
                    Status = false,
                    Message = "Request is null.",
                    Data = default
                });
            }

            var entity = mapToEntity(request);               // Not async
            var result = await saveAsync(entity);            // Async save
            var response = mapToResponse(result);            // Map to response

            return new OkObjectResult(new APIResponse<TResponse>
            {
                Status = true,
                Message = "Created successfully.",
                Data = response
            });
        }
        catch (Exception e)
        {
            return new ObjectResult(new APIResponse<TResponse>
            {
                Status = false,
                Message = $"An error occurred: {e.Message}",
                Data = default
            })
            { StatusCode = 500 };
        }
    }

    public static async Task<IActionResult> HandleUpdate<TRequest, TEntity, TResponse>(
    TRequest request,
    Func<TRequest, Task<TEntity?>> updateAsync,
    Func<TEntity, TResponse> mapToResponse
) where TResponse : class
    {
        try
        {
            if (request == null)
            {
                return new BadRequestObjectResult(new APIResponse<TResponse>
                {
                    Status = false,
                    Message = "Request is null.",
                    Data = default
                });
            }

            var updatedEntity = await updateAsync(request);

            if (updatedEntity == null)
            {
                return new NotFoundObjectResult(new APIResponse<TResponse>
                {
                    Status = false,
                    Message = "Entity not found.",
                    Data = default
                });
            }

            var response = mapToResponse(updatedEntity);

            return new OkObjectResult(new APIResponse<TResponse>
            {
                Status = true,
                Message = "Updated successfully.",
                Data = response
            });
        }
        catch (Exception ex)
        {
            return new ObjectResult(new APIResponse<TResponse>
            {
                Status = false,
                Message = $"An error occurred: {ex.Message}",
                Data = default
            })
            { StatusCode = 500 };
        }
    }

    public static async Task<IActionResult> HandleDelete<TEntity, TResponse>(
        int id,
        Func<int, Task<TEntity?>> deleteAsync,
        Func<TEntity, TResponse> mapToResponse
    ) where TResponse : class
    {
        try
        {
            var deletedEntity = await deleteAsync(id);

            if (deletedEntity == null)
            {
                return new NotFoundObjectResult(new APIResponse<TResponse>
                {
                    Status = false,
                    Message = "Entity not found.",
                    Data = default
                });
            }

            var response = mapToResponse(deletedEntity);

            return new OkObjectResult(new APIResponse<TResponse>
            {
                Status = true,
                Message = "Deleted successfully.",
                Data = response
            });
        }
        catch (Exception ex)
        {
            return new ObjectResult(new APIResponse<TResponse>
            {
                Status = false,
                Message = $"An error occurred: {ex.Message}",
                Data = default
            })
            { StatusCode = 500 };
        }
    }

    public static async Task<IActionResult> HandleGet<TEntity, TResponse>(
        Func<Task<TEntity?>> getAsync,
        Func<TEntity, TResponse> mapToResponse
    ) where TResponse : class
    {
        try
        {
            var entity = await getAsync();

            if (entity == null)
            {
                return new NotFoundObjectResult(new APIResponse<TResponse>
                {
                    Status = false,
                    Message = "Entity not found.",
                    Data = default
                });
            }

            var response = mapToResponse(entity);

            return new OkObjectResult(new APIResponse<TResponse>
            {
                Status = true,
                Message = "Fetched successfully.",
                Data = response
            });
        }
        catch (Exception ex)
        {
            return new ObjectResult(new APIResponse<TResponse>
            {
                Status = false,
                Message = $"An error occurred: {ex.Message}",
                Data = default
            })
            { StatusCode = 500 };
        }
    }


}

