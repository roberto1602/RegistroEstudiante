using Business.Students;
using Entities.Model;
using Microsoft.AspNetCore.Mvc;
using Utils;

namespace RegistroEstudiante.Controllers
{
    [Route("api/User")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserBusiness _userBusiness;
        public UserController(IUserBusiness userBusiness)
        {
            _userBusiness = userBusiness;
        }

        [HttpGet("user-id", Name = "UserId")]
        [ProducesResponseType(typeof(Result<UserDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Result<UserDto>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(Result<UserDto>), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetUserById(string identification)
        {
            try
            {
                var response = await _userBusiness.GetUserById(identification);

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

        [HttpGet("user-list", Name = "UserList")]
        [ProducesResponseType(typeof(Result<UserDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Result<UserDto>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(Result<UserDto>), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetUsers()
        {
            try
            {
                var response = await _userBusiness.GetUserAsync();

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

        [HttpPost("save-user", Name = "UserSave")]
        [ProducesResponseType(typeof(Result<UserDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Result<UserDto>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(Result<UserDto>), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> SaveUserAsync(UserDto userDto)
        {
            try
            {
                var response = await _userBusiness.SaveUserAsync(userDto);

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

        [HttpPost("update-user", Name = "UserUpdate")]
        [ProducesResponseType(typeof(Result<UserDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Result<UserDto>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(Result<UserDto>), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateUserAsync(UserDto userDto)
        {
            try
            {
                var response = await _userBusiness.UpdateUserAsync(userDto);

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

        [HttpDelete("delete-user", Name = "DeleteUser")]
        [ProducesResponseType(typeof(Result<int>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Result<int>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(Result<int>), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteUserAsync(int idUser)
        {
            try
            {
                var response = await _userBusiness.DeleteUserAsync(idUser);
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
