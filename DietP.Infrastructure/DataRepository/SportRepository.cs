using Microsoft.EntityFrameworkCore;
using DietP.Core.Entities;
using DietP.Core.Repositories;

namespace DietP.Infrastructure.DataRepository
{
    public partial class DataRepository : IDataRepository
    {
        public async Task<List<Sport>?> GetAllSports()
        {
            return await _dbContext.Sport.ToListAsync();
        }
        public async Task<Sport?> GetSport(int id)
        {
            return await _dbContext.Sport.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Sport> AddSport(Sport sport)
        {
            _dbContext.Sport.Add(sport);
            await _dbContext.SaveChangesAsync();
            return sport;   
        }

        public async Task<Sport> UpdateSport(Sport sport)
        {
            var entity = await _dbContext.Sport.Where(x => x.Id == sport.Id).FirstAsync();
            _dbContext.Entry(entity).CurrentValues.SetValues(sport);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<Sport> DeleteSport(int sportId)
        {
            var entity = await _dbContext.Sport.Where(x => x.Id == sportId).FirstAsync();
            _dbContext.Sport.Remove(entity); 
            await _dbContext.SaveChangesAsync();
            return entity;
        }


    }
}
