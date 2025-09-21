using ShaheemsDinerLibrary.Db;
using ShaheemsDinerLibrary.Model;

namespace ShaheemsDinerLibrary.Data;

public class FoodData : IFoodData
{
    private readonly IDataAccess dataAccess;
    private readonly ConnectionStringName connectionStringName;

    public FoodData(IDataAccess dataAccess, ConnectionStringName connectionStringName)
    {
        this.dataAccess = dataAccess;
        this.connectionStringName = connectionStringName;
    }

    public Task<List<FoodModel>> GetFood()
    {
        return dataAccess.LoadData<FoodModel, dynamic>("spFood_All", new { }, connectionStringName.SqlConnection);
    }

  


}
