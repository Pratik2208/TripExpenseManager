namespace TripExpenseManager.Business.Dto.ResponseDto
{
    public class ExpenseResponseDto
    {
        public required string Id { get; set; }
        public required string TripId { get; set; }
        public required string For { get; set; }
        public double Amount { get; set; }
        public required string Category { get; set; }
        public DateTime SpentOn { get; set; }
    }
}
