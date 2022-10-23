using HttpClientTest.Models;
using HttpClientTest.Repository;
using Newtonsoft.Json;

namespace HttpClientTest.Services
{
    public class DataService : IDataService
    {
        private HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private readonly IDataRepo _repo;

        public DataService(HttpClient httpClient, IConfiguration configuration, IDataRepo repo)
        {
            _httpClient= httpClient;
            _configuration = configuration;
            _repo = repo;
        }

        public async Task<DrinkData> GetCockTailByName()
        {
            //Api Key
            var RapidApiKey = _configuration["CockTailDb:Apikey"];
            var RapidApiHost = _configuration["CockTailDb:ApiHost"];
            //Api Uri
            string apiUri = _configuration["CockTailDb:ApiUrl"];

            //Headers
            _httpClient.DefaultRequestHeaders.Add("X-RapidAPI-Key", RapidApiKey);
            _httpClient.DefaultRequestHeaders.Add("X-RapidAPI-Host", RapidApiHost);
            //Send Request
            var response = await _httpClient.GetAsync(apiUri);

            if (response.IsSuccessStatusCode) 
            {
                var result = await response.Content.ReadAsStringAsync();
                var drinkList = JsonConvert.DeserializeObject<DrinkData>(result);

                //Create drin list and return it
                await _repo.CreateDrinks(drinkList);
                return drinkList;
            }
            else 
            {
                return null;
            }
        }

        // public async Task<PredictionsModel> GetPredictions()
        // {
        //     //Api Key
        //     var RapidApiKey = _configuration["ApiFootballKeys:Apikey"];
        //     var RapidApiHost = _configuration["ApiFootballKeys:ApiHost"];
        //     //Api Uri
        //     string apiUri = _configuration["ApiFootballKeys:PredictionsUrl"];

        //     //Headers
        //     _httpClient.DefaultRequestHeaders.Add("X-RapidAPI-Key", RapidApiKey);
        //     _httpClient.DefaultRequestHeaders.Add("X-RapidAPI-Host", RapidApiHost);
        //     // _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Authorization", apiKey);
        //     //Send Request
        //     var response = await _httpClient.GetFromJsonAsync<PredictionsModel>(apiUri);
            
        //     return response;
        // }
    }
}