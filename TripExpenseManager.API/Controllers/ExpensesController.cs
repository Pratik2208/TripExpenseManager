using Microsoft.AspNetCore.Mvc;
using TripExpenseManager.Business.Dto.RequestDto;
using TripExpenseManager.Business.Dto.ResponseDto;
using TripExpenseManager.Business.Services;

namespace TripExpenseManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpensesController : ControllerBase
    {
        private readonly IExpenseService service;
        public ExpensesController(IExpenseService service)
        {
            this.service = service;
        }

        [HttpPost]
        public async Task<ActionResult> CreateExpense([FromBody] ExpenseAddDto addDto)
        {
            var result = await service.AddExpense(addDto);
            return result != null ? Ok(result) : StatusCode(StatusCodes.Status500InternalServerError, "Error while adding expense");
        }

        [HttpGet("expense/{expenseId}")]
        public async Task<ActionResult> GetExpense(string expenseId)
        {
            var result = await service.GetExpense(expenseId);
            return result != null ? Ok(result) : NotFound($"Expense with Id {expenseId} Not Found");
        }

        [HttpPut]
        public async Task<ActionResult> UpdateExpense([FromBody] ExpenseUpdateDto updateDto)
        {
            var result = await service.UpdateExpense(updateDto);
            return result != null ? Ok(result) : StatusCode(StatusCodes.Status500InternalServerError, "Error while updating expense");
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteExpense(string expenseId)
        {
            var result = await service.DeleteExpense(expenseId);
            return result ? Ok("Expense Deleted Successfully") : StatusCode(StatusCodes.Status500InternalServerError, "Error while deleting expense");
        }

        [HttpGet("{tripId}")]
        public async Task<ActionResult> GetExpenseByTripId(string tripId)
        {
            var result = await service.GetExpensesByTripId(tripId);
            return result.Any() ? Ok(result) : Ok(Enumerable.Empty<ExpenseResponseDto>());
        }
    }
}
