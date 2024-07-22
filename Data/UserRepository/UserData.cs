using Entities;
using Entities.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Runtime.ExceptionServices;
using Utils;

namespace Data.StudentRepository
{
    public class UserData : UResult, IUserData
    {
        private readonly ContexMain _contexMain;
        public UserData(ContexMain contexMain)
        {
            _contexMain = contexMain;   
        }

        public async Task<Result<User>>GetUserById(string identification)
        {
            var result = new Result<User>();

            var responseUser = await _contexMain.Users.FirstOrDefaultAsync(user => user.IdentificationNumber == identification);

            result.Values = responseUser;

            return result;
        }


        public async Task<Result<List<User>>> GetUserAsync()
        {
           var result = new Result<List<User>>();

            List<User>? userList = [];

            userList = await (from users in _contexMain.Users
                            select new User
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
                            }).ToListAsync();

            result.Values = userList;

            return result;
        }

        public async Task<Result<User>> SaveUserAsync(User user)
        {
            var result = new Result<User>();
            try
            {
                _contexMain.Users.Add(user);

                await _contexMain.SaveChangesAsync();

                result.Values = user;
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
            }

            return result;
        }

        public async Task<Result<User>> UpdateUserAsync(User user)
        {
            var result = new Result<User>();

            try
            {
                var existingUser = await _contexMain.Users.FirstOrDefaultAsync(u => u.UserId.Equals(user.UserId));
                
                if (existingUser == null)
                        return Error<User>(StatusCodes.Status404NotFound.ToString(), null!);

                existingUser.IdentificationNumber = user.IdentificationNumber;
                existingUser.FirstName = user.FirstName;
                existingUser.LastName = user.LastName;
                existingUser.Username = user.Username;
                existingUser.Email = user.Email;
                existingUser.Phone = user.Phone;
                existingUser.Address = user.Address;
                existingUser.Gender = user.Gender;
                existingUser.Status = user.Status;
                existingUser.Password = user.Password;
                existingUser.RegistrationDate = user.RegistrationDate;
                existingUser.IsActive = user.IsActive;

                await _contexMain.SaveChangesAsync();

                result.Values = existingUser;

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

            try
            {
                var user = await _contexMain.Users.FirstOrDefaultAsync(u => u.UserId == idUser);

                if (user == null)
                    return Ok<int>(StatusCodes.Status404NotFound.ToString(), 0);

                _contexMain.Users.Remove(user);
                await _contexMain.SaveChangesAsync();

                result = Ok(StatusCodes.Status200OK.ToString(), result.Values);
            }
            catch (Exception ex)
            {
                ExceptionDispatchInfo.Capture(ex).Throw();
            }

            return result;
        }
    }
}
