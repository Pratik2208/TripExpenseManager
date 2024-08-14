using System.ComponentModel.DataAnnotations;

namespace TripExpenseManager.Business.Dto.RequestDto
{
    public class ExpenseUpdateDto
    {
        [Required(ErrorMessage = "Trip required")]
        public string TripId { get; set; }
        [Required(ErrorMessage = "Expense required")]
        public string Id { get; set; }

        [MaxLength(100), Required]
        public string For { get; set; }

        [Range(0.1, double.MaxValue, ErrorMessage = "Please enter valid amount")]
        public double Amount { get; set; }

        [Required(ErrorMessage = "Please select category")]
        public string Category { get; set; }
        public DateTime SpentOn { get; set; }
    }
}
