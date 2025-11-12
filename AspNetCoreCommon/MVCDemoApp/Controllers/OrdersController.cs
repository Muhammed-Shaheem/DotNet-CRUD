using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVCDemoApp.Models;
using ShaheemsDinerLibrary.Data;
using ShaheemsDinerLibrary.Model;
using System.Threading.Tasks;

namespace MVCDemoApp.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IOrderData orderData;
        private readonly IFoodData foodData;

       

        public OrdersController(IOrderData orderData, IFoodData foodData)
        {
            this.orderData = orderData;
            this.foodData = foodData;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Create()
        {
            var foodMenu = await foodData.GetFood();
            CreateOrderModel model = new();
            foodMenu.ForEach(x => model.FoodItems.Add(new SelectListItem() { Text = x.Title, Value = x.Id.ToString() }));

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(OrderModel order)
        {
            if (ModelState.IsValid == false)
            {
                return View();
            }
            var food = await foodData.GetFood();

            var price = food.Where(x => x.Id == order.FoodId).First().Price;
            order.Total = order.Quantity * price;

            int id = await orderData.CreateOrder(order);

            return RedirectToAction("Create"); 
        }


    }
}
