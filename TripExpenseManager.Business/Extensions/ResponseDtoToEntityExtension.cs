using TripExpenseManager.Business.Dto.ResponseDto;
using TripExpenseManager.Data.Data.Models;

namespace TripExpenseManager.Business.Extensions
{
    public static class ResponseDtoToEntityExtension
    {
        public static User ToUser(this UserResponseDto responseDto)
        {
            return new User
            {
                Name = responseDto.Name,
                UserName = responseDto.UserName,
                Password = responseDto.Password
            };
        }

        public static Trip ToTrip(this TripResponseDto responseDto)
        {
            return new Trip
            {
                Id = responseDto.Id,
                UserName = "Pratik2208",
                Title = responseDto.Title,
                Location = responseDto.Location,
                CategoryImage = responseDto.CategoryImage,
                FromDate = responseDto.FromDate,
                ToDate = responseDto.ToDate,
                DisplayStatus = responseDto.DisplayStatus
            };
        }

        public static Expense ToExpense(this ExpenseResponseDto responseDto)
        {
            return new Expense
            {
                Id = responseDto.Id,
                TripId = responseDto.TripId,
                For = responseDto.For,
                Category = responseDto.Category,
                Amount = responseDto.Amount,
                SpentOn = responseDto.SpentOn
            };
        }
    }
}
