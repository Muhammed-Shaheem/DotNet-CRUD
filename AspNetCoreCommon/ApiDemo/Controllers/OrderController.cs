using ApiDemo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShaheemsDinerLibrary.Data;
using ShaheemsDinerLibrary.Model;
using System.Threading.Tasks;

namespace ApiDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IFoodData foodData;
        private readonly IOrderData orderData;

        public OrderController(IFoodData foodData, IOrderData orderData)
        {
            this.foodData = foodData;
            this.orderData = orderData;
        }


        [HttpPost]
        [ValidateModel]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post(OrderModel order)
        {
            var food = await foodData.GetFood();

            var price = food.Where(x => x.Id == order.FoodId).First().Price;
            order.Total = order.Quantity * price;

            int id = await orderData.CreateOrder(order);

            return Ok(new { Id = id });

        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            var order = await orderData.GetOrderById(id);
            if (order is not null)
            {
                var food = await foodData.GetFood();

                var output = new
                {
                    Order = order,
                    ItemPurchased = food.Where(x => x.Id == order.FoodId).FirstOrDefault()?.Title
                };
                return Ok(output);
            }

            else
            {
                return NotFound(); 
            }
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Put([FromBody]OrderUpdateModel data)
        {
            await orderData.UpdateOrderName(data.Id, data.OrderName);

            return Ok();
        }
    }
}
