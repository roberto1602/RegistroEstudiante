using Entities.Model;
using Utils;

namespace Business.Career
{
    public interface ICareerBusiness
    {
        Task<Result<CareerDto>> GetCareerById(int idCareer);
        Task<Result<List<CareerDto>>> GetCareerAsync();
        Task<Result<CareerDto>> SaveCareerAsync(CareerDto CareerDto);
        Task<Result<CareerDto>> UpdateCareerAsync(CareerDto CareerDto);
        Task<Result<int>> DeleteCareerAsync(int idCareer);
    }
}