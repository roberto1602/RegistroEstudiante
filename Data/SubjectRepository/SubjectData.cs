using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Runtime.ExceptionServices;
using Utils;

namespace Data.Subject
{
    public class SubjectData : UResult, ISubjectData
    {
        private readonly ContexMain _contexMain;
        public SubjectData(ContexMain contexMain)
        {
            _contexMain = contexMain;
        }
        public async Task<Result<SubjectIdentity>> GetSubjectById(int idSubject)
        {
            var result = new Result<SubjectIdentity>();

            var responseSubject = await _contexMain.Subjects.FirstOrDefaultAsync(subject => subject.SubjectId == idSubject);

            result.Values = responseSubject;

            return result;
        }

        public async Task<Result<List<SubjectIdentity>>> GetSubjectAsync()
        {
            var result = new Result<List<SubjectIdentity>>();

            List<SubjectIdentity>? subjectList = [];

            subjectList = await(from subjects in _contexMain.Subjects
                               select new SubjectIdentity
                               {
                                   SubjectId = subjects.SubjectId,
                                   Name = subjects.Name,
                                   Credit = subjects.Credit
                               }).ToListAsync();

            result.Values = subjectList;

            return result;
        }

        public async Task<Result<SubjectIdentity>> SaveSubjectAsync(SubjectIdentity subject)
        {
            var result = new Result<SubjectIdentity>();
            try
            {
                _contexMain.Subjects.Add(subject);

                await _contexMain.SaveChangesAsync();

                result.Values = subject;
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
            }

            return result;
        }

        public async Task<Result<SubjectIdentity>> UpdateSubjectAsync(SubjectIdentity subject)
        {
            var result = new Result<SubjectIdentity>();

            try
            {
                var existingSubject = await _contexMain.Subjects.FirstOrDefaultAsync(s => s.SubjectId.Equals(subject.SubjectId));

                if (existingSubject == null)
                    return Error<SubjectIdentity>(StatusCodes.Status404NotFound.ToString(), null!);

                existingSubject.SubjectId = subject.SubjectId;
                existingSubject.Name = subject.Name;
                existingSubject.Credit = subject.Credit;

                await _contexMain.SaveChangesAsync();

                result.Values = existingSubject;
            }
            catch (Exception ex)
            {
                ExceptionDispatchInfo.Capture(ex).Throw();
            }

            return result;
        }

        public async Task<Result<int>> DeleteSubjectAsync(int idSubject)
        {
            var result = new Result<int>();

            try
            {
                var subject = await _contexMain.Subjects.FirstOrDefaultAsync(s=> s.SubjectId == idSubject);

                if (subject == null)
                    return Error(StatusCodes.Status404NotFound.ToString(), 0);

                _contexMain.Subjects.Remove(subject);
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
