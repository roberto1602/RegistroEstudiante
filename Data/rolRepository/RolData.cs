using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Runtime.ExceptionServices;
using Utils;

namespace Data.rolRepository
{
    public class RolData : UResult, IRolData
    {
        private readonly ContexMain _contexMain;
        public RolData(ContexMain contexMain)
        {
            _contexMain = contexMain;
        }

        public async Task<Result<Role>> GetRoleById(int idRole)
        {
            var result = new Result<Role>();

            try
            {
                var responseRole = await _contexMain.Roles.FirstOrDefaultAsync(r => r.RoleId == idRole);

                result.Values = responseRole;
            }
            catch (Exception ex)
            {
                result.Error = false;
                result.Message = ex.Message;
                ExceptionDispatchInfo.Capture(ex).Throw();
            }
            return result;
        }

        public async Task<Result<List<Role>>> GetRoleAsync()
        {
            var result = new Result<List<Role>>();

            List<Role>? roleList = [];

            roleList = await(from role in _contexMain.Roles
                                 select new Role
                                 {
                                    RoleId = role.RoleId,
                                    Name = role.Name
                                 }).ToListAsync();

            result.Values = roleList;

            return result;
        }

        public async Task<Result<Role>> SaveRoleAsync(Role rol)
        {
            var result = new Result<Role>();
            try
            {
                _contexMain.Roles.Add(rol);

                await _contexMain.SaveChangesAsync();

                result.Values = rol;
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
            }

            return result;
        }

        public async Task<Result<Role>> UpdateRoleAsync(Role rol)
        {
            var result = new Result<Role>();

            try
            {
                var existingRol = await _contexMain.Roles.FirstOrDefaultAsync(r => r.RoleId.Equals(rol.RoleId));

                if (existingRol == null)
                    return Error<Role>(StatusCodes.Status404NotFound.ToString(), null!);

                existingRol.RoleId = rol.RoleId;
                existingRol.Name = rol.Name;
                

                await _contexMain.SaveChangesAsync();

                result.Values = existingRol;

            }
            catch (Exception ex)
            {
                ExceptionDispatchInfo.Capture(ex).Throw();
            }

            return result;
        }

        public async Task<Result<int>> DeleteRoleAsync(int idRole)
        {
            var result = new Result<int>();

            try
            {
                var role = await _contexMain.UserRoles.FirstOrDefaultAsync(r => r.RoleId == idRole);

                if (role == null)
                    return Error(StatusCodes.Status404NotFound.ToString(), 0);

                _contexMain.UserRoles.Remove(role);
                await _contexMain.SaveChangesAsync();

                result = Ok(StatusCodes.Status200OK.ToString(), result.Values);
            }
            catch (Exception ex)
            {
                result.Error = false;
                result.Message = ex.Message;
                ExceptionDispatchInfo.Capture(ex).Throw();
            }

            return result;
        }
    }
}
