using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DietP.Core.Entities;

namespace DietP.Core.Repositories
{
    public partial interface IDataRepository
    {
        Task<List<Calendar>?> getCalendarItems();
        Task<Calendar> createCalendarEvent(Calendar calendarEvent);
        Task deleteEvents(int year);
    }
}
