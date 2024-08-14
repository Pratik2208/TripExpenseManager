using TripExpenseManager.Data.Repository;

namespace TripExpenseManager.Business.Services
{
    public interface IExpenseCategoryService
    {
        Task<List<string>> GetExpenseCategories();
    }

    public class ExpenseCategoryService : IExpenseCategoryService
    {
        private readonly ExpenseCategoryRepository repository;
        public ExpenseCategoryService(ExpenseCategoryRepository repository)
        {
            this.repository = repository;
        }

        public async Task<List<string>> GetExpenseCategories()
        {
            var result = await repository.GetAll();
            return result.Data!.Select(ec => ec.Name).ToList();
        }
    }
}
