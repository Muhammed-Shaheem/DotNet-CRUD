using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RPDemo.Models;
using ShaheemsDinerLibrary.Data;
using ShaheemsDinerLibrary.Model;
using System.Threading.Tasks;

namespace RPDemo.Pages.Orders;

public class DisplayModel : PageModel
{
    private readonly IFoodData foodData;
    private readonly IOrderData orderData;

    public List<SelectListItem> foodList = new();
    [BindProperty(SupportsGet = true)]
    public int Id { get; set; }
    public string? ItemPurchased { get; set; }

    public OrderModel? Order { get; set; }
    [BindProperty]
    public UpdateOrderName UpdateOrder { get; set; }
    public DisplayModel(IFoodData foodData, IOrderData orderData)
    {
        this.foodData = foodData;
        this.orderData = orderData;
    }

    public async Task<IActionResult> OnGet()
    {
        Order = await orderData.GetOrderById(Id);

        if (Order is not null)
        {
            var food = await foodData.GetFood();

            ItemPurchased = food.Where(x => x.Id == Order.FoodId).FirstOrDefault()?.Title;
        }

        
        return Page();
    }

    public async Task<IActionResult> OnPost()
    {
        await orderData.UpdateOrderName(UpdateOrder.OrderId,UpdateOrder.OrderName);
        return RedirectToPage("./Display", new { Id });
    }
}
