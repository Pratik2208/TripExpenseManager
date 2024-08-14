using Microsoft.EntityFrameworkCore;
using TripExpenseManager.Data.Data;
using TripExpenseManager.Data.Data.Models;
using TripExpenseManager.Shared;

namespace TripExpenseManager.Data.Repository
{
    public class TripRepository : GenericRepository<Trip>
    {
        private readonly CosmosDbContext dbContext;
        public TripRepository(CosmosDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<MethodResult<IEnumerable<Trip>>> GetTripsByUserName(string userName)
        {
            try
            {
                var trips = await dbContext.Trips.WithPartitionKey(userName).ToListAsync();
                return MethodResult<IEnumerable<Trip>>.Success(trips);
            }
            catch (Exception ex)
            {
                return MethodResult<IEnumerable<Trip>>.Fail(ex.Message);
            }
        }
    }
}
