using Ivathu.Madu.DataAccessLayer.Models;

namespace Ivathu.Madu.DataAccessLayer.Interfaces
{
    public interface ISeverityDataAccess
    {
        Task<bool> SaveAsync(SeverityMaster data);

        Task<bool> UpdateAsync(SeverityMaster data);

        Task<List<SeverityMaster>> GetAllAsync();

        Task<SeverityMaster> GetAsync(Guid id);

        Task<bool> DeleteAsync(Guid id);
    }
}