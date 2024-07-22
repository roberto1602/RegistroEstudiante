using Data.alunmnoRepository;
using Entities;
using Entities.Model;
using Microsoft.AspNetCore.Http;
using System.Runtime.ExceptionServices;
using Utils;

namespace Business.Student
{
    public class StudentBusiness : UResult, IStudentBusiness
    {
        private readonly IStudentData _studentData;
        public StudentBusiness(IStudentData studentData)
        {
            _studentData = studentData;
        }
        public async Task<Result<StudentDto>> GetStudentById(int idStudent)
        {
            var result = new Result<StudentDto>();

            try
            {
                var responseStudent = await _studentData.GetStudentById(idStudent);

                if (responseStudent.Values == null)
                    return Ok<StudentDto>(StatusCodes.Status404NotFound.ToString(), null);

                result.Values = MapToStudent(responseStudent.Values!);

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

        public async Task<Result<List<StudentDto>>> GetStudentAsync()
        {
            var result = new Result<List<StudentDto>>();

            try
            {
                var students = await _studentData.GetStudentAsync();

                if (students.Values == null)
                    return Ok<List<StudentDto>>(StatusCodes.Status404NotFound.ToString(), null!);

                result.Values = MapToStudents(students.Values!);

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
       
        public async Task<Result<StudentDto>> SaveStudentAsync(StudentDto studentDto)
        {
            var result = new Result<StudentDto>();

            try
            {
                var mapstudent = MapToSaveUpdateStudent(studentDto);

                if (mapstudent.StudentId < 3)
                {
                    var student = await _studentData.SaveStudentAsync(mapstudent);

                    if (student.Values == null)
                        return Ok<StudentDto>(StatusCodes.Status400BadRequest.ToString(), null!);

                    result.Values = MapToStudent(student.Values!);
                }

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

        public async Task<Result<StudentDto>> UpdateStudentAsync(StudentDto studentDto)
        {
            var result = new Result<StudentDto>();

            try
            {
                var mapStudent = MapToSaveUpdateStudent(studentDto);

                var student = await _studentData.SaveStudentAsync(mapStudent);

                if (student.Values == null)
                    return Ok<StudentDto>(StatusCodes.Status400BadRequest.ToString(), null!);

                result.Values = MapToStudent(student.Values!);

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

        public async Task<Result<int>> DeleteStudentAsync(int idStudent)
        {
            var result = new Result<int>();
            var deleteStudent = await _studentData.DeleteStudentAsync(idStudent);

            result.Values = deleteStudent.Values;

            return result;
        }

        private static StudentDto MapToStudent(StudentIdentity student)
        {
            return new StudentDto()
            {
                StudentId = student.StudentId,
                UserRolId = student.UserRolId,
                UserId = student.UserId,
                RoleId = student.RoleId,
                CareerId = student.CareerId,
                SubjectId = student.SubjectId
            };
        }

        private static List<StudentDto> MapToStudents(List<StudentIdentity> students)
        {
            return students.Select(students => new StudentDto
            {
                StudentId = students.StudentId,
                UserRolId = students.UserRolId,
                UserId = students.UserId,
                RoleId = students.RoleId,
                CareerId = students.CareerId,
                SubjectId = students.SubjectId
                
            }).ToList();
        }

        private static StudentIdentity MapToSaveUpdateStudent(StudentDto studentDto)
        {
            return new StudentIdentity()
            {
                
            };
        }
    }
}
