using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Threading.Tasks;

namespace ShaheemsDinerLibrary.Db;


public class SqlDb : IDataAccess
{
    private readonly IConfiguration config;

    public SqlDb(IConfiguration config)
    {
        this.config = config;
    }

    public async Task<List<T>> LoadData<T, U>(string storedProcedure, U parameters, string connectionStringName)
    {
        var connectionString = config.GetConnectionString(connectionStringName);

        using (IDbConnection db = new SqlConnection(connectionString))
        {
            var rows = await db.QueryAsync<T>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);

            return rows.ToList();
        }
    }

    public async Task<int> SaveData<T>(string StoredProcedure, T parameters, string connectionStringName)
    {
        var connectionString = config.GetConnectionString(connectionStringName);
        using (IDbConnection db = new SqlConnection(connectionString))
        {
            return await db.ExecuteAsync(StoredProcedure, parameters, commandType: CommandType.StoredProcedure);
        }
    }
}
