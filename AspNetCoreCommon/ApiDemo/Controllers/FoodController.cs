using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShaheemsDinerLibrary.Data;
using System.Threading.Tasks;

namespace ApiDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodController : ControllerBase
    {
        private readonly IFoodData foodData;

        public FoodController(IFoodData foodData)
        {
            this.foodData = foodData;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
           var food = await foodData.GetFood();

            return Ok(food);
            
        }
    }
}
