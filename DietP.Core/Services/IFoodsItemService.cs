using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DietP.Core.Entities;
using DietP.Core.Repositories;

namespace DietP.Core.Services
{
    public interface IFoodsItemService
    {
        //מביא את הדבר מאכל לפי ערך קלורי וקטגוריה
        Task<List<FoodsItem>?> GetByCategoryAndCalories(string category, int calories);
        //מוסיף דבר מאכל
        Task<FoodsItem> AddFoodItem(FoodsItem foodsItem);
        //מעדכן דבר מאכל לפי שם, כמות קלוריות וקטגוריה
        Task<FoodsItem> UpdateFoodItem(string name, string category, int cal, string newName, string newCategory, int newCal);

        //מוחק דבר מאכל לפי שם
        Task<FoodsItem> DeleteFoodItem(string name);
    }
}
