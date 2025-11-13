using Microsoft.AspNetCore.Mvc;
using ShaheemsDinerLibrary.Data;
using ShaheemsDinerLibrary.Model;
using System.Threading.Tasks;

namespace MVCDemoApp.Controllers
{
    public class FoodController : Controller
    {
        private readonly IFoodData foodData;

        public FoodController(IFoodData foodData)
        {
            this.foodData = foodData;
        }

        public async Task<IActionResult> Index()
        {
            List<FoodModel> food = await foodData.GetFood();
            return View(food);
        }
    }
}
