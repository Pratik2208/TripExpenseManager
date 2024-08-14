using System.ComponentModel.DataAnnotations;

namespace TripExpenseManager.Business.Dto.RequestDto
{
    public class UserAddDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
