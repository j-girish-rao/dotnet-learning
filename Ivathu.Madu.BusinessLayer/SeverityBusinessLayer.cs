using Ivathu.Madu.BusinessLayer.Interfaces;
using Ivathu.Madu.DataAccessLayer.Interfaces;
using Ivathu.Madu.DataAccessLayer.Models;
using Microsoft.Extensions.Logging;

namespace Ivathu.Madu.BusinessLayer
{
    public class SeverityBusinessLayer : ISeverityBusinessLayer
    {
        private readonly ILogger<SeverityBusinessLayer> _logger;
        private readonly ISeverityDataAccess _daSeverity;

        public SeverityBusinessLayer(ILogger<SeverityBusinessLayer> logger, ISeverityDataAccess daSeverity)
        {
            _logger = logger;
            _daSeverity = daSeverity;
        }

        public async Task<SeverityMaster> GetAsync(Guid id)
        {
            try
            {
                return await _daSeverity.GetAsync(id);
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
                return await _daSeverity.GetAllAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message, null);
                throw ex;
            }
        }

        public async Task<bool> SaveAsync(SeverityMaster request)
        {
            try
            {
                request.Id = new Guid();
                return await _daSeverity.SaveAsync(request);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message, null);
                throw ex;
            }
        }

        public async Task<bool> UpdateAsync(SeverityMaster request)
        {
            try
            {
                return await _daSeverity.UpdateAsync(request);
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
                return await _daSeverity.DeleteAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message, null);
                throw ex;
            }
        }
    }
}
