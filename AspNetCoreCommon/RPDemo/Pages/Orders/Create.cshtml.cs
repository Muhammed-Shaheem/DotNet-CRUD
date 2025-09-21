using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShaheemsDinerLibrary.Data;
using ShaheemsDinerLibrary.Model;

namespace RPDemo.Pages.Orders;

public class CreateModel : PageModel
{
    private readonly IOrderData orderData;
    private readonly IFoodData foodData;


    public List<SelectListItem> FoodItems;
    [BindProperty]
    public OrderModel Order { get; set; }

    public CreateModel(IOrderData orderData, IFoodData foodData)
    {
        this.orderData = orderData;
        this.foodData = foodData;
    }

    public async Task OnGetAsync()
    {
        await LoadFoodItems();

    }

    private async Task LoadFoodItems()
    {
        var foodMenu = await foodData.GetFood();

        FoodItems = new();

        foodMenu.ForEach(x =>
        {
            FoodItems.Add(new SelectListItem { Text = x.Title, Value = x.Id.ToString() });
        });
    }

    public async Task<IActionResult> OnPostAsync()
    {
        await LoadFoodItems();

        if (ModelState.IsValid == false)
        {
            return Page();
        }

        var food = await foodData.GetFood();
        var price = food.Where(x => x.Id == Order.FoodId).First().Price;

        Order.Total = Order.Quantity * price;  
        int id = await orderData.CreateOrder(Order);

        return RedirectToPage("./Display", new {Id = id});
    }
}
