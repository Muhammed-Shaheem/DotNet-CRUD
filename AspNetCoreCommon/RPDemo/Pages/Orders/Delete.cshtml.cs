using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShaheemsDinerLibrary.Data;
using ShaheemsDinerLibrary.Model;
using System.Threading.Tasks;

namespace RPDemo.Pages.Orders;

public class DeleteModel : PageModel
{
    private readonly IOrderData orderData;

    public DeleteModel(IOrderData orderData)
    {
        this.orderData = orderData;
    }

    [BindProperty(SupportsGet = true)]
    public int Id { get; set; }
    public OrderModel? Order { get; private set; }

    public async Task OnGet()
    {
       Order = await orderData.GetOrderById(Id);
    }

    public async Task<IActionResult> OnPost()
    {
      await orderData.DeletOrder(Id);

        return RedirectToPage("./Create");

    }
}
