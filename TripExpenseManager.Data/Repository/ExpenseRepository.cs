using Microsoft.EntityFrameworkCore;
using TripExpenseManager.Data.Data;
using TripExpenseManager.Data.Data.Models;
using TripExpenseManager.Shared;

namespace TripExpenseManager.Data.Repository
{
    public class ExpenseRepository : GenericRepository<Expense>
    {
        private readonly CosmosDbContext context;

        public ExpenseRepository(CosmosDbContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<MethodResult<IEnumerable<Expense>>> GetExpensesByTripId(string tripId)
        {
            try
            {
                var expenses = await context.Expenses.WithPartitionKey(tripId).ToListAsync();
                return MethodResult<IEnumerable<Expense>>.Success(expenses);
            }
            catch (Exception ex)
            {
                return MethodResult<IEnumerable<Expense>>.Fail(ex.Message);
            }
        }
    }
}
