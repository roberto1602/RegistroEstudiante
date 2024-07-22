using Entities;
using Entities.Model;
using Utils;

namespace Data.Subject
{
    public interface ISubjectData
    {
        Task<Result<SubjectIdentity>> GetSubjectById(int idSubject);
        Task<Result<List<SubjectIdentity>>> GetSubjectAsync();
        Task<Result<SubjectIdentity>> SaveSubjectAsync(SubjectIdentity subject);
        Task<Result<SubjectIdentity>> UpdateSubjectAsync(SubjectIdentity Subject);
        Task<Result<int>> DeleteSubjectAsync(int idSubject);
    }
}
