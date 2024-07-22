using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Runtime.ExceptionServices;
using Utils;

namespace Data.UserRoleRepostitory
{
    public class UserRolData : UResult, IUserRolData
    {
        private readonly ContexMain _contexMain;

        public UserRolData(ContexMain contexMain)
        {
            _contexMain = contexMain;
        }
        public async Task<Result<UserRoleIdentity>> GetUserRoleById(int idUserRole)
        {
            var result = new Result<UserRoleIdentity>();

            try
            {
                var responseUserRole = await _contexMain.UserRoles.FirstOrDefaultAsync(userRole => userRole.UserRoleId == idUserRole);

                result.Values = responseUserRole;
            }
            catch (Exception ex)
            {
                result.Error = false;
                result.Message = ex.Message;
                ExceptionDispatchInfo.Capture(ex).Throw();
            }
            return result;
        }

        public async Task<Result<List<UserRoleIdentity>>> GetUserRoleAsync()
        {
            var result = new Result<List<UserRoleIdentity>>();

            List<UserRoleIdentity>? userRoleList = [];

            userRoleList = await (from userRole in _contexMain.UserRoles
                                 select new UserRoleIdentity
                                 {
                                     UserRoleId = userRole.UserRoleId,
                                     UserId = userRole.UserId,
                                     RoleId = userRole.RoleId,
                                     IsActive = userRole.IsActive
                                 }).ToListAsync();

            result.Values = userRoleList;

            return result;
        }

        public async Task<Result<UserRoleIdentity>> SaveUserRoleAsync(UserRoleIdentity userRole)
        {
            var result = new Result<UserRoleIdentity>();
            try
            {
                _contexMain.UserRoles.Add(userRole);

                await _contexMain.SaveChangesAsync();

                result.Values = userRole;
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
            }

            return result;
        }

        public async Task<Result<UserRoleIdentity>> UpdateUserRoleAsync(UserRoleIdentity userRole)
        {
            var result = new Result<UserRoleIdentity>();

            try
            {
                var existingUserRole = await _contexMain.UserRoles.FirstOrDefaultAsync(ur => ur.UserRoleId.Equals(userRole.UserRoleId));
               
                if (existingUserRole == null)
                    return Error<UserRoleIdentity>(StatusCodes.Status404NotFound.ToString(), null!);

                
                _contexMain.UserRoles.Remove(existingUserRole);
                await _contexMain.SaveChangesAsync();

                // Crear una nueva entidad con los valores actualizados
                var newUserRole = new UserRoleIdentity
                {
                    UserId = userRole.UserId,
                    RoleId = userRole.RoleId,
                    IsActive = userRole.IsActive
                };

                // Agregar la nueva entidad al contexto
                _contexMain.UserRoles.Add(newUserRole);
                await _contexMain.SaveChangesAsync();

                result = Ok(StatusCodes.Status200OK.ToString(), newUserRole);
            }
            catch (Exception ex)
            {
                result.Error = false;
                result.Message = ex.Message;
                ExceptionDispatchInfo.Capture(ex).Throw();
            }

            return result;
        }

        public async Task<Result<int>> DeleteUserRoleAsync(int idUserRole)
        {
            var result = new Result<int>();

            try
            {
                var userRole = await _contexMain.UserRoles.FirstOrDefaultAsync(ur => ur.UserId == idUserRole);

                if (userRole == null)
                    return Error(StatusCodes.Status404NotFound.ToString(), 0);

                _contexMain.UserRoles.Remove(userRole);
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
