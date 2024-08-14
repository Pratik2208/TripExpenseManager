using TripExpenseManager.Business.Dto.RequestDto;
using TripExpenseManager.Business.Dto.ResponseDto;
using TripExpenseManager.Business.Extensions;
using TripExpenseManager.Data.Repository;

namespace TripExpenseManager.Business.Services
{
    public interface IExpenseService
    {
        Task<ExpenseResponseDto> AddExpense(ExpenseAddDto addDto);
        Task<bool> DeleteExpense(string id);
        Task<ExpenseResponseDto> GetExpense(string id);
        Task<IEnumerable<ExpenseResponseDto>> GetExpensesByTripId(string tripId);
        Task<ExpenseResponseDto> UpdateExpense(ExpenseUpdateDto updateDto);
    }

    public class ExpenseService : IExpenseService
    {
        private readonly ExpenseRepository repository;
        public ExpenseService(ExpenseRepository repository)
        {
            this.repository = repository;
        }

        public async Task<ExpenseResponseDto> AddExpense(ExpenseAddDto addDto)
        {
            var expense = addDto.ToExpense();
            var repoResult = await repository.AddEntity(expense);
            return repoResult.IsSuccess ? expense.ToExpenseResponse() : null!;
        }

        public async Task<ExpenseResponseDto> GetExpense(string id)
        {
            var repoResult = await repository.Get(id);
            return (repoResult.IsSuccess && repoResult.Data != null) ? repoResult.Data.ToExpenseResponse() : null!;
        }

        public async Task<ExpenseResponseDto> UpdateExpense(ExpenseUpdateDto updateDto)
        {
            var expense = updateDto.ToExpense();
            var repoResult = await repository.Update(expense);
            return repoResult.IsSuccess ? expense.ToExpenseResponse() : null!;
        }

        public async Task<bool> DeleteExpense(string id)
        {
            var repoResult = await repository.Delete(id, "Expense");
            return repoResult.IsSuccess;
        }

        public async Task<IEnumerable<ExpenseResponseDto>> GetExpensesByTripId(string tripId)
        {
            var repoResult = await repository.GetExpensesByTripId(tripId);
            return (repoResult.IsSuccess && !(repoResult.Data!.Any())) ? [] : repoResult.Data!.ToExpenseResponse();
        }
    }
}
