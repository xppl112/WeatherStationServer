using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WeatherStationServer.Models;

namespace WeatherStationServer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherController : ControllerBase
    {
        private readonly ILogger<WeatherController> _logger;

        public WeatherController(ILogger<WeatherController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public string Post(WeatherState state)
        {
            return "OK";
        }
    }
}
