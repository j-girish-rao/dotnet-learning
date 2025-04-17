using Ivathu.Madu.DataAccessLayer.DBContext;
using Ivathu.Madu.DataAccessLayer.Interfaces;
using Ivathu.Madu.DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Ivathu.Madu.DataAccessLayer
{
    public class UserNotesDataAccess : IUserNotesDataAccess
    {
        private readonly ILogger<SeverityDataAccess> _logger;
        private readonly MyDailyTakeDbContext _dbContext;
        public UserNotesDataAccess(ILogger<SeverityDataAccess> logger, MyDailyTakeDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }
        public async Task<bool> SaveAsync(UserNote request)
        {
            try
            {
                await _dbContext.UserNotes.AddAsync(request);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message, null);
                throw ex;
            }
        }
        public async Task<bool> UpdateAsync(UserNote request)
        {
            try
            {
                UserNote oUserNote = await _dbContext.UserNotes.FirstOrDefaultAsync(_ => _.Id == request.Id);
                if (oUserNote != null)
                {
                    oUserNote.ParentSeverityId = request.ParentSeverityId;
                    oUserNote.Heading = request.Heading;
                    oUserNote.Content = request.Content;
                    oUserNote.CreatedDate = oUserNote.CreatedDate;
                    _dbContext.UserNotes.Update(oUserNote);
                    await _dbContext.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message, null);
                throw ex;
            }
        }

        public async Task<List<UserNote>> GetAllAsync()
        {
            try
            {
                return await _dbContext.UserNotes.ToListAsync();
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
                UserNote response = await _dbContext.UserNotes.Where(_ => _.Id == id).Include(l => l.UserNotesCheckLists).FirstOrDefaultAsync();
                if (response == null)
                {
                    return null;
                }
                return response;
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
                UserNote oUserNote = await _dbContext.UserNotes.Where(_ => _.Id == id).Include(l => l.UserNotesCheckLists).FirstOrDefaultAsync();
                if (oUserNote != null)
                {
                    _dbContext.UserNotes.Remove(oUserNote);
                    await _dbContext.SaveChangesAsync();
                }
                return false;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message, null);
                throw ex;
            }
        }
    }
}
