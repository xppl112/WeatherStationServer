using Newtonsoft.Json;

namespace WeatherStationServer.Contracts
{
    public class OverseasWeatherReportResponse
    {
        [JsonProperty("sds")]
        public int SleepDurationSeconds { get; set; }
    }
}
