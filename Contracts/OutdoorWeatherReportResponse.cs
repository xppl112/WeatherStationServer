using Newtonsoft.Json;

namespace WeatherStationServer.Contracts
{
    public class OutdoorWeatherReportResponse
    {
        [JsonProperty("ts")]
        public long CurrentTimeStamp { get; set; }

        [JsonProperty("nm")]
        public bool IsNightMode { get; set; }
    }
}
