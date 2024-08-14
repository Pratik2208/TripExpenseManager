using TripExpenseManager.Business.Dto.RequestDto;
using TripExpenseManager.Data.Data.Models;

namespace TripExpenseManager.Business
{
    public static class RequestDtoToEntityExtension
    {
        public static User ToUser(this UserAddDto userAddDto)
        {
            return new User
            {
                Name = userAddDto.Name,
                UserName = userAddDto.UserName,
                Password = userAddDto.Password
            };
        }

        public static Trip ToTrip(this TripAddDto tripAddDto)
        {
            return new Trip
            {
                UserName = "Pratik2208",
                Title = tripAddDto.Title,
                Location = tripAddDto.Location,
                CategoryImage = tripAddDto.CategoryImage,
                FromDate = tripAddDto.FromDate,
                ToDate = tripAddDto.ToDate,
                DisplayStatus = tripAddDto.DisplayStatus,
            };
        }

        public static Trip ToTrip(this TripUpdateDto updateDto)
        {
            return new Trip
            {
                Id = updateDto.Id.ToString(),
                UserName = "Pratik2208",
                Title = updateDto.Title,
                Location = updateDto.Location,
                CategoryImage = updateDto.CategoryImage,
                FromDate = updateDto.FromDate,
                ToDate = updateDto.ToDate,
                DisplayStatus = updateDto.DisplayStatus,
            };
        }

        public static Expense ToExpense(this ExpenseAddDto addDto)
        {
            return new Expense
            {
                TripId = addDto.TripId,
                For = addDto.For,
                Category = addDto.Category,
                Amount = addDto.Amount,
                SpentOn = addDto.SpentOn
            };
        }

        public static Expense ToExpense(this ExpenseUpdateDto updateDto)
        {
            return new Expense
            {
                Id = updateDto.Id,
                TripId = updateDto.TripId,
                For = updateDto.For,
                Category = updateDto.Category,
                Amount = updateDto.Amount,
                SpentOn = updateDto.SpentOn
            };
        }
    }
}
