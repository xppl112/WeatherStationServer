﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WeatherStationServer.Contracts;
using WeatherStationServer.DomainServices;

namespace WeatherStationServer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TimeController : ControllerBase
    {
        private readonly ILogger<TimeController> _logger;

        public TimeController(ILogger<TimeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public long Get()
        {
            return TimeInfoProvider.GetCurrentTimestamp();
        }

        [HttpPost]
        public GetServerDataResponse GetServerData(int testEcho, string testString)
        {
            return new GetServerDataResponse {
                Timestamp = TimeInfoProvider.GetCurrentTimestamp(),
                TestEcho = testEcho,
                TestString = testString
            };
        }
    }
}
