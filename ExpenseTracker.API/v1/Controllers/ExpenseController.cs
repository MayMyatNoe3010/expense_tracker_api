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
    [Route("api/v1/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase, IController<TransactionRequest, Transaction, TransactionResponse>
    {
        private readonly IServiceCollections _serviceCollections;
        private readonly IMapper _mapper;

        public TransactionController(IServiceCollections serviceCollections, IMapper mapper)
        {
            _serviceCollections = serviceCollections;
            _mapper = mapper;
        }
        //to check if the API is alive 
        [HttpGet("health")]
        public IActionResult Health() => Ok("API is alive");

        [HttpPost("Add")]
        public async Task<IActionResult> Add(TransactionRequest entity)
        {
            return await APIResponseHelper.HandleCreate<TransactionRequest, Transaction, TransactionResponse>(
                entity,
                req => _mapper.Map<Transaction>(req),
                _serviceCollections.TransactionServices.AddAsync,
                entity => _mapper.Map<TransactionResponse>(entity)
            );


        }
        [HttpPost("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            return await APIResponseHelper.HandleDelete<Transaction, TransactionResponse>(
                id,
                _serviceCollections.TransactionServices.DeleteAsync,
                entity => _mapper.Map<TransactionResponse>(entity)
            );
        }
        [HttpPost("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var data = await MockTransactionData.GetMockTransactionResponses();

            return Ok(new APIResponse<List<TransactionResponse>>
            {
                Status = true,
                Message = "Mock data loaded",
                Data = data
            });


            // return await APIResponseHelper.HandleGet<IEnumerable<Transaction>, List<TransactionResponse>>(
            // async () => await _serviceCollections.TransactionServices.GetAllAsync(),
            // list => list.Select(entity => _mapper.Map<TransactionResponse>(entity)).ToList()
            // );

        }
        [HttpPost("Get")]
        public async Task<IActionResult> GetById(int id)
        {
            return await APIResponseHelper.HandleGet<Transaction, TransactionResponse>(
            async () => await _serviceCollections.TransactionServices.GetAsync(
                new Expression<Func<Transaction, bool>>[] { e => e.Id == id }
            ),
            entity => _mapper.Map<TransactionResponse>(entity)
    );
        }
        [HttpPost("Update")]
        public async Task<IActionResult> Update(TransactionRequest entity)
        {
            return await APIResponseHelper.HandleUpdate<TransactionRequest, Transaction, TransactionResponse>(
                entity,
                async (req) =>
                {
                    var model = _mapper.Map<Transaction>(req);
                    return await _serviceCollections.TransactionServices.UpdateAsync(model);
                },
                updatedEntity => _mapper.Map<TransactionResponse>(updatedEntity)
            );
        }

    }
}
