using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Runtime.ExceptionServices;
using Utils;

namespace Data.alunmnoRepository
{
    public class StudentData : UResult, IStudentData
    {
        private readonly ContexMain _contexMain;
        public StudentData(ContexMain contexMain)
        {
            _contexMain = contexMain;
        }
        public async Task<Result<StudentIdentity>> GetStudentById(int idStudent)
        {
            var result = new Result<StudentIdentity>();

            try
            {
                var responseStudent = await _contexMain.Students.FirstOrDefaultAsync(s => s.StudentId == idStudent);

                result.Values = responseStudent;
            }
            catch (Exception ex)
            {
                result.Error = false;
                result.Message = ex.Message;
                ExceptionDispatchInfo.Capture(ex).Throw();
            }
            return result;
        }
        public async Task<Result<List<StudentIdentity>>> GetStudentAsync()
        {
            var result = new Result<List<StudentIdentity>>();

            List<StudentIdentity>? studentList = [];

            studentList = await(from student in _contexMain.Students
                                .Include(student => student.User)
                                .Include(student => student.Role)
                                .Include(student => student.Career)
                                .Include(student => student.Subject)
                                select new StudentIdentity
                                {
                                    StudentId = student.StudentId,
                                    UserRolId = student.UserRolId,
                                    UserId = student.UserId,
                                    RoleId = student.RoleId,
                                    CareerId = student.CareerId,
                                    SubjectId = student.SubjectId,
                                    UserName = student.User!.Username,
                                    RoleName = student.Role!.Name,
                                    CareerName = student.Career!.Name,
                                    SubjectName = student.Subject!.Name
                                }).ToListAsync();

            result.Values = studentList;

            return result;
        }

        public async Task<Result<StudentIdentity>> SaveStudentAsync(StudentIdentity student)
        {
            var result = new Result<StudentIdentity>();
            try
            {
                _contexMain.Students.Add(student);

                await _contexMain.SaveChangesAsync();

                result.Values = student;
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
            }

            return result;
        }

        public async Task<Result<StudentIdentity>> UpdateStudentAsync(StudentIdentity student)
        {
            var result = new Result<StudentIdentity>();

            try
            {
                var existingStudent = await _contexMain.Students.FirstOrDefaultAsync(s => s.StudentId.Equals(student.StudentId));

                if (existingStudent == null)
                    return Error<StudentIdentity>(StatusCodes.Status404NotFound.ToString(), null!);


                _contexMain.Students.Remove(existingStudent);
                await _contexMain.SaveChangesAsync();

              
                var newStudent = new StudentIdentity
                {
                    StudentId = student.StudentId,
                    UserRolId = student.UserRolId,
                    UserId = student.UserId,
                    RoleId = student.RoleId,
                    CareerId = student.CareerId,
                    SubjectId = student.SubjectId
                };

            
                _contexMain.Students.Add(newStudent);
                await _contexMain.SaveChangesAsync();

                result = Ok(StatusCodes.Status200OK.ToString(), newStudent);
            }
            catch (Exception ex)
            {
                result.Error = false;
                result.Message = ex.Message;
                ExceptionDispatchInfo.Capture(ex).Throw();
            }

            return result;
        }

        public async Task<Result<int>> DeleteStudentAsync(int idStudent)
        {
            var result = new Result<int>();

            try
            {
                var student = await _contexMain.Students.FirstOrDefaultAsync(s => s.StudentId == idStudent);

                if (student == null)
                    return Error(StatusCodes.Status404NotFound.ToString(), 0);

                _contexMain.Students.Remove(student);
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
