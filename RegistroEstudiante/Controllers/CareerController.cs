using Business.Career;
using Entities.Model;
using Microsoft.AspNetCore.Mvc;
using Utils;

namespace RegistroEstudiante.Controllers
{
    [Route("api/career")]
    [ApiController]
    public class CareerController : ControllerBase
    {
        private readonly ICareerBusiness _careerBusiness;
        public CareerController(ICareerBusiness careerBusiness)
        {
            _careerBusiness = careerBusiness;
        }


        [HttpGet("career-id", Name = "CareerId")]
        [ProducesResponseType(typeof(Result<CareerDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Result<CareerDto>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(Result<CareerDto>), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetCareerById(int idCareer)
        {
            try
            {
                var response = await _careerBusiness.GetCareerById(idCareer);

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

        [HttpGet("career-list", Name = "careerList")]
        [ProducesResponseType(typeof(Result<CareerDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Result<CareerDto>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(Result<CareerDto>), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetCareers()
        {
            try
            {
                var response = await _careerBusiness.GetCareerAsync();

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

        [HttpPost("save-career", Name = "CareerSave")]
        [ProducesResponseType(typeof(Result<CareerDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Result<CareerDto>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(Result<CareerDto>), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> SaveCareerAsync(CareerDto careerDto)
        {
            try
            {
                var response = await _careerBusiness.SaveCareerAsync(careerDto);

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


        [HttpPost("update-career", Name = "CareerUpdate")]
        [ProducesResponseType(typeof(Result<CareerDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Result<CareerDto>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(Result<CareerDto>), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateCareerAsync(CareerDto careerDto)
        {
            try
            {
                var response = await _careerBusiness.UpdateCareerAsync(careerDto);

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

        [HttpDelete("delete-career", Name = "Deletecareer")]
        [ProducesResponseType(typeof(Result<int>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Result<int>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(Result<int>), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteCareerAsync(int idCareer)
        {
            try
            {
                var response = await _careerBusiness.DeleteCareerAsync(idCareer);
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
