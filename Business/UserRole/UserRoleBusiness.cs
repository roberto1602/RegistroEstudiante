using Data.UserRoleRepostitory;
using Entities;
using Entities.Model;
using Microsoft.AspNetCore.Http;
using System.Runtime.ExceptionServices;
using Utils;

namespace Business.UserRole
{
    public class UserRoleBusiness : UResult, IUserRoleBusiness
    {
        private readonly IUserRolData _userRolData;
        public UserRoleBusiness(IUserRolData userRolData)
        {
            _userRolData = userRolData;
        }
        public async Task<Result<UserRoleDto>> GetUserRoleById(int idUserRole)
        {
            var result = new Result<UserRoleDto>();

            try
            {
                var responseUserRole = await _userRolData.GetUserRoleById(idUserRole);

                if (responseUserRole.Values == null)
                    return Ok<UserRoleDto>(StatusCodes.Status404NotFound.ToString(), null);

                result.Values = MapToUserRole(responseUserRole.Values!);

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
        public async Task<Result<List<UserRoleDto>>> GetUserRoleAsync()
        {
            var result = new Result<List<UserRoleDto>>();

            try
            {
                var userRoles = await _userRolData.GetUserRoleAsync();

                if (userRoles.Values == null)
                    return Ok<List<UserRoleDto>>(StatusCodes.Status404NotFound.ToString(), null!);

                result.Values = MapToUserRoles(userRoles.Values!);

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

        public async Task<Result<UserRoleDto>> SaveUserRoleAsync(UserRoleDto userRoleDto)
        {
            var result = new Result<UserRoleDto>();

            try
            {
                var mapUserRole = MapToSaveUpdateUserRole(userRoleDto);

                var userRole = await _userRolData.SaveUserRoleAsync(mapUserRole);

                if (userRole.Values == null)
                    return Ok<UserRoleDto>(StatusCodes.Status400BadRequest.ToString(), null!);

                result.Values = MapToUserRole(userRole.Values!);

                result = Ok(StatusCodes.Status201Created.ToString(), result.Values);
            }
            catch (Exception ex)
            {
                result.Error = false;
                result.Message = ex.Message;
                ExceptionDispatchInfo.Capture(ex).Throw();
            }

            return result;
        }

        public async Task<Result<UserRoleDto>> UpdateUserRoleAsync(UserRoleDto userRoleDto)
        {
            var result = new Result<UserRoleDto>();

            try
            {
                var mapSubject = MapToSaveUpdateUserRole(userRoleDto);

                var userRole = await _userRolData.UpdateUserRoleAsync(mapSubject);

                if (userRole.Values == null)
                    return Ok<UserRoleDto>(StatusCodes.Status400BadRequest.ToString(), null!);

                result.Values = MapToUserRole(userRole.Values!);

                result = Ok(StatusCodes.Status201Created.ToString(), result.Values);
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
            var deleteuserRole = await _userRolData.DeleteUserRoleAsync(idUserRole);

            result.Values = deleteuserRole.Values;

            return result;
        }

        private static UserRoleDto MapToUserRole(UserRoleIdentity userRole)
        {
            return new UserRoleDto()
            {
               UserRoleId = userRole.UserRoleId,
               UserId = userRole.UserId,    
               RoleId = userRole.RoleId,
               IsActive = userRole.IsActive
            };
        }

        private static List<UserRoleDto> MapToUserRoles(List<UserRoleIdentity> userRoles)
        {
            return userRoles.Select(userRoles => new UserRoleDto
            {
                UserRoleId = userRoles.UserRoleId,
                UserId = userRoles.UserId,
                RoleId = userRoles.RoleId,
                IsActive = userRoles.IsActive
            }).ToList();
        }

        private static UserRoleIdentity MapToSaveUpdateUserRole(UserRoleDto userRoleDto)
        {
            return new UserRoleIdentity()
            {
                UserRoleId = userRoleDto.UserRoleId,
                UserId = userRoleDto.UserId,
                RoleId = userRoleDto.RoleId,
                IsActive = userRoleDto.IsActive
            };
        }

    }
}
