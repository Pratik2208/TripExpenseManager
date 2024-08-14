using TripExpenseManager.Data.Data;
using TripExpenseManager.Data.Data.Models;

namespace TripExpenseManager.Data.Repository
{
    public class UserRepository : GenericRepository<User>
    {
        public UserRepository(CosmosDbContext context) : base(context)
        {
        }
    }
}
