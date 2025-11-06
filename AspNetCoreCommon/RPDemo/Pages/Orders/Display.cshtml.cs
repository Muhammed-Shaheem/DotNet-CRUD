using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
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

    public OrderModel? Order { get; set; };
    [BindProperty]
    public int FoodId { get; set; }
    public DisplayModel(IFoodData foodData, IOrderData orderData)
    {
        this.foodData = foodData;
        this.orderData = orderData;
    }

    public async Task<IActionResult> OnGet()
    {
        Order = await orderData.GetOrderId(Id);

        if (Order is not null)
        {
            var food = await foodData.GetFood();

            ItemPurchased = food.Where(x => x.Id == Order.FoodId).FirstOrDefault()?.Title;
        }
        var foods = await foodData.GetFood();
        foreach (var food in foods)
        {
            foodList.Add(new SelectListItem { Text = food.Title, Value = food.Id.ToString() });
        }
        return Page();
    }

    public async Task<IActionResult> OnPost()
    {
        await orderData.UpdateOrderName(FoodId, Order.OrderName);
        return RedirectToPage("./Display", new { Id = Id });
    }
}
