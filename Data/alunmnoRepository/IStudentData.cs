using Entities;
using Utils;

namespace Data.alunmnoRepository
{
    public interface IStudentData
    {
        Task<Result<StudentIdentity>> GetStudentById(int idStudent);
        Task<Result<List<StudentIdentity>>> GetStudentAsync();
        Task<Result<StudentIdentity>> SaveStudentAsync(StudentIdentity studentDto);
        Task<Result<StudentIdentity>> UpdateStudentAsync(StudentIdentity studentDto);
        Task<Result<int>> DeleteStudentAsync(int idStudent);
    }
}
