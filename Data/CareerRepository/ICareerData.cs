using Entities;
using Entities.Model;
using Utils;

namespace Data.CareerRepository
{
    public interface ICareerData
    {
        Task<Result<Career>> GetCareerById(int idCareer);
        Task<Result<List<Career>>> GetCareerAsync();
        Task<Result<Career>> SaveCareerAsync(Career CareerDto);
        Task<Result<Career>> UpdateCareerAsync(Career CareerDto);
        Task<Result<int>> DeleteCareerAsync(int idCareer);
    }
}