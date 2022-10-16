using HttpClientTest.Models;

namespace HttpClientTest.Repository
{
    public interface IDataRepo
    {
         Task CreateDrinks(DrinkData model);
         Task<List<DrinkModel>> GetDrinks();
    }
}