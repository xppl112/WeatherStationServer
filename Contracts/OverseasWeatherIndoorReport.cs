using Newtonsoft.Json;

namespace WeatherStationServer.Contracts
{
    /*
 {
    "ts": 1,

    "t": 12.3,
    "h": 50,
    "p": 1000.2,
    "r": 0.13,

    "pm1": 10,
    "pm25": 11,
    "pm10": 12
}
    */

    public class OverseasWeatherIndoorReport
    {
        [JsonProperty("ts")]
        public long TimeStamp { get; set; }

        [JsonProperty("t")]
        public float Temperature { get; set; }

        [JsonProperty("t2")]
        public float TemperatureBME { get; set; }

        [JsonProperty("h")]
        public int Humidity { get; set; }

        [JsonProperty("h2")]
        public int HumidityAHT { get; set; }

        [JsonProperty("p")]
        public float Pressure { get; set; }

        [JsonProperty("gr")]
        public float GasResistance { get; set; }

        [JsonProperty("r")]
        public float Radiation { get; set; }

        [JsonProperty("pm1")]
        public int PM1_0 { get; set; }

        [JsonProperty("pm25")]
        public int PM2_5 { get; set; }

        [JsonProperty("pm10")]
        public int PM10_0 { get; set; }
    }
}
