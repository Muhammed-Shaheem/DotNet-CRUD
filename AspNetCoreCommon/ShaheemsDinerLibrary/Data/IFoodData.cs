using ShaheemsDinerLibrary.Model;

namespace ShaheemsDinerLibrary.Data
{
    public interface IFoodData
    {
        Task<List<FoodModel>> GetFood();
    }
}