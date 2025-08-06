using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using DietP.Core.Entities;
using DietP.Service.Services;
using Microsoft.Extensions.Logging;
using DietP.Core.Services;
using System.Xml.Linq;
using MySqlX.XDevAPI.Common;

namespace DietP.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SportController : ControllerBase
    {
        private readonly ISportService _sportService;
        private readonly IMapper _mapper;
        private readonly ILogger<SportController> _logger;

        public SportController(ISportService sportService, IMapper mapper, ILogger<SportController> logger)
        {
            _mapper = mapper; // המרה מDTO לDAO
            _sportService = sportService; // פונקציות הסרוויס שלנו
            _logger = logger; // מיפוי שגיאות
        }

        // GET: api/sport/losecal/{cal}
        [HttpGet("losecal/{cal}")]
        public async Task<ActionResult<List<Sport>>> GetByLoseCal(int cal)
        {
            try
            {
                var sports = await _sportService.GetByLoseCal(cal);
                if (sports == null || !sports.Any())
                {
                    return NotFound("No sports action found for the specified calories.");
                }
                return Ok(sports);
            }
            catch(Exception ex) {
                _logger.LogError(ex, "Error finding sport");
                return NotFound(ex.Message);

            }
    }
// POST: api/sport
[HttpPost]
        public async Task<ActionResult<Sport>> AddSport([FromBody] Sport sport)
        {
            var createdSport = await _sportService.AddSport(sport);
            return CreatedAtAction(nameof(GetByLoseCal), new { cal = createdSport.LoseCalPerHour }, createdSport);
        }

        // PUT: api/sport
        [HttpPut]
        public async Task<ActionResult<Sport>> UpdateSport(string name, string description, string type, int loseCalPerHour, string newName, string newDescription, string newType, int newLoseCalPerHour)
        {
            try
            {
                var updatedSport = await _sportService.UpdateSport(name, description, type, loseCalPerHour, newName, newDescription, newType, newLoseCalPerHour);
                return Ok(updatedSport);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating sport");
                return NotFound(ex.Message);
            }
        }

        // DELETE: api/sport/{name}
        [HttpDelete("{name}")]
        public async Task<ActionResult<Sport>> DeleteSport(string name)
        {
            try
            {
                var deletedSport = await _sportService.DeleteSport(name);
                return Ok(deletedSport);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting sport");
                return NotFound(ex.Message);
            }
        }
    }
}
