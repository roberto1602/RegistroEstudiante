using Business.Student;
using Entities.Model;
using Microsoft.AspNetCore.Mvc;
using Utils;

namespace RegistroEstudiante.Controllers
{
    [Route("api/student")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentBusiness _studentBusiness;
        public StudentController(IStudentBusiness studentBusiness)
        {
            _studentBusiness = studentBusiness;
        }

        [HttpGet("student-id", Name = "StudentId")]
        [ProducesResponseType(typeof(Result<StudentDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Result<StudentDto>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(Result<StudentDto>), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetStudentById(int idStudent)
        {
            try
            {
                var response = await _studentBusiness.GetStudentById(idStudent);

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

        [HttpGet("student-list", Name = "StudentList")]
        [ProducesResponseType(typeof(Result<StudentDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Result<StudentDto>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(Result<StudentDto>), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetStudents()
        {
            try
            {
                var response = await _studentBusiness.GetStudentAsync();

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

        [HttpPost("save-student", Name = "StudentSave")]
        [ProducesResponseType(typeof(Result<StudentDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Result<StudentDto>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(Result<StudentDto>), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> SaveStudentAsync(StudentDto StudentDto)
        {
            try
            {
                var response = await _studentBusiness.SaveStudentAsync(StudentDto);

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


        [HttpPost("update-Student", Name = "StudentUpdate")]
        [ProducesResponseType(typeof(Result<StudentDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Result<StudentDto>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(Result<StudentDto>), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateStudentAsync(StudentDto StudentDto)
        {
            try
            {
                var response = await _studentBusiness.UpdateStudentAsync(StudentDto);

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

        [HttpDelete("delete-Student", Name = "DeleteStudent")]
        [ProducesResponseType(typeof(Result<int>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Result<int>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(Result<int>), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteStudentAsync(int idStudent)
        {
            try
            {
                var response = await _studentBusiness.DeleteStudentAsync(idStudent);
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
