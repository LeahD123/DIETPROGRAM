using DietP.Core.Entities;
using DietP.Core.Repositories;
using DietP.Core.Services;

namespace DietP.Service.Services
{
    public class CalendarService : ICalendarService
    {
        private readonly IDataRepository _dataRepository;
        public CalendarService(IDataRepository dataRepository)
        {
            _dataRepository = dataRepository;
        }

        public async Task<List<Calendar?>> getCalendarItemsByMonth(int month)
        {
            var calendarItems = await _dataRepository.getCalendarItems();
            var CalendarItemsByMonth = calendarItems.Where(item => item.Date.Month == month).ToList();
            if(CalendarItemsByMonth != null)
                return CalendarItemsByMonth;
            return null;

        }

        public async Task<Calendar> createCalendarEvent(Calendar calendarEvent)
        {
            var calendarItem = await _dataRepository.createCalendarEvent(calendarEvent);
            return calendarItem;
        }
        public async Task deleteEvents(int year)
        {
            await _dataRepository.deleteEvents(year);
            return;
        }
    }
}