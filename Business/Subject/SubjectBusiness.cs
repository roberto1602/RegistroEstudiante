using Data.Subject;
using Entities;
using Entities.Model;
using Microsoft.AspNetCore.Http;
using System.Runtime.ExceptionServices;
using Utils;

namespace Business.Subject
{
    public class SubjectBusiness : UResult, ISubjectBusiness
    {  
        private readonly ISubjectData _subjectData;

        public SubjectBusiness(ISubjectData subjectData)
        {
            _subjectData = subjectData;
        }
        public async Task<Result<SubjectDto>> GetSubjectById(int idSubject)
        {
            var result = new Result<SubjectDto>();

            try
            {
                var responseSubject = await _subjectData.GetSubjectById(idSubject);

                if (responseSubject.Values == null)
                    return Ok<SubjectDto>(StatusCodes.Status404NotFound.ToString(), null);

                result.Values = MapToSubject(responseSubject.Values!);

                result = Ok(StatusCodes.Status200OK.ToString(), result.Values);

            }
            catch (Exception ex)
            {
                ExceptionDispatchInfo.Capture(ex).Throw();
            }

            return result;
        }


        public async Task<Result<List<SubjectDto>>> GetSubjectAsync()
        {
            var result = new Result<List<SubjectDto>>();

            try
            {
                var careers = await _subjectData.GetSubjectAsync();

                if (careers.Values == null)
                    return Ok<List<SubjectDto>>(StatusCodes.Status404NotFound.ToString(), null!);

                result.Values = MapToSubjects(careers.Values!);

                result = Ok(StatusCodes.Status200OK.ToString(), result.Values);

            }
            catch (Exception ex)
            {
                ExceptionDispatchInfo.Capture(ex).Throw();
            }

            return result;
        }

        public async Task<Result<SubjectDto>> SaveSubjectAsync(SubjectDto subjectDto)
        {
            var result = new Result<SubjectDto>();

            try
            {
                var mapSubject = MapToSaveUpdateSubject(subjectDto);

                var subject = await _subjectData.SaveSubjectAsync(mapSubject);

                if (subject.Values == null)
                    return Ok<SubjectDto>(StatusCodes.Status400BadRequest.ToString(), null!);

                result.Values = MapToSubject(subject.Values!);

                result = Ok(StatusCodes.Status201Created.ToString(), result.Values);
            }
            catch (Exception ex)
            {
                ExceptionDispatchInfo.Capture(ex).Throw();
            }

            return result;
        }

        public async Task<Result<SubjectDto>> UpdateSubjectAsync(SubjectDto SubjectDto)
        {
            var result = new Result<SubjectDto>();

            try
            {
                var mapSubject = MapToSaveUpdateSubject(SubjectDto);

                var subject = await _subjectData.UpdateSubjectAsync(mapSubject);

                if (subject.Values == null)
                    return Ok<SubjectDto>(StatusCodes.Status400BadRequest.ToString(), null!);

                result.Values = MapToSubject(subject.Values!);

                result = Ok(StatusCodes.Status201Created.ToString(), result.Values);
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
            var deleteUser = await _subjectData.DeleteSubjectAsync(idSubject);

            result.Values = deleteUser.Values;

            return result;
        }


        private static SubjectDto MapToSubject(SubjectIdentity subject)
        {
            return new SubjectDto()
            {
                SubjectId = subject.SubjectId,
                Name = subject.Name,
                Credit = subject.Credit
            };
        }

        private static List<SubjectDto> MapToSubjects(List<SubjectIdentity> subjects)
        {
            return subjects.Select(subjects => new SubjectDto
            {
                SubjectId = subjects.SubjectId,
                Name = subjects.Name,
                Credit = subjects.Credit
            }).ToList();
        }

        private static SubjectIdentity MapToSaveUpdateSubject(SubjectDto SubjectDto)
        {
            return new SubjectIdentity()
            {
                SubjectId = SubjectDto.SubjectId,
                Name = SubjectDto.Name,
                Credit = SubjectDto.Credit
            };
        }

    }
}
