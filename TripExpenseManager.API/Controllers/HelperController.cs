using Microsoft.AspNetCore.Mvc;
using TripExpenseManager.Business.Services;

namespace TripExpenseManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HelperController : ControllerBase
    {
        private readonly ILocationCategoryService locationCategoryService;
        private readonly IExpenseCategoryService expenseCategoryService;
        public HelperController(ILocationCategoryService locationCategoryService, IExpenseCategoryService expenseCategoryService)
        {
            this.locationCategoryService = locationCategoryService;
            this.expenseCategoryService = expenseCategoryService;
        }

        [HttpGet("/locations")]
        public async Task<ActionResult> GetLocationCategories()
        {
            var categories = await locationCategoryService.GetAllLocationCategory();
            return Ok(categories);
        }

        [HttpGet("/expenses")]
        public async Task<ActionResult> GetExpenseCategories()
        {
            var categories = await expenseCategoryService.GetExpenseCategories();
            return Ok(categories);
        }
    }
}
