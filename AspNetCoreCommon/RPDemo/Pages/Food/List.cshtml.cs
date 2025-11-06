using Microsoft.AspNetCore.Mvc.RazorPages;
using ShaheemsDinerLibrary.Data;
using ShaheemsDinerLibrary.Model;
using System.Threading.Tasks;

namespace RPDemo.Pages.Food;

public class ListModel : PageModel
{
    private readonly IFoodData foodData;
    public List<FoodModel> Foods;

    public ListModel(IFoodData foodData)
    {
        this.foodData = foodData;
    }
    public async Task OnGet()
    {
        Foods = await foodData.GetFood();

    }
}
