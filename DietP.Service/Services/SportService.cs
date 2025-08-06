using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DietP.Core.Repositories;
using DietP.Core.Entities;
using DietP.Core.Services;

namespace DietP.Service.Services
{
    public class SportService:ISportService
    {
        private readonly IDataRepository _dataRepository;
        public SportService(IDataRepository dataRepository)
        {
            _dataRepository = dataRepository;
        }
        //מביא פעילות ספורטיבית לפי איבוד קלוריות פר שעה
        public async Task<List<Sport>?> GetByLoseCal(int cal)
        {
            var allSports = await _dataRepository.GetAllSports(); 
            // מחזיר אם ערך הקלוריות שווה לערך הקלוריות הנאבדות בפעילות או כאשר הכמות גדולה עד חמישים מכמות הקלוריות הנתונה
            return allSports?.Where(sport => sport.LoseCalPerHour == cal || sport.LoseCalPerHour > cal && sport.LoseCalPerHour - 50 <= cal).ToList(); // משתמש ב-Where לאחר קבלת התוצאה
        }
        public async Task<Sport> UpdateSport(string name, string description, string type, int LoseCalPerHour, string newName, string newDescription, string newType, int newLoseCalPerHour)
        {
            var allSports = await _dataRepository.GetAllSports();
            if (allSports == null)
            {
                throw new Exception("the list is null!");
            }
            Sport? sport = allSports.FirstOrDefault(sport =>  sport.Name == name && sport.Type == type && sport.Description == description && sport.LoseCalPerHour == LoseCalPerHour);
            if (sport == null)
            {
                throw new Exception("Sport is not found");
            }
            sport.LoseCalPerHour = newLoseCalPerHour;
            sport.Name = newName;
            sport.Description = newDescription;
            sport.Type = newType;
            return await _dataRepository.UpdateSport(sport);
        }
        public async Task<Sport> AddSport(Sport sport)
        {
            return await _dataRepository.AddSport(sport);
        }
        public async Task<Sport> DeleteSport(string name)
        {
            var allSports = await _dataRepository.GetAllSports();
            if(allSports == null)
            {
                throw new Exception("the list is null!");
            }
            Sport? sport = allSports.FirstOrDefault(sport => sport.Name == name);
            if (sport == null) {
                throw new Exception("sport is not found!");
            }
            return await _dataRepository.DeleteSport(sport.Id);
        }
    }
}