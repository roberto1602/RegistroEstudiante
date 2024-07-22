using Business.Subject;
using Entities.Model;
using Microsoft.AspNetCore.Mvc;
using Utils;

namespace RegistroEstudiante.Controllers
{
    [Route("api/subject")]
    [ApiController]
    public class SubjectController : ControllerBase
    {
        private readonly ISubjectBusiness _subjectBusiness;
        public SubjectController(ISubjectBusiness subjectBusiness)
        {
            _subjectBusiness = subjectBusiness;
        }


        [HttpGet("subject-id", Name = "SubjectId")]
        [ProducesResponseType(typeof(Result<SubjectDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Result<SubjectDto>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(Result<SubjectDto>), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetSubjectById(int idsubject)
        {
            try
            {
                var response = await _subjectBusiness.GetSubjectById(idsubject);

                if (response.Error == true)
                {
                    if (response.Values != null)
                        return Ok(response.Values);
                }
                return NotFound(response);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpGet("subject-list", Name = "subjectList")]
        [ProducesResponseType(typeof(Result<SubjectDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Result<SubjectDto>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(Result<SubjectDto>), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Getsubjects()
        {
            try
            {
                var response = await _subjectBusiness.GetSubjectAsync();

                if (response.Error == true)
                {
                    if (response.Values != null)
                        return Ok(response.Values);
                }
                return NotFound(response);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpPost("save-subject", Name = "subjectSave")]
        [ProducesResponseType(typeof(Result<SubjectDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Result<SubjectDto>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(Result<SubjectDto>), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> SaveSubjectAsync(SubjectDto SubjectDto)
        {
            try
            {
                var response = await _subjectBusiness.SaveSubjectAsync(SubjectDto);

                if (response.Error == true)
                {
                    if (response.Values != null)
                        return Ok(response.Values);
                }
                return NotFound(response);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }


        [HttpPost("update-subject", Name = "subjectUpdate")]
        [ProducesResponseType(typeof(Result<SubjectDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Result<SubjectDto>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(Result<SubjectDto>), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateSubjectAsync(SubjectDto SubjectDto)
        {
            try
            {
                var response = await _subjectBusiness.UpdateSubjectAsync(SubjectDto);

                if (response.Error == true)
                {
                    if (response.Values != null)
                        return Ok(response.Values);
                }
                return NotFound(response);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpDelete("delete-subject", Name = "Deletesubject")]
        [ProducesResponseType(typeof(Result<int>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Result<int>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(Result<int>), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeletesubjectAsync(int idsubject)
        {
            try
            {
                var response = await _subjectBusiness.DeleteSubjectAsync(idsubject);
                return Ok(response.Values);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        protected IActionResult InternalServerError(object obj)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, obj);
        }
    }
}
