using TripExpenseManager.Data.Data;
using TripExpenseManager.Data.Data.Models;

namespace TripExpenseManager.Data.Repository
{
    public class ExpenseCategoryRepository : GenericRepository<ExpenseCategory>
    {
        public ExpenseCategoryRepository(CosmosDbContext context) : base(context)
        {

        }
    }
}
