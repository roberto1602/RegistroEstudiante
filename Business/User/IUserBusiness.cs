using Entities.Model;
using Utils;

namespace Business.Students
{
    public interface IUserBusiness
    {
        Task<Result<UserDto>> GetUserById(string identification);
        Task<Result<List<UserDto>>> GetUserAsync();
        Task<Result<UserDto>> SaveUserAsync(UserDto userDto);
        Task<Result<UserDto>> UpdateUserAsync(UserDto userDto);
        Task<Result<int>> DeleteUserAsync(int idUser);
    }
}