using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DietP.Core.Entities;
using DietP.Core.Repositories;

namespace DietP.Core.Services
{
    public interface ISportService
    {
        Task<List<Sport>?> GetByLoseCal(int cal);

        Task<Sport> UpdateSport(string name, string description, string type, int LoseCalPerHour, string newName, string newDescription, string newType, int newLoseCalPerHour);

        Task<Sport> AddSport(Sport sport);

        Task<Sport> DeleteSport(string name);

        }
}
