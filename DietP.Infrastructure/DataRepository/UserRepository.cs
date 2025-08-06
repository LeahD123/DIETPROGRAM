using Microsoft.EntityFrameworkCore;
using DietP.Core.Entities;
using DietP.Core.Repositories;

namespace DietP.Infrastructure.DataRepository
{
    public partial class DataRepository : IDataRepository
    {
        public async Task<List<User>> GetAllUsers()
        {
            var users = _dbContext.User.ToListAsync();
            if(users == null)
            {
                throw new Exception("the list is null");
            }
            return await users;
        }
        public async Task<User?> GetUser(int id)
        {
            return await _dbContext.User.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<User> AddUser(User user)
        {
            _dbContext.User.Add(user);
            await _dbContext.SaveChangesAsync();
            return user;
        }

        public async Task<User> UpdateUser(User user)
        {
            //whats going on?
            var entity = await _dbContext.User.Where(x => x.Id == user.Id).FirstAsync();
            _dbContext.Entry(entity).CurrentValues.SetValues(user);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<User> DeleteUser(int userId)
        {
            var entity = await _dbContext.User.Where(x => x.Id == userId).FirstAsync();
            _dbContext.User.Remove(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }
    }
}
