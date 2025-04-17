using Ivathu.Madu.DataAccessLayer.DBContext;
using Ivathu.Madu.DataAccessLayer.Interfaces;
using Ivathu.Madu.DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Ivathu.Madu.DataAccessLayer
{
    public class SeverityDataAccess : ISeverityDataAccess
    {
        private readonly ILogger<SeverityDataAccess> _logger;
        private readonly MyDailyTakeDbContext _dbContext;

        public SeverityDataAccess(ILogger<SeverityDataAccess> logger, MyDailyTakeDbContext dbContext) 
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        public async Task<bool> SaveAsync(SeverityMaster request)
        {
            try
            {
                await _dbContext.SeverityMasters.AddAsync(request);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message, null);
                throw ex;
            }
        }

        public async Task<bool> UpdateAsync(SeverityMaster data)
        {
            try
            {
                SeverityMaster severity = await _dbContext.SeverityMasters.SingleOrDefaultAsync(_ => _.Id == data.Id);
                if (severity == null)
                {
                    return false;
                }
                severity.Priority = data.Priority;
                severity.Name = data.Name;
                severity.Color = data.Color;
                _dbContext.SeverityMasters.Update(severity);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message, null);
                throw ex;
            }
        }

        public async Task<List<SeverityMaster>> GetAllAsync()
        {
            try
            {
                return await Task.FromResult(_dbContext.SeverityMasters.ToList());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message, null);
                throw ex;
            }
        }

        public async Task<SeverityMaster> GetAsync(Guid id)
        {
            try
            {
                SeverityMaster severity = await _dbContext.SeverityMasters.FirstOrDefaultAsync(_ => _.Id == id);
                if (severity == null)
                {
                    return null;
                }
                return severity;
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
                SeverityMaster severity = await _dbContext.SeverityMasters.SingleOrDefaultAsync(_ => _.Id == id);
                if (severity == null)
                {
                    return false;
                }

                _dbContext.SeverityMasters.Remove(severity);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message, null);
                throw ex;
            }
        }
    }
}
