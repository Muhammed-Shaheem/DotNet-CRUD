using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace ShaheemsDinerLibrary.Db;


public class SqlDb : IDataAccess
{
    private readonly IConfiguration config;

    public SqlDb(IConfiguration config)
    {
        this.config = config;
    }

    public List<T> LoadData<T, U>(string storedProcedure, U parameters, string connectionStringName, bool isStoreProcedure)
    {
        var connectionString = config.GetConnectionString(connectionStringName);

        using (IDbConnection db = new SqlConnection(connectionString))
        {
            return db.Query<T>(storedProcedure, parameters, commandType: CommandType.StoredProcedure).ToList();
        }
    }

    public void SaveData<T>(string StoredProcedure, T parameters, string connectionStringName)
    {
        var connectionString = config.GetConnectionString(connectionStringName);
        using (IDbConnection db = new SqlConnection(connectionString))
        {
            db.Execute(StoredProcedure, parameters, commandType: CommandType.StoredProcedure);
        }
    }
}
