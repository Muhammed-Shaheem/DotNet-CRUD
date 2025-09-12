using Dapper;
using ShaheemsDinerLibrary.Db;
using ShaheemsDinerLibrary.Model;
using System.Data;
using System.Threading.Tasks;

namespace ShaheemsDinerLibrary.Data;

public class OrderData : IOrderData
{
    private readonly IDataAccess dataAccess;
    private readonly ConnectionStringName connectionStringName;

    public OrderData(IDataAccess dataAccess, ConnectionStringName connectionStringName)
    {
        this.dataAccess = dataAccess;
        this.connectionStringName = connectionStringName;
    }

    public async Task<int> CreateOrder(OrderModel order)
    {
        DynamicParameters p = new();

        p.Add("orderName", order.OrderName);
        p.Add("orderDate", order.OrderDate);
        p.Add("foodId", order.FoodId);
        p.Add("quantity", order.Quantity);
        p.Add("total", order.Total);
        p.Add("id", DbType.Int32, direction: ParameterDirection.Output);

        await dataAccess.SaveData("spOrdersInsert", p, connectionStringName.SqlConnection);

        return p.Get<int>("id");
    }

    public Task<int> UpdateOrderName(int id, string orderName)
    {
        return dataAccess.SaveData("spOrders_UpdateName", new { id, orderName }, connectionStringName.SqlConnection);

    }
    public Task<int> DeletOrder(int id)
    {
        return dataAccess.SaveData("spOrders_Delete", new { id }, connectionStringName.SqlConnection);

    }

    public async Task<OrderModel?> GetOrderId(int id)
    {
        List<OrderModel> rows = await dataAccess.LoadData<OrderModel, dynamic>("spOrders_GetById", new { id }, connectionStringName.SqlConnection);
        return rows.FirstOrDefault();

    }
}
