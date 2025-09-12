
namespace ShaheemsDinerLibrary.Db
{
    public interface IDataAccess
    {
        Task<List<T>> LoadData<T, U>(string storedProcedure, U parameters, string connectionStringName);
        Task<int> SaveData<T>(string StoredProcedure, T parameters, string connectionStringName);
    }
}