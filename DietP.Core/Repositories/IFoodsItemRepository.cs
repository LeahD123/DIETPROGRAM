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
        Task<List<FoodsItem>?> GetAllFoodsItems();
        Task<FoodsItem?> GetFoodsItem(int id);
        Task<FoodsItem> AddFoodItem(FoodsItem foodsItem);
        Task<FoodsItem>? UpdateFoodItem(FoodsItem foodsItem);
        Task<FoodsItem> DeleteFoodItem(int id);
    }
}

