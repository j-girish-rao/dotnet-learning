using myDailyTask.DataAccessLayer.Models;

namespace myDailyTask.DataAccessLayer.Interfaces
{
    public interface ISeverityDataAccess
    {
        //1. Save
        Task<bool> SaveAsync(SeverityMaster data);

        //2. Update
        Task<bool> UpdateAsync(SeverityMaster data);

        //3. GetAll
        Task<List<SeverityMaster>> GetAllAsync();

        //4. Get
        Task<SeverityMaster> GetAsync(Guid id);

        //5. Delete
        Task<bool> DeleteAsync(Guid id);
    }
}
