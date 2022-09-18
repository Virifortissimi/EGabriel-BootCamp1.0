using searchApp.Domain;

namespace searchApp.Service
{
    public class SearchService : ISearchService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;


        public SearchService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }


        public async Task<ImageResponse> GetImages()
        {
             //Api Key
            var RapidApiKey = _configuration["ApiSearchKeys:ApiKey"];
            var RapidApiHost = _configuration["ApiSearchKeys:ApiHost"];
            //Api Uri
            string apiUri = "https://google-search3.p.rapidapi.com/api/v1/image/q=tesla";

            //Headers
            _httpClient.DefaultRequestHeaders.Add("X-RapidAPI-Key", RapidApiKey);
            _httpClient.DefaultRequestHeaders.Add("X-RapidAPI-Host", RapidApiHost);


            //Send Request
            var response = await _httpClient.GetAsync(apiUri);

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<ImageResponse>(result);
            }
            else
            {
                return null;
            }
        }
        
        public async Task<NewsResponse> GetNews() 
        { 
             //Api Key
            var RapidApiKey = _configuration["ApiSearchKeys:ApiKey"];
            var RapidApiHost = _configuration["ApiSearchKeys:ApiHost"];

            //Api Uri
            string apiUri = "https://google-search3.p.rapidapi.com/api/v1/news/q=president+united+states";

            //Headers
            _httpClient.DefaultRequestHeaders.Add("X-RapidAPI-Key", RapidApiKey);
            _httpClient.DefaultRequestHeaders.Add("X-RapidAPI-Host", RapidApiHost);


            //Send Request
            var response = await _httpClient.GetAsync(apiUri);

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<NewsResponse>(result);
            }
            else
            {
                return null;
            }
        }

        public async Task<ScholarResponse> GetScholars() 
        {
            //Api Key
            var RapidApiKey = _configuration["ApiSearchKeys:ApiKey"];
            var RapidApiHost = _configuration["ApiSearchKeys:ApiHost"];

            //Api Uri
            string apiUri = "https://google-search3.p.rapidapi.com/api/v1/scholar/q=high+frequency+trading";

            //Headers
            _httpClient.DefaultRequestHeaders.Add("X-RapidAPI-Key", RapidApiKey);
            _httpClient.DefaultRequestHeaders.Add("X-RapidAPI-Host", RapidApiHost);


            //Send Request
            var response = await _httpClient.GetAsync(apiUri);

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<ScholarResponse>(result);
            }
        }

        public async Task<SearchResponse> GetSearch() 
        { 
            //Api Key
            var RapidApiKey = _configuration["ApiSearchKeys:ApiKey"];
            var RapidApiHost = _configuration["ApiSearchKeys:ApiHost"];
            
            //Api Uri
            string apiUri = "https://google-search3.p.rapidapi.com/api/v1/search/q=elon+musk";

            //Headers
            _httpClient.DefaultRequestHeaders.Add("X-RapidAPI-Key", RapidApiKey);
            _httpClient.DefaultRequestHeaders.Add("X-RapidAPI-Host", RapidApiHost);


            //Send Request
            var response = await _httpClient.GetAsync(apiUri);

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<SearchResponse>(result);
            }
            else
            {
                return null;
            }
        }

        public async Task<VideoResponse> GetVideos() 
        {
            //Api Key
            var RapidApiKey = _configuration["ApiSearchKeys:ApiKey"];
            var RapidApiHost = _configuration["ApiSearchKeys:ApiHost"];

            //Api Uri
            string apiUri = "https://google-search3.p.rapidapi.com/api/v1/video/q=iphone+reviews";

            //Headers
            _httpClient.DefaultRequestHeaders.Add("X-RapidAPI-Key", RapidApiKey);
            _httpClient.DefaultRequestHeaders.Add("X-RapidAPI-Host", RapidApiHost);


            //Send Request
            var response = await _httpClient.GetAsync(apiUri);

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<VideoResponse>(result);
            }
            else
            {
                return null;
            }
        }      

        public async Task<Serp> AddSerp()
        { 
            //Api Key
            var RapidApiKey = _configuration["ApiSearchKeys:ApiKey"];
            var RapidApiHost = _configuration["ApiSearchKeys:ApiHost"];

            //Api Uri
            string apiUri = "https://google-search3.p.rapidapi.com/api/v1/crawl/q=best+iphone&num=100";


            //Serialize object to Json
            searchApp apiModel = new searchApp()
            {
                query = query,
                website = website,
                searched_results,
                position = position
            };

            var searchAppJson = JsonConvert.SerializedObject(apiModel);
            var data = new StringContent(searchAppJson, Encoding.UTF8, "application/json");

            //Headers
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


            //Semd Request

            var response = await _httpClient.PostAync(apiUri, data);

            if(response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Serp>(result);
            }
        }

    }
}
