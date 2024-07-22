using Entities.Model;
using Utils;

namespace Business.UserRole
{
    public interface IUserRoleBusiness
    {
        Task<Result<UserRoleDto>> GetUserRoleById(int idUserRole);
        Task<Result<List<UserRoleDto>>> GetUserRoleAsync();
        Task<Result<UserRoleDto>> SaveUserRoleAsync(UserRoleDto userRoleDto);
        Task<Result<UserRoleDto>> UpdateUserRoleAsync(UserRoleDto userRoleDto);
        Task<Result<int>> DeleteUserRoleAsync(int idUserRole);
    }
}
