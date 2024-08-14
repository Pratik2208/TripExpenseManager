using Microsoft.AspNetCore.Mvc;
using TripExpenseManager.Business.Dto.RequestDto;
using TripExpenseManager.Business.Dto.ResponseDto;
using TripExpenseManager.Business.Services;

namespace TripExpenseManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TripsController : ControllerBase
    {
        private readonly ITripService service;
        public TripsController(ITripService service)
        {
            this.service = service;
        }

        [HttpPost]
        public async Task<ActionResult> CreateTrip([FromBody] TripAddDto addDto)
        {
            var result = await service.AddTrip(addDto);
            return result != null ? Ok(result) : StatusCode(StatusCodes.Status500InternalServerError, "Error While Creating Trip");
        }

        [HttpGet("{tripId}")]
        public async Task<ActionResult> GetTrip(string tripId)
        {
            var result = await service.GetTripByTripId(tripId);
            return result != null ? Ok(result) : NotFound($"Trip with Id {tripId} Not Found");
        }

        [HttpPut]
        public async Task<ActionResult> UpdateTrip([FromBody] TripUpdateDto updateDto)
        {
            var result = await service.UpdateTrip(updateDto);
            return result != null ? Ok(result) : StatusCode(StatusCodes.Status500InternalServerError, "Error While Updating Trip");
        }

        [HttpDelete("{tripId}")]
        public async Task<ActionResult> DeleteUser(string tripId)
        {
            var result = await service.DeleteTrip(tripId);
            return result ? Ok("Trip Deleted Successfully") : StatusCode(StatusCodes.Status500InternalServerError, "Error While Deleting Trip");
        }

        [HttpGet("/trips/{userName}")]
        public async Task<ActionResult> GetTripsByUserId(string userName)
        {
            var result = await service.GetTripsByUserName(userName);
            return result.Any() ? Ok(result) : Ok(Enumerable.Empty<TripResponseDto>());
        }

    }
}
