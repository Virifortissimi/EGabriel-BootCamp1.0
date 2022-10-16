using HttpClientTest.Models;

namespace HttpClientTest.Services
{
    public interface IDataService
    {
        Task<DrinkData> GetCockTailByName();
    }
}