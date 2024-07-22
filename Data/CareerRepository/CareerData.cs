using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Runtime.ExceptionServices;
using Utils;

namespace Data.CareerRepository
{
    public class CareerData : UResult, ICareerData
    {
        private readonly ContexMain _contexMain;
        public CareerData(ContexMain contexMain)
        {
            _contexMain = contexMain;   
        }

        public async Task<Result<Career>> GetCareerById(int idCareer)
        {
            var result = new Result<Career>();

            var responseCareer = await _contexMain.Careers.FirstOrDefaultAsync(career => career.CareerId == idCareer);

            result.Values = responseCareer;

            return result;
        }

        public async Task<Result<List<Career>>> GetCareerAsync()
        {
            var result = new Result<List<Career>>();

            List<Career>? careerList = [];

            careerList = await (from careers in _contexMain.Careers
                             select new Career
                             {
                                 Name = careers.Name,
                             }).ToListAsync();

            result.Values = careerList;

            return result;
        }


       
        public async Task<Result<Career>> SaveCareerAsync(Career career)
        {
            var result = new Result<Career>();
            try
            {
                _contexMain.Careers.Add(career);

                await _contexMain.SaveChangesAsync();

                result.Values = career;
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
            }

            return result;
        }

        public async Task<Result<Career>> UpdateCareerAsync(Career career)
        {
            var result = new Result<Career>();

            try
            {
                var existingCareer = await _contexMain.Careers.FirstOrDefaultAsync(c => c.CareerId.Equals(career.CareerId));

                if (existingCareer == null)
                    return Error<Career>(StatusCodes.Status404NotFound.ToString(), null!);

                existingCareer.Name = career.Name;

                await _contexMain.SaveChangesAsync();

                result.Values = existingCareer;
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

            try
            {
                var career = await _contexMain.Careers.FirstOrDefaultAsync(u => u.CareerId == idCareer);

                if (career == null)
                    return Ok(StatusCodes.Status404NotFound.ToString(), 0);

                _contexMain.Careers.Remove(career);
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
