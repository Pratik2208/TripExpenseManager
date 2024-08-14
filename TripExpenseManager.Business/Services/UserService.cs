using TripExpenseManager.Business.Dto.RequestDto;
using TripExpenseManager.Business.Dto.ResponseDto;
using TripExpenseManager.Business.Extensions;
using TripExpenseManager.Data.Repository;

namespace TripExpenseManager.Business.Services
{
    public interface IUserService
    {
        Task<UserResponseDto> AddUser(UserAddDto addDto);
        Task<bool> DeleteUser(string userName);
        Task<UserResponseDto> GetUserByUserName(string userName);
        Task<UserResponseDto> UpdateUser(UserAddDto updateDto);
    }

    public class UserService : IUserService
    {
        private readonly UserRepository repository;
        public UserService(UserRepository repository)
        {
            this.repository = repository;
        }

        public async Task<UserResponseDto> AddUser(UserAddDto addDto)
        {
            if (await GetUserByUserName(addDto.UserName) != null)
            {
                throw new InvalidOperationException("User Already Exist");
            }
            var user = addDto.ToUser();
            var repoResult = await repository.AddEntity(user);
            return repoResult.IsSuccess ? user.ToUserResponse() : null!;
        }

        public async Task<UserResponseDto> GetUserByUserName(string userName)
        {
            var repoResult = await repository.Get(userName);
            return (repoResult.IsSuccess && repoResult.Data != null) ? repoResult.Data!.ToUserResponse() : null!;
        }

        public async Task<UserResponseDto> UpdateUser(UserAddDto updateDto)
        {
            var user = updateDto.ToUser();
            var repoResult = await repository.Update(user);
            return repoResult.IsSuccess ? user.ToUserResponse() : null!;
        }

        public async Task<bool> DeleteUser(string userName)
        {
            var repoResult = await repository.Delete(userName, "User");
            return repoResult.IsSuccess;
        }
    }
}
