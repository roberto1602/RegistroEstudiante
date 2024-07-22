using Business.UserRole;
using Entities.Model;
using Microsoft.AspNetCore.Mvc;
using Utils;

namespace RegistroEstudiante.Controllers
{
    [Route("api/user-rol")]
    [ApiController]
    public class UserRolController : ControllerBase
    {
        private readonly IUserRoleBusiness _userRoleBusiness;
        public UserRolController(IUserRoleBusiness userRoleBusiness)
        {
            _userRoleBusiness = userRoleBusiness;
        }

        [HttpGet("user-rol-id", Name = "UserRoleId")]
        [ProducesResponseType(typeof(Result<UserRoleDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Result<UserRoleDto>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(Result<UserRoleDto>), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetUserRoleById(int idUserRole)
        {
            try
            {
                var response = await _userRoleBusiness.GetUserRoleById(idUserRole);

                if (response.Error == true)
                {
                    if (response.Values != null)
                        return Ok(response.Values);
                }
                return NotFound(response);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpGet("user-rol-list", Name = "UserRoleList")]
        [ProducesResponseType(typeof(Result<UserRoleDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Result<UserRoleDto>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(Result<UserRoleDto>), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetUserRoles()
        {
            try
            {
                var response = await _userRoleBusiness.GetUserRoleAsync();

                if (response.Error == true)
                {
                    if (response.Values != null)
                        return Ok(response.Values);
                }
                return NotFound(response);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpPost("save-user-rol", Name = "UserRoleSave")]
        [ProducesResponseType(typeof(Result<UserRoleDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Result <UserRoleDto>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(Result<UserRoleDto>), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> SaveUserRoleAsync(UserRoleDto UserRoleDto)
        {
            try
            {
                var response = await _userRoleBusiness.SaveUserRoleAsync(UserRoleDto);

                if (response.Error == true)
                {
                    if (response.Values != null)
                        return Ok(response.Values);
                }
                return NotFound(response);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }


        [HttpPost("update-user-rol", Name = "UserRoleUpdate")]
        [ProducesResponseType(typeof(Result<UserRoleDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Result<UserRoleDto>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(Result<UserRoleDto>), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateUserRoleAsync(UserRoleDto UserRoleDto)
        {
            try
            {
                var response = await _userRoleBusiness.UpdateUserRoleAsync(UserRoleDto);

                if (response.Error == true)
                {
                    if (response.Values != null)
                        return Ok(response.Values);
                }
                return NotFound(response);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpDelete("delete-user-rol", Name = "DeleteUserRole")]
        [ProducesResponseType(typeof(Result<int>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Result<int>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(Result<int>), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteUserRoleAsync(int idUserRole)
        {
            try
            {
                var response = await _userRoleBusiness.DeleteUserRoleAsync(idUserRole);
                return Ok(response.Values);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        protected IActionResult InternalServerError(object obj)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, obj);
        }
    }
}
