using TripExpenseManager.Business.Dto.RequestDto;
using TripExpenseManager.Business.Dto.ResponseDto;
using TripExpenseManager.Business.Extensions;
using TripExpenseManager.Data.Repository;

namespace TripExpenseManager.Business.Services
{
    public interface ITripService
    {
        Task<TripResponseDto> AddTrip(TripAddDto addDto);
        Task<bool> DeleteTrip(string tripId);
        Task<TripResponseDto> GetTripByTripId(string tripId);
        Task<IEnumerable<TripResponseDto>> GetTripsByUserName(string userName);
        Task<TripResponseDto> UpdateTrip(TripUpdateDto updateDto);
    }

    public class TripService : ITripService
    {
        private readonly TripRepository repository;
        private readonly ExpenseRepository expenseRepository;
        public TripService(TripRepository repository, ExpenseRepository expenseRepository)
        {
            this.repository = repository;
            this.expenseRepository = expenseRepository;
        }

        public async Task<TripResponseDto> AddTrip(TripAddDto addDto)
        {
            var trip = addDto.ToTrip();
            trip.AddedOn = DateTime.UtcNow;
            trip.ModifiedOn = DateTime.UtcNow;
            var repoResult = await repository.AddEntity(trip);
            return repoResult.IsSuccess ? trip.ToTripResponse() : null!;
        }

        public async Task<TripResponseDto> GetTripByTripId(string tripId)
        {
            var repoResult = await repository.Get(tripId);
            return (repoResult.IsSuccess && repoResult.Data != null) ? repoResult.Data.ToTripResponse() : null!;
        }

        public async Task<TripResponseDto> UpdateTrip(TripUpdateDto updateDto)
        {
            var trip = updateDto.ToTrip();
            trip.ModifiedOn = DateTime.UtcNow;
            var repoResult = await repository.Update(trip);
            return repoResult.IsSuccess ? trip.ToTripResponse() : null!;
        }

        public async Task<bool> DeleteTrip(string tripId)
        {
            var expensesOfTripsResult = await expenseRepository.GetExpensesByTripId(tripId);
            if (expensesOfTripsResult.Data!.Any())
            {
                await expenseRepository.DeleteAll(expensesOfTripsResult.Data!);
            }
            var repoResult = await repository.Delete(tripId, "Trip");
            return repoResult.IsSuccess;
        }

        public async Task<IEnumerable<TripResponseDto>> GetTripsByUserName(string userName)
        {
            var repoResult = await repository.GetTripsByUserName(userName);
            return (repoResult.IsSuccess && !(repoResult.Data!.Any())) ? [] : repoResult.Data!.ToTripResponse();
        }
    }
}
