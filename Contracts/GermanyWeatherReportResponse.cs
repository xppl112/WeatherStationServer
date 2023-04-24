using Newtonsoft.Json;

namespace WeatherStationServer.Contracts
{
    public class GermanyWeatherReportResponse
    {
        [JsonProperty("sds")]
        public int SleepDurationSeconds { get; set; }

        [JsonProperty("maqc")]
        public int MeasureAirQualityCycle { get; set; }

        [JsonProperty("aqmds")]
        public int AirQualityMeasurementDurationSeconds { get; set; }
    }
}
