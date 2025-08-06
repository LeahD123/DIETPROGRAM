using Microsoft.AspNetCore.Mvc;
using DietP.Core.Entities;
using DietP.Service.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using DietP.Core.Services;
namespace DietP.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodsItemController : ControllerBase
    {
        private readonly IFoodsItemService _foodsItemService;

        public FoodsItemController(IFoodsItemService foodsItemService)
        {
            _foodsItemService = foodsItemService;
        }


        // GET: api/foodsitem/category/{category}/calories/{calories}
        [HttpGet("category/{category}/calories/{calories}")]
        public async Task<ActionResult<List<FoodsItem>>> GetByCategoryAndCalories(string category, int calories)
        {
            try
            {
                var result = await _foodsItemService.GetByCategoryAndCalories(category, calories);
                if (result == null || !result.Any())
                {
                    return NotFound("No food items found for the specified category and calories.");
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
}
// POST: api/foodsitem
[HttpPost]
        public async Task<ActionResult<FoodsItem>> AddFoodItem([FromBody] FoodsItem foodsItem)
        {
            var result = await _foodsItemService.AddFoodItem(foodsItem);
            return CreatedAtAction(nameof(GetByCategoryAndCalories), new { category = foodsItem.category, calories = foodsItem.calories }, result);
        }

        // PUT: api/foodsitem
        [HttpPut]
        public async Task<ActionResult<FoodsItem>> UpdateFoodItem(string name, string category, int cal, string newName, string newCategory, int newCal)
        {
            try
            {
                var result = await _foodsItemService.UpdateFoodItem(name, category, cal, newName, newCategory, newCal);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        // DELETE: api/foodsitem/{name}
        [HttpDelete("{name}")]
        public async Task<ActionResult<FoodsItem>> DeleteFoodItem(string name)
        {
            try
            {
                var result = await _foodsItemService.DeleteFoodItem(name);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
