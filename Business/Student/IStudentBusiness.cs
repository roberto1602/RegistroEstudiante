using Entities.Model;
using Utils;

namespace Business.Student
{
    public interface IStudentBusiness
    {
        Task<Result<StudentDto>> GetStudentById(int idStudent);
        Task<Result<List<StudentDto>>> GetStudentAsync();
        Task<Result<StudentDto>> SaveStudentAsync(StudentDto studentDto);
        Task<Result<StudentDto>> UpdateStudentAsync(StudentDto studentDto);
        Task<Result<int>> DeleteStudentAsync(int idStudent);
    }
}
