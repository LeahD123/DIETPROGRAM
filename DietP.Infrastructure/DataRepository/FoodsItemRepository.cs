using DietP.Core.Entities;
using DietP.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DietP.Infrastructure.DataRepository
{
    public partial class DataRepository : IDataRepository
    {
        public async Task<List<FoodsItem>?> GetAllFoodsItems()
        {
            return await _dbContext.FoodsItem.ToListAsync();
        }
        public async Task<FoodsItem?> GetFoodsItem(int id)
        {
            return await _dbContext.FoodsItem.Where(x => x.id == id).FirstOrDefaultAsync();
        }

        public async Task<FoodsItem> AddFoodItem(FoodsItem foodsItem)
        {
            _dbContext.FoodsItem.Add(foodsItem);
            await _dbContext.SaveChangesAsync();
            return foodsItem ;
        }

        public async Task<FoodsItem>? UpdateFoodItem(FoodsItem foodsItem)
        {
            var entity = await _dbContext.FoodsItem.Where(x => x.id == foodsItem.id).FirstAsync();
            _dbContext.Entry(entity).CurrentValues.SetValues(foodsItem);
            await _dbContext.SaveChangesAsync();
            return foodsItem ;
        }

        public async Task<FoodsItem> DeleteFoodItem(int foodItemId)
        {
            var entity = await _dbContext.FoodsItem.Where(x => x.id == foodItemId).FirstAsync();
            _dbContext.FoodsItem.Remove(entity);
            await _dbContext.SaveChangesAsync();
            return entity ;
        }

    }
}

