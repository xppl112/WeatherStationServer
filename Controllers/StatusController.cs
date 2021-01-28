using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WeatherStationServer.Models;

namespace WeatherStationServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusController : ControllerBase
    {
        private readonly ILogger<StatusController> _logger;

        public StatusController(ILogger<StatusController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public string Get()
        {
            return "Ready";
        }

        [HttpPost]
        public string Post(HealthcheckStatus state)
        {
            return "OK";
        }
    }
}
