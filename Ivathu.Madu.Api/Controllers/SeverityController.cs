using Microsoft.AspNetCore.Mvc;
using Ivathu.Madu.BusinessLayer.Interfaces;
using Ivathu.Madu.DataAccessLayer.Models;

namespace Ivathu.Madu.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeverityController : ControllerBase
    {
        private readonly ILogger<SeverityController> _logger;
        private readonly ISeverityBusinessLayer _blSeverity;
        public SeverityController(ILogger<SeverityController> logger, ISeverityBusinessLayer blSeverity)
        {
            _logger = logger;
            _blSeverity = blSeverity;
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {
                return Ok(await _blSeverity.GetAllAsync());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message, null);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("Get")]
        public async Task<IActionResult> GetAsync(Guid id)
        {
            try
            {
                if (id == Guid.Empty)
                {
                    return BadRequest();
                }
                SeverityMaster result = await _blSeverity.GetAsync(id);
                if (result != null)
                {
                    return Ok(result);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message, null);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        [Route("Save")]
        public async Task<IActionResult> SaveAsync([FromBody] SeverityMaster request)
        {
            try
            {
                bool result = await _blSeverity.SaveAsync(request);
                if (result)
                {
                    return Ok();
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message, null);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> UpdateAsync([FromBody] SeverityMaster request)
        {
            try
            {
                if (request.Id == Guid.Empty)
                {
                    return BadRequest();
                }
                bool result = await _blSeverity.UpdateAsync(request);
                if (result)
                {
                    return Ok();
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message, null);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete]
        [Route("Delete")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            try
            {
                if (id == Guid.Empty)
                {
                    return BadRequest();
                }
                bool result = await _blSeverity.DeleteAsync(id);
                if (result)
                {
                    return Ok();
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message, null);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}