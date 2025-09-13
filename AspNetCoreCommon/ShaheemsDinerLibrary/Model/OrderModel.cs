using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ShaheemsDinerLibrary.Model;

public class OrderModel
{
    public int Id { get; set; }
    [Required]
    [MaxLength(20, ErrorMessage = "You can only enter up to 20 characters maximum")]
    [MinLength(3, ErrorMessage = "You should atleat enter 3 characters")]
    [DisplayName("Name of the order")]
    public string OrderName { get; set; }


    public DateTime OrderDate { get; set; } = DateTime.UtcNow;

    [DisplayName("Meal")]
    [Range(1, int.MaxValue, ErrorMessage = "You need to select a meal from the list")]
    public int FoodId { get; set; }

    [Required]
    [Range(1, 10, ErrorMessage = "you can select up to 10 meals")]
    public int Quantity { get; set; }

    public decimal Total { get; set; }
}
