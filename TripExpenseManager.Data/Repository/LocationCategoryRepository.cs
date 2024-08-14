using TripExpenseManager.Data.Data;
using TripExpenseManager.Data.Data.Models;

namespace TripExpenseManager.Data.Repository
{
    public class LocationCategoryRepository : GenericRepository<LocationCategory>
    {
        public LocationCategoryRepository(CosmosDbContext context) : base(context)
        {

        }
    }
}
