using ShaheemsDinerLibrary.Model;

namespace ShaheemsDinerLibrary.Data
{
    public interface IOrderData
    {
        Task<int> CreateOrder(OrderModel order);
        Task<int> DeletOrder(int id);
        Task<OrderModel?> GetOrderById(int id);
        Task<int> UpdateOrderName(int id, string orderName);
    }
}