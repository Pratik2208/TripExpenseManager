using TripExpenseManager.Business.Dto.ResponseDto;
using TripExpenseManager.Data.Data.Models;

namespace TripExpenseManager.Business.Extensions
{
    public static class EntityToResponseDtoExtension
    {
        public static UserResponseDto ToUserResponse(this User user)
        {
            return new UserResponseDto
            {
                Name = user.Name,
                UserName = user.UserName,
                Password = user.Password
            };
        }

        public static TripResponseDto ToTripResponse(this Trip trip)
        {
            return new TripResponseDto
            {
                Id = trip.Id.ToString(),
                Title = trip.Title,
                Location = trip.Location,
                CategoryImage = trip.CategoryImage,
                FromDate = trip.FromDate,
                ToDate = trip.ToDate,
                DisplayStatus = trip.DisplayStatus
            };
        }

        public static ExpenseResponseDto ToExpenseResponse(this Expense expense)
        {
            return new ExpenseResponseDto
            {
                Id = expense.Id,
                TripId = expense.TripId,
                For = expense.For,
                Category = expense.Category,
                Amount = expense.Amount,
                SpentOn = expense.SpentOn
            };
        }

        public static IEnumerable<ExpenseResponseDto> ToExpenseResponse(this IEnumerable<Expense> expenses)
        {
            return expenses.Select(expense => new ExpenseResponseDto
            {
                Id = expense.Id,
                TripId = expense.TripId,
                For = expense.For,
                Category = expense.Category,
                Amount = expense.Amount,
                SpentOn = expense.SpentOn
            }).AsEnumerable();
        }

        public static IEnumerable<TripResponseDto> ToTripResponse(this IEnumerable<Trip> trips)
        {
            return trips.Select(trip => new TripResponseDto
            {
                Id = trip.Id.ToString(),
                Title = trip.Title,
                Location = trip.Location,
                CategoryImage = trip.CategoryImage,
                FromDate = trip.FromDate,
                ToDate = trip.ToDate,
                DisplayStatus = trip.DisplayStatus
            }).AsEnumerable();
        }
    }
}
