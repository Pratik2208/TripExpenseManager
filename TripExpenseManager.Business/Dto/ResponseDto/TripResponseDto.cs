using TripExpenseManager.Data.Data.Models;

namespace TripExpenseManager.Business.Dto.ResponseDto
{
    public class TripResponseDto
    {
        public required string Id { get; set; }
        public required string Title { get; set; }
        public required string Location { get; set; }
        public required string CategoryImage { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public required string DisplayStatus { get; set; }
    }
}
