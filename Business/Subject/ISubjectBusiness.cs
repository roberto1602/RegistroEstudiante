using Entities.Model;
using Utils;

namespace Business.Subject
{
    public interface ISubjectBusiness
    {
        Task<Result<Entities.Model.SubjectDto>> GetSubjectById(int idSubject);
        Task<Result<List<Entities.Model.SubjectDto>>> GetSubjectAsync();
        Task<Result<Entities.Model.SubjectDto>> SaveSubjectAsync(Entities.Model.SubjectDto subjectDto);
        Task<Result<Entities.Model.SubjectDto>> UpdateSubjectAsync(Entities.Model.SubjectDto SubjectDto);
        Task<Result<int>> DeleteSubjectAsync(int idSubject);
    }
}
