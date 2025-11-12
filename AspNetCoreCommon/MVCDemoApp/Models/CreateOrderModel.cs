using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using ShaheemsDinerLibrary.Model;

namespace MVCDemoApp.Models;

public class CreateOrderModel
{
    public List<SelectListItem> FoodItems = new();
    public OrderModel Order { get; set; } = new();
}
