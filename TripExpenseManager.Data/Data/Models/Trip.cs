namespace TripExpenseManager.Data.Data.Models
{
    public class Trip : Document
    {
        public required string UserName { get; set; }
        public required string Title { get; set; }
        public required string Location { get; set; }
        public required string CategoryImage { get; set; }

        public DateTime? FromDate { get; set; }

        public DateTime? ToDate { get; set; }

        public DateTime AddedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public string DisplayStatus { get; set; }
    }
}

