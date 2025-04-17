using Microsoft.AspNetCore.Mvc;
using Ivathu.Madu.BusinessLayer.Interfaces;
using Ivathu.Madu.DataAccessLayer.Models;

namespace myDailyTask.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserNotesController : ControllerBase
    {
        private readonly ILogger<UserNotesController> _logger;
        private readonly IUserNotesBusinessLayer _blUserNotes;
        public UserNotesController(ILogger<UserNotesController> logger, IUserNotesBusinessLayer blUserNotes)
        {
            _logger = logger;
            _blUserNotes = blUserNotes;
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {
                return Ok(await _blUserNotes.GetAllAsync());
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
                UserNote result = await _blUserNotes.GetAsync(id);
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
        public async Task<IActionResult> SaveAsync([FromBody] UserNote request)
        {
            try
            {
                bool result = await _blUserNotes.SaveAsync(request);
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
        public async Task<IActionResult> UpdateAsync([FromBody] UserNote request)
        {
            try
            {
                if (request.Id == Guid.Empty)
                {
                    return BadRequest();
                }
                bool result = await _blUserNotes.UpdateAsync(request);
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
                bool result = await _blUserNotes.DeleteAsync(id);
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