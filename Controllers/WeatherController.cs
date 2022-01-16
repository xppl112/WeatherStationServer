using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WeatherStationServer.Contracts;
using WeatherStationServer.DomainServices;
using WeatherStationServer.Repositories;

namespace WeatherStationServer.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class WeatherController : ControllerBase
    {
        private readonly ILogger<WeatherController> _logger;
        private readonly IReportsRepository ReportsRepository;

        public WeatherController(IReportsRepository reportsRepository, ILogger<WeatherController> logger)
        {
            ReportsRepository = reportsRepository;
            _logger = logger;
        }

        [HttpPost]
        public async Task<OutdoorWeatherReportResponse> PostOutdoorReport(OutdoorWeatherReport report)
        {
            var result = await ReportsRepository.StoreOutdoorWeatherReport(report);

            return new OutdoorWeatherReportResponse
            {
                CurrentTimeStamp = TimeInfoProvider.GetCurrentTimestamp(),
                IsNightMode = TimeInfoProvider.IsNightTime()
            };
        }


        [HttpPost]
        public async Task<OutdoorWeatherReportResponse> PostOutdoorReportsBatch(OutdoorWeatherReport[] reports)
        {
            foreach (var report in reports)
            {
                var result = await ReportsRepository.StoreOutdoorWeatherReport(report);
            }

            return new OutdoorWeatherReportResponse
            {
                CurrentTimeStamp = TimeInfoProvider.GetCurrentTimestamp(),
                IsNightMode = TimeInfoProvider.IsNightTime()
            };
        }

        [HttpGet]
        public string GetLastData(int c = 30)
        {
            var currentTimeStamp = new DateTimeOffset(DateTime.Now).ToUnixTimeSeconds();

            var data = ReportsRepository.GetLastReports(c);
            data.ForEach(r =>
            {
                r.TimeStamp = currentTimeStamp - r.TimeStamp;
                r.Pressure = (float)Math.Round(r.Pressure - 1000, 1);
            });

            GetLastDataResponse response = new GetLastDataResponse
            {
                CurrentTimeStamp = currentTimeStamp,
                Data = data
            };

            return JsonConvert.SerializeObject(response);
        }
    }
}
