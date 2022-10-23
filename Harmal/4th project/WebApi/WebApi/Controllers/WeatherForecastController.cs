using Microsoft.AspNetCore.Mvc;

namespace HttpRequest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly weatherServices _Weatherservice;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, weatherServices weatherServices)
        {
            _logger = logger;
            _Weatherservice = weatherServices;
        }

        [HttpGet(Name = "GetWeatherForecast")]
      public async Task<String> Get(String cityName)
        {
                return await _Weatherservice.GetWeather(cityName);
        }
    }
}