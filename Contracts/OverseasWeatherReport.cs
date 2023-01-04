using Newtonsoft.Json;

namespace WeatherStationServer.Contracts
{
    /*
    {
    "tss": 1607772810,
    "tsf": 1607772820,
    "to": 12.5,
    "ho": 60,
    "po": 121.3,
    "ti": 16,
    "hi": 40,
    "p1": 20,
    "p2": 30,
    "p10": 40
    }
    */
    public class OutdoorWeatherReport
    {
        [JsonProperty("tss")]
        public long TimeStampOfStart { get; set; }

        [JsonProperty("tsf")]
        public long TimeStampOfFinish { get; set; }

        [JsonProperty("to")]
        public float TemperatureOutside { get; set; }

        [JsonProperty("ho")]
        public int HumidityOutside { get; set; }

        [JsonProperty("po")]
        public float PressureOutside { get; set; }

        [JsonProperty("ti")]
        public float TemperatureInside { get; set; }

        [JsonProperty("hi")]
        public int HumidityInside { get; set; }

        [JsonProperty("p1")]
        public int PM1_0 { get; set; }

        [JsonProperty("p2")]
        public int PM2_5 { get; set; }

        [JsonProperty("p10")]
        public int PM_10_0 { get; set; }
    }
}
