using Entities;
using Entities.Model;
using Utils;

namespace Data.StudentRepository
{
    public interface IUserData
    {
        Task<Result<User>> GetUserById(string identification);
        Task<Result<List<User>>> GetUserAsync();
        Task<Result<User>> SaveUserAsync(User userDto);
        Task<Result<User>> UpdateUserAsync(User userDto);
        Task<Result<int>> DeleteUserAsync(int idUser);
    }
}
