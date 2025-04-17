using Ivathu.Madu.BusinessLayer.Interfaces;
using Ivathu.Madu.DataAccessLayer.Interfaces;
using Ivathu.Madu.DataAccessLayer.Models;
using Microsoft.Extensions.Logging;

namespace Ivathu.Madu.BusinessLayer
{
    public class UserNotesBusinessLayer : IUserNotesBusinessLayer
    {
        private readonly ILogger<UserNotesBusinessLayer> _logger;
        private readonly IUserNotesDataAccess _daUserNotes;

        public UserNotesBusinessLayer(ILogger<UserNotesBusinessLayer> logger, IUserNotesDataAccess daUserNotes)
        {
            _logger = logger;
            _daUserNotes = daUserNotes;
        }

        public async Task<List<UserNote>> GetAllAsync()
        {
            try
            {
                return await _daUserNotes.GetAllAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message, null);
                throw ex;
            }
        }

        public async Task<UserNote> GetAsync(Guid id)
        {
            try
            {
                return await _daUserNotes.GetAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message, null);
                throw ex;
            }
        }

        public async Task<bool> SaveAsync(UserNote data)
        {
            try
            {
                data.Id = Guid.NewGuid();
                data.CreatedDate = DateTime.UtcNow;
                data.ModifiedDate = DateTime.UtcNow;
                if (data.UserNotesCheckLists.Count > 0)
                {
                    foreach (UserNotesCheckList item in data.UserNotesCheckLists)
                    {
                        item.Id = Guid.NewGuid();
                        item.CreatedDate = DateTime.UtcNow;
                        item.ModifiedDate = DateTime.UtcNow;
                    }
                }
                return await _daUserNotes.SaveAsync(data);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message, null);
                throw ex;
            }
        }

        public async Task<bool> UpdateAsync(UserNote data)
        {
            try
            {
                data.ModifiedDate = DateTime.UtcNow;
                if (data.UserNotesCheckLists.Count > 0)
                {
                    foreach (UserNotesCheckList item in data.UserNotesCheckLists)
                    {
                        if (item.Id == Guid.Empty)
                        {
                            item.Id = Guid.NewGuid();
                            item.CreatedDate = DateTime.UtcNow;
                        }
                        item.ModifiedDate = DateTime.UtcNow;
                    }
                }
                return await _daUserNotes.UpdateAsync(data);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message, null);
                throw ex;
            }
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            try
            {
                return await _daUserNotes.DeleteAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message, null);
                throw ex;
            }
        }
    }
}
