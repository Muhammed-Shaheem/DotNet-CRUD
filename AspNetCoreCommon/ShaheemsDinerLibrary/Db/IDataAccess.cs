
namespace ShaheemsDinerLibrary.Db
{
    public interface IDataAccess
    {
        List<T> LoadData<T, U>(string storedProcedure, U parameters, string connectionStringName, bool isStoreProcedure);
        void SaveData<T>(string StoredProcedure, T parameters, string connectionStringName);
    }
}