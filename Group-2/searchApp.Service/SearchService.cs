using System.Text.Json;
using searchApp.Domain;
using searchApp.Repository;

namespace searchApp.Service
{
    public class SearchService : ISearchService
    {
        private readonly HttpClient _httpClient;
        private readonly IRepository<Search> _searchRepo;
        static string RapidApiKey = "24ecf45b76msh35fe8d4bbd80ae0p1a010ejsn3de804ad668f";
        static string RapidApiHost = "google-search3.p.rapidapi.com";


        public SearchService(HttpClient httpClient, IRepository<Search> searchRepo)
        {
            _httpClient = httpClient;
            _httpClient.DefaultRequestHeaders.Add("X-RapidAPI-Key", RapidApiKey);
            _httpClient.DefaultRequestHeaders.Add("X-RapidAPI-Host", RapidApiHost);
            _httpClient.DefaultRequestHeaders.Add("X-Proxy-Location", "EU" );
            _searchRepo = searchRepo;

        }

        public async Task<List<string>> GetSearch(string text)
        {
            Search search = _searchRepo.Get(text);
            if (search == null) 
            {   
                var apiUri = "https://" + RapidApiHost + "/api/v1/search/q=" + text.Trim().Replace(" ", "+");
                var response = await _httpClient.GetAsync(apiUri);

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    var searchResponse = JsonSerializer.Deserialize<SearchResponse>(result);
                    if(searchResponse != null && searchResponse.answers != null)
                    {
                        search = new Search {Text=text, Answer=searchResponse.answers};
                        await _searchRepo.Create(search);
                    }
                    
                }
            }
            return search.Answer;
        }
    }
}
