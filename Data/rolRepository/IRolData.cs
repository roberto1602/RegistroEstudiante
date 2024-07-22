using Entities;
using Utils;

namespace Data.rolRepository
{
    public interface IRolData
    {
        Task<Result<Role>> GetRoleById(int idRole);
        Task<Result<List<Role>>> GetRoleAsync();
        Task<Result<Role>> SaveRoleAsync(Role rol);
        Task<Result<Role>> UpdateRoleAsync(Role rol);
        Task<Result<int>> DeleteRoleAsync(int idRole);
    }
}
