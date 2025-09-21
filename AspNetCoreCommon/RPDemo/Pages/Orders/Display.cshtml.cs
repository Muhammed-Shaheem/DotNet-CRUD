using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShaheemsDinerLibrary.Data;
using ShaheemsDinerLibrary.Model;
using System.Threading.Tasks;

namespace RPDemo.Pages.Orders;

public class DisplayModel : PageModel
{
    private readonly IFoodData foodData;
    private readonly IOrderData orderData;

    [BindProperty(SupportsGet = true)]
    public int Id { get; set; }

    public OrderModel? Order { get; set; }
    public DisplayModel(IFoodData foodData, IOrderData orderData)
    {
        this.foodData = foodData;
        this.orderData = orderData;
    }
    public string? ItemPurchased { get; set; }

    public async Task<IActionResult> OnGet()
    {
        Order = await orderData.GetOrderId(Id);

        if (Order is not null)
        {
            var food = await foodData.GetFood();

            ItemPurchased = food.Where(x => x.Id == Order.FoodId).FirstOrDefault()?.Title;
        }

        return Page();
    }
}
