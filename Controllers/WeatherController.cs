using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using WeatherStationServer.Contracts;
using WeatherStationServer.DomainServices;

namespace WeatherStationServer.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class WeatherController : ControllerBase
    {
        private readonly ILogger<WeatherController> _logger;
        private readonly IReportsRepository ReportsRepository;
        private readonly NightTimeConfiguration _nightTimeConfiguration;
        private readonly OverseasMonitorConfiguration _overseasMonitorConfiguration;
        private readonly GermanyMonitorConfiguration _germanyMonitorConfiguration;

        public WeatherController(IReportsRepository reportsRepository, ILogger<WeatherController> logger, IConfiguration configuration)
        {
            ReportsRepository = reportsRepository;
            _logger = logger;
            _nightTimeConfiguration = configuration.GetSection("NightTimeConfiguration").Get<NightTimeConfiguration>();
            _overseasMonitorConfiguration = configuration.GetSection("OverseasMonitorConfiguration").Get<OverseasMonitorConfiguration>();
            _germanyMonitorConfiguration = configuration.GetSection("GermanyMonitorConfiguration").Get<GermanyMonitorConfiguration>();
        }

        [HttpPost]
        public async Task<OutdoorWeatherReportResponse> PostOutdoorReport(OutdoorWeatherReport report)
        {
            var result = await ReportsRepository.StoreOutdoorWeatherReport(report);

            return new OutdoorWeatherReportResponse
            {
                CurrentTimeStamp = TimeInfoProvider.GetCurrentTimestamp(),
                IsNightMode = TimeInfoProvider.IsNightTime(_nightTimeConfiguration)
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
                IsNightMode = TimeInfoProvider.IsNightTime(_nightTimeConfiguration)
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


        [HttpPost]
        public async Task<OverseasWeatherReportResponse> PostOverseasReport(OverseasWeatherReport report)
        {
            var result = await ReportsRepository.StoreOverseasWeatherReport(report);

            return new OverseasWeatherReportResponse
            {
                SleepDurationSeconds = _overseasMonitorConfiguration.SleepDurationSeconds
            };
        }


        [HttpPost]
        public async Task<OverseasWeatherDataItem> PostOverseasIndoorReport([FromBody]OverseasWeatherIndoorReport report)
        {
            var result = await ReportsRepository.StoreOverseasWeatherIndoorReport(report);

            var data = ReportsRepository.GetLastOverseasOutdoorReports(1);
            
            data.ForEach(r =>
            {
                r.Pressure = (float)Math.Round(r.Pressure - 1000, 1);
            });

            return data.FirstOrDefault();
        }

        [HttpGet]
        public OverseasWeatherIndoorResponse GetOverseasData([FromQuery] int c = 30)
        {
            var currentTimeStamp = new DateTimeOffset(DateTime.Now).ToUnixTimeSeconds();

            var data = ReportsRepository.GetLastOverseasOutdoorReports(c);
            data.ForEach(r =>
            {
                r.Pressure = (float)Math.Round(r.Pressure - 1000, 1);
            });

            return new OverseasWeatherIndoorResponse
            {
                CurrentTimeStamp = currentTimeStamp,
                Data = data
            };
        }


        [HttpPost]
        public async Task<GermanyWeatherReportResponse> PostGermanyReport(GermanyWeatherReport report)
        {
            var result = await ReportsRepository.StoreGermanyWeatherReport(report);

            return new GermanyWeatherReportResponse
            {
                SleepDurationSeconds = _germanyMonitorConfiguration.SleepDurationSeconds,
                MeasureAirQualityCycle = _germanyMonitorConfiguration.MeasureAirQualityCycle,
                AirQualityMeasurementDurationSeconds = _germanyMonitorConfiguration.AirQualityMeasurementDurationSeconds
            };
        }
    }
}
