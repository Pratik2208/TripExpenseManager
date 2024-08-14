namespace TripExpenseManager.Data.Data.Models
{
    public class Expense : Document
    {
        public required string TripId { get; set; }
        public required string For { get; set; }
        public double Amount { get; set; }
        public required string Category { get; set; }
        public DateTime SpentOn { get; set; }
    }
}
