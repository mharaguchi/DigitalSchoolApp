using Microsoft.AspNetCore.Mvc;
using DigitalSchoolApi.Core;
using DigitalSchoolApi.Core.Models;

namespace DigitalSchoolApi.Controllers
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
        private readonly IDigitalSchoolApiManager _manager;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IDigitalSchoolApiManager manager)
        {
            _logger = logger;
            _manager = manager;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet]
        [Route("[action]")]
        public IActionResult GetTestName()
        {
            return Ok(_manager.GetTestNameAsync().Result);
        }
    }
}
