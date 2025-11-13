using ShaheemsDinerLibrary.Model;

namespace MVCDemoApp.Models;

public class DisplayOrderModel
{
    public OrderModel Order { get; set; } = new();
    public string? ItemPurchased { get; set; }

}
