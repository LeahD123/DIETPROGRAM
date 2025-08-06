using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DietP.Core.Entities;
using DietP.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DietP.Infrastructure.DataRepository
{
    public partial class DataRepository:IDataRepository
    {
        public async Task<List<Calendar>?> getCalendarItems()
        {
            return await _dbContext.calendar.ToListAsync();
        }
        public async Task<Calendar> createCalendarEvent(Calendar calendarEvent)
        {
            _dbContext.Add(calendarEvent);
            await _dbContext.SaveChangesAsync();
            return calendarEvent;
        }
        public async Task deleteEvents(int year)
        {
            var calendarDeleteList = await _dbContext.calendar.Where(x => x.Date.Year != year).ToListAsync();
            for (int i = 0; i < calendarDeleteList.Count; i++)
            {
                _dbContext.Remove(calendarDeleteList[i]);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
