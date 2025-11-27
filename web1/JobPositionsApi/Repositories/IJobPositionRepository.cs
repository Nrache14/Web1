using JobPositionsApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JobPositionsApi.Repositories
{
    public interface IJobPositionRepository
    {
        Task<IEnumerable<JobPosition>> GetAllAsync();
        Task<JobPosition?> GetByIdAsync(int id);
        Task<int> CreateAsync(JobPosition job);
        Task<bool> UpdateAsync(JobPosition job);
        Task<bool> DeleteAsync(int id);
    }
}
