namespace HttpRequest
{
    public interface IWeatherService
    {
        Task<String> GetWeather(string cityName);
    }
    public class weatherServices : IWeatherService
    {
        private readonly HttpClient _httpClient;
        public weatherServices(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<String> GetWeather(string cityName)
        {
            var ApiKey = "4919859c229e43e18d8125218222509";
            String ApiUrl = $"?Key={ApiKey}&q={cityName}";
            var response = await _httpClient.GetAsync(ApiUrl);
            return await response.Content.ReadAsStringAsync();
        }
    }
}
