using Microsoft.AspNetCore.Mvc;
using TripExpenseManager.Business.Dto.RequestDto;
using TripExpenseManager.Business.Services;

namespace TripExpenseManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService service;
        public UsersController(IUserService service)
        {
            this.service = service;
        }

        [HttpPost]
        public async Task<ActionResult> CreateUser([FromBody] UserAddDto addDto)
        {
            var result = await service.AddUser(addDto);
            return result != null ? Ok(result) : StatusCode(StatusCodes.Status500InternalServerError, "Error While Creating User");
        }

        [HttpGet("{userName}")]
        public async Task<ActionResult> GetUser(string userName)
        {
            var user = await service.GetUserByUserName(userName);
            return user != null ? Ok(user) : NotFound($"User with given User Name {userName} Not Found");
        }

        [HttpPut]
        public async Task<ActionResult> UpdateUser([FromBody] UserAddDto updateDto)
        {
            var result = await service.UpdateUser(updateDto);
            return result != null ? Ok(result) : StatusCode(StatusCodes.Status500InternalServerError, "Error While Updating User");
        }

        [HttpDelete("{userName}")]
        public async Task<ActionResult> DeleteUser(string userName)
        {
            var result = await service.DeleteUser(userName);
            return result ? Ok("User Deleted Successfully") : StatusCode(StatusCodes.Status500InternalServerError, "Error While Deleting User");
        }
    }
}
