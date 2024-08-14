using System.ComponentModel.DataAnnotations;
using TripExpenseManager.Data.Data.Models;

namespace TripExpenseManager.Business.Dto.RequestDto
{
    public class TripUpdateDto
    {
        [Required(ErrorMessage = "Trip required")]
        public string Id { get; set; }

        [MaxLength(30)]
        [Required]
        public string Title { get; set; }

        [MaxLength(50)]
        [Required]
        public string Location { get; set; }

        [MaxLength(30)]
        [Required]
        public string CategoryImage { get; set; }

        public DateTime? FromDate { get; set; }

        public DateTime? ToDate { get; set; }

        public string DisplayStatus { get; set; }
    }
}
