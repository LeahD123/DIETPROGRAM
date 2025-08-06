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
        Task<List<Sport>?> GetAllSports();
        Task<Sport?> GetSport(int id);
        Task<Sport> AddSport(Sport sport);
        Task<Sport> UpdateSport(Sport sport);
        Task<Sport> DeleteSport(int id);
    }
}
