using TripExpenseManager.Data.Data.Models;
using TripExpenseManager.Data.Repository;

namespace TripExpenseManager.Business.Services
{
    public interface ILocationCategoryService
    {
        Task<List<LocationCategory>> GetAllLocationCategory();
    }

    public class LocationCategoryService : ILocationCategoryService
    {
        private readonly LocationCategoryRepository repository;
        public LocationCategoryService(LocationCategoryRepository repository)
        {
            this.repository = repository;
        }

        public async Task<List<LocationCategory>> GetAllLocationCategory()
        {
            var result = await repository.GetAll();
            return result.Data!;
        }
    }
}
