using DietP.Core.Entities;
using DietP.Core.Repositories;
using DietP.Core.Services;

namespace DietP.Service.Services
{
    public class FoodsItemService : IFoodsItemService
    {
        private readonly IDataRepository _dataRepository;
        public FoodsItemService(IDataRepository dataRepository)
        {
            _dataRepository = dataRepository;
        }
        //מביא את הדבר מאכל לפי ערך קלורי וקטגוריה
        public async Task<List<FoodsItem>?> GetByCategoryAndCalories(string category, int calories)
        {
            var allFoodItems = await _dataRepository.GetAllFoodsItems();
            if(allFoodItems == null)
            {
                throw new Exception("foodsItem table is null!");
            }
            var foodsItems =  allFoodItems?.Where(foodsItem => foodsItem.calories <= calories && foodsItem.category == category).ToList();
            if(foodsItems == null)
            {
                throw new Exception("the list is null!");
            }
            return foodsItems;

        }
        //מוסיף דבר מאכל
        public async Task<FoodsItem> AddFoodItem(FoodsItem foodsItem)
        {
            return await _dataRepository.AddFoodItem(foodsItem);
        }
        //מעדכן דבר מאכל לפי שם, כמות קלוריות וקטגוריה
        public async Task<FoodsItem> UpdateFoodItem(string name, string category, int cal, string newName, string newCategory, int newCal)
        {
            var allFoodItems = await _dataRepository.GetAllFoodsItems();
            if (allFoodItems == null)
            {
                throw new Exception("the list is null!");
            }
            FoodsItem? foodItem = allFoodItems
                .FirstOrDefault(item => item.name == name && item.category == category && item.calories == cal);

            if (foodItem == null)
            {
                throw new Exception("Food item not found.");
            }
            foodItem.name = newName;
            foodItem.category = newCategory;
            foodItem.calories = newCal;
            return await _dataRepository.UpdateFoodItem(foodItem);
        }

        //מוחק דבר מאכל לפי שם
        public async Task<FoodsItem> DeleteFoodItem(string name)
        {
            var allFoodsItems = await _dataRepository.GetAllFoodsItems();
            if (allFoodsItems == null)
            {
                throw new Exception("the list is null!");
            }
            FoodsItem? entity  = allFoodsItems.FirstOrDefault(foodsItem => foodsItem.name == name);
            if (entity == null)
            {
                throw new Exception("foods item not found");
            }
            return await _dataRepository.DeleteFoodItem(entity.id);
        }
    }
}
