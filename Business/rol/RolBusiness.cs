using Data.rolRepository;
using Entities;
using Entities.Model;
using Microsoft.AspNetCore.Http;
using System.Data;
using System.Runtime.ExceptionServices;
using Utils;

namespace Business.rol
{
    public class RolBusiness : UResult, IRolBusiness
    {
        private readonly IRolData _rolData;
        public RolBusiness(IRolData rolData)
        {
            _rolData = rolData;
        }


        public async Task<Result<RoleDto>> GetRoleById(int idRole)
        {
            var result = new Result<RoleDto>();

            try
            {
                var responseRole = await _rolData.GetRoleById(idRole);

                if (responseRole.Values == null)
                    return Ok<RoleDto>(StatusCodes.Status404NotFound.ToString(), null);

                result.Values = MapToUserRole(responseRole.Values!);

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
        public async Task<Result<List<RoleDto>>> GetRoleAsync()
        {
            var result = new Result<List<RoleDto>>();

            try
            {
                var roles = await _rolData.GetRoleAsync();

                if (roles.Values == null)
                    return Ok<List<RoleDto>>(StatusCodes.Status404NotFound.ToString(), null!);

                result.Values = MapToRoles(roles.Values!);

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

        public async Task<Result<RoleDto>> SaveRoleAsync(RoleDto RoleDto)
        {
            var result = new Result<RoleDto>();

            try
            {
                var mapUserRole = MapToSaveUpdateRole(RoleDto);

                var rol = await _rolData.SaveRoleAsync(mapUserRole);

                if (rol.Values == null)
                    return Ok<RoleDto>(StatusCodes.Status400BadRequest.ToString(), null!);

                result.Values = MapToUserRole(rol.Values!);

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

        public async Task<Result<RoleDto>> UpdateRoleAsync(RoleDto RoleDto)
        {
            var result = new Result<RoleDto>();

            try
            {
                var mapRole = MapToSaveUpdateRole(RoleDto);

                var rol = await _rolData.UpdateRoleAsync(mapRole);

                if (rol.Values == null)
                    return Ok<RoleDto>(StatusCodes.Status400BadRequest.ToString(), null!);

                result.Values = MapToUserRole(rol.Values!);

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
        public async Task<Result<int>> DeleteRoleAsync(int idRole)
        {
            var result = new Result<int>();
            var deleteRol = await _rolData.DeleteRoleAsync(idRole);

            result.Values = deleteRol.Values;

            return result;
        }

        private static RoleDto MapToUserRole(Role role)
        {
            return new RoleDto()
            {
                RoleId = role.RoleId,
                Name = role.Name
            };
        }

        private static List<RoleDto> MapToRoles(List<Role> roles)
        {
            return roles.Select(roles => new RoleDto
            {
                RoleId = roles.RoleId,
                Name = roles.Name
            }).ToList();
        }

        private static Role MapToSaveUpdateRole(RoleDto RoleDto)
        {
            return new Role()
            {
                RoleId = RoleDto.RoleId,
                Name = RoleDto.Name
            };
        }
    }
}
