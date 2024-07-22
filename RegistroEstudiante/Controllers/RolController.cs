using Business.rol;
using Entities.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Utils;

namespace RegistroEstudiante.Controllers
{
    [Route("api/rol")]
    [ApiController]
    public class RolController : ControllerBase
    {
        private readonly IRolBusiness _rolBusiness;
        public RolController(IRolBusiness rolBusiness)
        {
            _rolBusiness = rolBusiness;
        }

        [HttpGet("rol-id", Name = "RoleId")]
        [ProducesResponseType(typeof(Result<RoleDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Result<RoleDto>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(Result<RoleDto>), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetRoleById(int idRole)
        {
            try
            {
                var response = await _rolBusiness.GetRoleById(idRole);

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

        [HttpGet("rol-list", Name = "RoleList")]
        [ProducesResponseType(typeof(Result<RoleDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Result<RoleDto>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(Result<RoleDto>), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetRoles()
        {
            try
            {
                var response = await _rolBusiness.GetRoleAsync();

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

        [HttpPost("save--rol", Name = "RoleSave")]
        [ProducesResponseType(typeof(Result<RoleDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Result<RoleDto>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(Result<RoleDto>), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> SaveRoleAsync(RoleDto RoleDto)
        {
            try
            {
                var response = await _rolBusiness.SaveRoleAsync(RoleDto);

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


        [HttpPost("update--rol", Name = "RoleUpdate")]
        [ProducesResponseType(typeof(Result<RoleDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Result<RoleDto>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(Result<RoleDto>), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateRoleAsync(RoleDto RoleDto)
        {
            try
            {
                var response = await _rolBusiness.UpdateRoleAsync(RoleDto);

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

        [HttpDelete("delete--rol", Name = "DeleteRole")]
        [ProducesResponseType(typeof(Result<int>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Result<int>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(Result<int>), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteRoleAsync(int idRole)
        {
            try
            {
                var response = await _rolBusiness.DeleteRoleAsync(idRole);
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
