using Microsoft.AspNetCore.Mvc;
using DietP.Core.Entities;
using DietP.Core.Services;

namespace DietP.Service.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CalendarController : ControllerBase
    {
        private readonly ICalendarService _calendarService;

        public CalendarController(ICalendarService calendarService)
        {
            _calendarService = calendarService;
        }

        [HttpGet("month")]
        public async Task<ActionResult<List<Calendar?>>> GetCalendarItemsByMonth()
        {
            DateTime date = DateTime.Now;
            var items = await _calendarService.getCalendarItemsByMonth(date.Month);
            if (items == null || !items.Any())
            {
                return NotFound("No calendar items found for the specified month.");
            }
            return Ok(items);
        }

        [HttpPost]
        public async Task<ActionResult<Calendar>> CreateCalendarEvent([FromBody] Calendar calendarEvent)
        {
            if (calendarEvent == null)
            {
                return BadRequest("Calendar event cannot be null.");
            }
            var createdEvent = await _calendarService.createCalendarEvent(calendarEvent);
            return CreatedAtAction(nameof(GetCalendarItemsByMonth), new { month = createdEvent.Date.Month }, createdEvent);
        }

        [HttpDelete("year")]
        public async Task<IActionResult> DeleteEvents()
        {
            DateTime date = DateTime.Now;
            await _calendarService.deleteEvents(date.Year);
            return NoContent();
        }
    }
}
