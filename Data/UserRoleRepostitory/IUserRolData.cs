using Entities;
using Entities.Model;
using Utils;

namespace Data.UserRoleRepostitory
{
    public interface IUserRolData
    {
        Task<Result<UserRoleIdentity>> GetUserRoleById(int idUserRole);
        Task<Result<List<UserRoleIdentity>>> GetUserRoleAsync();
        Task<Result<UserRoleIdentity>> SaveUserRoleAsync(UserRoleIdentity userRoleDto);
        Task<Result<UserRoleIdentity>> UpdateUserRoleAsync(UserRoleIdentity userRoleDto);
        Task<Result<int>> DeleteUserRoleAsync(int idUserRole);
    }
}
