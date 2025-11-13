using ShaheemsDinerLibrary.Model;

namespace MVCDemoApp.Models;

public class DisplayOrderModel
{
    public OrderModel Order { get; set; } = new();
    public string? ItemPurchased { get; set; }

    public int OrderId { get; set; }
    public string OrderName { get; set; }
}
