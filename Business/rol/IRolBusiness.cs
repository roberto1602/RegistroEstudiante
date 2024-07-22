using Entities.Model;
using Utils;

namespace Business.rol
{
    public interface IRolBusiness
    {
        Task<Result<RoleDto>> GetRoleById(int idRole);
        Task<Result<List<RoleDto>>> GetRoleAsync();
        Task<Result<RoleDto>> SaveRoleAsync(RoleDto RoleDto);
        Task<Result<RoleDto>> UpdateRoleAsync(RoleDto RoleDto);
        Task<Result<int>> DeleteRoleAsync(int idRole);
    }
}
