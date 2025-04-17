using Ivathu.Madu.DataAccessLayer.Models;

namespace Ivathu.Madu.BusinessLayer.Interfaces
{
    public interface IUserNotesBusinessLayer
    {
        //1. Save
        Task<bool> SaveAsync(UserNote data);

        //2. Update
        Task<bool> UpdateAsync(UserNote data);

        //3. GetAll
        Task<List<UserNote>> GetAllAsync();

        //4. Get
        Task<UserNote> GetAsync(Guid id);

        //5. Delete
        Task<bool> DeleteAsync(Guid id);
    }
}
