using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DietP.Core.Entities;

namespace DietP.Core.Services
{
    public interface ICalendarService
    {
        Task<List<Calendar>?> getCalendarItemsByMonth(int month);
        Task<Calendar> createCalendarEvent(Calendar calendarEvent);
        Task deleteEvents(int year);
    }
}
