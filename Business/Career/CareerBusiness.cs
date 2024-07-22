using Data.CareerRepository;
using Data.StudentRepository;
using Entities;
using Entities.Model;
using Microsoft.AspNetCore.Http;
using System.Runtime.ExceptionServices;
using Utils;

namespace Business.Career
{
    public class CareerBusiness : UResult, ICareerBusiness
    {
        private readonly ICareerData _careerData;
        public CareerBusiness(ICareerData careerData)
        {
            _careerData = careerData;
        }
        public async Task<Result<CareerDto>> GetCareerById(int career)
        {
            var result = new Result<CareerDto>();

            try
            {               
                var responseCareer = await _careerData.GetCareerById(career);

                if (responseCareer.Values == null)
                    return Ok<CareerDto>(StatusCodes.Status404NotFound.ToString(), null);

                result.Values = MapToCareer(responseCareer.Values!);

                result = Ok(StatusCodes.Status200OK.ToString(), result.Values);

            }
            catch (Exception ex)
            {
                ExceptionDispatchInfo.Capture(ex).Throw();
            }

            return result;
        }


        public async Task<Result<List<CareerDto>>> GetCareerAsync()
        {
            var result = new Result<List<CareerDto>>();

            try
            {
                var careers = await _careerData.GetCareerAsync();

                if (careers.Values == null)
                    return Ok<List<CareerDto>>(StatusCodes.Status404NotFound.ToString(), null!);

                result.Values = MapToCareers(careers.Values!);

                result = Ok(StatusCodes.Status200OK.ToString(), result.Values);

            }
            catch (Exception ex)
            {
                ExceptionDispatchInfo.Capture(ex).Throw();
            }

            return result;
        }  


        public async Task<Result<CareerDto>> SaveCareerAsync(CareerDto CareerDto)
        {
            var result = new Result<CareerDto>();

            try
            {
                var mapcareer = MapToSaveUpdateCareer(CareerDto);

                var career = await _careerData.SaveCareerAsync(mapcareer);

                if (career.Values == null)
                    return Ok<CareerDto>(StatusCodes.Status400BadRequest.ToString(), null!);

                result.Values = MapToCareer(career.Values!);

                result = Ok(StatusCodes.Status201Created.ToString(), result.Values);
            }
            catch (Exception ex)
            {
                ExceptionDispatchInfo.Capture(ex).Throw();
            }

            return result;
        }

        public async Task<Result<CareerDto>> UpdateCareerAsync(CareerDto CareerDto)
        {
            var result = new Result<CareerDto>();

            try
            {
                var mapUser = MapToSaveUpdateCareer(CareerDto);

                var career = await _careerData.UpdateCareerAsync(mapUser);

                if (career.Values == null)
                    return Ok<CareerDto>(StatusCodes.Status404NotFound.ToString(), null!);

                result.Values = MapToCareer(career.Values!);

                result = Ok(StatusCodes.Status201Created.ToString(), result.Values);
            }
            catch (Exception ex)
            {
                ExceptionDispatchInfo.Capture(ex).Throw();
            }

            return result;
        }
        public async Task<Result<int>> DeleteCareerAsync(int idCareer)
        {
            var result = new Result<int>();
            var deleteUser = await _careerData.DeleteCareerAsync(idCareer);

            result.Values = deleteUser.Values;

            return result;
        }




        private static CareerDto MapToCareer(Entities.Career career)
        {
            return new CareerDto()
            {
                Name = career.Name
            };
        }

        private static List<CareerDto> MapToCareers(List<Entities.Career> careers)
        {
            return careers.Select(careers => new CareerDto
            {
                Name = careers.Name
            }).ToList();
        }

        private static Entities.Career MapToSaveUpdateCareer(CareerDto careerDto)
        {
            return new Entities.Career()
            {
                CareerId = careerDto.CareerId,
                Name = careerDto.Name
            };
        }
    }
}
