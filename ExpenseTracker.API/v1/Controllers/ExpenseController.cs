using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper;
using ExpenseTracker.DataAccess.MockData;
using ExpenseTracker.Models;
using ExpenseTracker.Models.Base;
using ExpenseTracker.Models.Dtos.Request;
using ExpenseTracker.Models.Dtos.Response;
using ExpenseTracker.Services.IServices;
using ExpenseTracker.Utility;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseTracker.API.v1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpenseController : ControllerBase, IController<ExpenseRequest, Expense, ExpenseResponse>
    {
        private readonly IServiceCollections _serviceCollections;
        private readonly IMapper _mapper;

        public ExpenseController(IServiceCollections serviceCollections, IMapper mapper)
        {
            _serviceCollections = serviceCollections;
            _mapper = mapper;
        }
        //to check if the API is alive 
        [HttpGet("/health")]
        public IActionResult Health() => Ok("API is alive");

        [HttpPost("Add")]
        public async Task<IActionResult> Add(ExpenseRequest entity)
        {
            return await APIResponseHelper.HandleCreate<ExpenseRequest, Expense, ExpenseResponse>(
                entity,
                req => _mapper.Map<Expense>(req),
                _serviceCollections.ExpenseServices.AddAsync,
                entity => _mapper.Map<ExpenseResponse>(entity)
            );


        }
        [HttpPost("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            return await APIResponseHelper.HandleDelete<Expense, ExpenseResponse>(
                id,
                _serviceCollections.ExpenseServices.DeleteAsync,
                entity => _mapper.Map<ExpenseResponse>(entity)
            );
        }
        [HttpPost("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var data = await MockExpenseData.GetMockExpenseResponses();

            return Ok(new APIResponse<List<ExpenseResponse>>
            {
                Status = true,
                Message = "Mock data loaded",
                Data = data
            });


            // return await APIResponseHelper.HandleGet<IEnumerable<Expense>, List<ExpenseResponse>>(
            // async () => await _serviceCollections.ExpenseServices.GetAllAsync(),
            // list => list.Select(entity => _mapper.Map<ExpenseResponse>(entity)).ToList()
            // );

        }
        [HttpPost("Get")]
        public async Task<IActionResult> GetById(int id)
        {
            return await APIResponseHelper.HandleGet<Expense, ExpenseResponse>(
            async () => await _serviceCollections.ExpenseServices.GetAsync(
                new Expression<Func<Expense, bool>>[] { e => e.Id == id }
            ),
            entity => _mapper.Map<ExpenseResponse>(entity)
    );
        }
        [HttpPost("Update")]
        public async Task<IActionResult> Update(ExpenseRequest entity)
        {
            return await APIResponseHelper.HandleUpdate<ExpenseRequest, Expense, ExpenseResponse>(
                entity,
                async (req) =>
                {
                    var model = _mapper.Map<Expense>(req);
                    return await _serviceCollections.ExpenseServices.UpdateAsync(model);
                },
                updatedEntity => _mapper.Map<ExpenseResponse>(updatedEntity)
            );
        }

    }
}
