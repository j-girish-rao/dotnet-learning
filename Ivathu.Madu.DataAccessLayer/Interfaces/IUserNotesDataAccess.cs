using Ivathu.Madu.DataAccessLayer.Models;

namespace Ivathu.Madu.DataAccessLayer.Interfaces
{
    public interface IUserNotesDataAccess
    {
        Task<bool> SaveAsync(UserNote data);

        Task<bool> UpdateAsync(UserNote data);

        Task<List<UserNote>> GetAllAsync();

        Task<UserNote> GetAsync(Guid id);

        Task<bool> DeleteAsync(Guid id);
    }
}