using Data.StudentRepository;
using Entities;
using Entities.Model;
using Microsoft.AspNetCore.Http;
using System.Runtime.ExceptionServices;
using Utils;

namespace Business.Students
{
    public class UserBusiness : UResult, IUserBusiness
    {
        private readonly IUserData _userData;
        public UserBusiness(IUserData userData)
        {
            _userData = userData;
        }
        public async Task<Result<UserDto>> GetUserById(string identification)
        {
            var result = new Result<UserDto>();

            try
            {
                if (!ValidateUser(identification))
                    return Error<UserDto>("user not specified", null);

                var responseUser = await _userData.GetUserById(identification);
                
                if (responseUser.Values  == null)
                    return Ok<UserDto>(StatusCodes.Status404NotFound.ToString(), null);

                result.Values = MapToUser(responseUser.Values!);

                result = Ok(StatusCodes.Status200OK.ToString(), result.Values);

            }
            catch (Exception ex)
            {
                ExceptionDispatchInfo.Capture(ex).Throw();
            }

            return result;
        }

        

        public async Task<Result<List<UserDto>>> GetUserAsync()
        {
            var result = new Result<List<UserDto>>();

            try
            {
                var users = await _userData.GetUserAsync();

                if (users.Values == null)
                    return Ok<List<UserDto>>(StatusCodes.Status404NotFound.ToString(), null!);

                result.Values = MapToUsers(users.Values!);

                result = Ok(StatusCodes.Status200OK.ToString(), result.Values);

            }
            catch (Exception ex)
            {
                ExceptionDispatchInfo.Capture(ex).Throw();
            }

            return result;
        }

        public async Task<Result<UserDto>> SaveUserAsync(UserDto userDto)
        {
            var result = new Result<UserDto>();

            try
            {
                var mapUser =  MapToSaveUpdateUser(userDto);

                var user = await _userData.SaveUserAsync(mapUser);

                if (user.Values == null)
                    return Ok<UserDto>(StatusCodes.Status400BadRequest.ToString(), null!);

                result.Values = MapToUser(user.Values!);

                result = Ok(StatusCodes.Status201Created.ToString(), result.Values);
            }
            catch (Exception ex)
            {
                ExceptionDispatchInfo.Capture(ex).Throw();
            }

            return result;
        }

        public async Task<Result<UserDto>> UpdateUserAsync(UserDto userDto)
        {
            var result = new Result<UserDto>();

            try
            {
                var mapUser = MapToSaveUpdateUser(userDto);

                Result<User> user = await _userData.UpdateUserAsync(mapUser);

                if (user.Values == null)
                    return Ok<UserDto>(StatusCodes.Status404NotFound.ToString(), null!);

                result.Values = MapToUser(user.Values!);

                result = Ok(StatusCodes.Status201Created.ToString(), result.Values);
            }
            catch (Exception ex)
            {
                ExceptionDispatchInfo.Capture(ex).Throw();
            }

            return result;
        }

        public async Task<Result<int>> DeleteUserAsync(int idUser)
        {
            var result = new Result<int>();
            var deleteUser = await _userData.DeleteUserAsync(idUser);

            result.Values = deleteUser.Values;

            return result;
        }

        private static UserDto MapToUser(User user)
        {
            return new UserDto()
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Phone = user.Phone,
                Address = user.Address,
                Gender = user.Gender,
                Status = user.Status,
                RegistrationDate = user.RegistrationDate,
                IsActive = user.IsActive
            };
        }

        private static User MapToSaveUpdateUser(UserDto userDto)
        {
            return new User()
            {
                UserId = userDto.UserId,
                IdentificationNumber = userDto.IdentificationNumber,
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
                Username = userDto.Username,
                Email = userDto.Email,
                Phone = userDto.Phone,
                Address = userDto.Address,
                Gender = userDto.Gender,
                Status = userDto.Status,
                Password = userDto.Password,
                RegistrationDate = userDto.RegistrationDate,
                IsActive = userDto.IsActive
            };
        }

        private static List<UserDto> MapToUsers(List<User> users)
        {
            return users.Select(users => new UserDto
            {
                FirstName = users.FirstName,
                LastName = users.LastName,
                Email = users.Email,
                Phone = users.Phone,
                Address = users.Address,
                Gender = users.Gender,
                Status = users.Status,
                RegistrationDate = users.RegistrationDate,
                IsActive = users.IsActive
            }).ToList();
        }

       

        private static bool ValidateUser(string identification)
        {
            if (string.IsNullOrEmpty(identification))
                return false;
            if (identification.Length < 2)
                return false;
            return true;
        }
    }
}
