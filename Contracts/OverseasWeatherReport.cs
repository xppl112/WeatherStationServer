using Newtonsoft.Json;

namespace WeatherStationServer.Contracts
{
    /*
 {
    "ts": 1,

    "t": 12.3,
    "h": 50,
    "p": 1000.2,

    "rd": 10,
    "uv": 12.3,
    "ll": 50,
    "w": 60,

    "bv": 5.6,
    "bci": 0.3,
    "bcw": 0.4,

    "wsl": 10,
    "we": 3
}
    */

    public class OverseasWeatherReport
    {
        [JsonProperty("ts")]
        public long TimeStamp { get; set; }

        [JsonProperty("t")]
        public float Temperature { get; set; }

        [JsonProperty("h")]
        public int Humidity { get; set; }

        [JsonProperty("p")]
        public float Pressure { get; set; }

        [JsonProperty("rd")]
        public int RaindropLevel { get; set; }

        [JsonProperty("uv")]
        public float UvLevel { get; set; }

        [JsonProperty("ll")]
        public int LightLevel { get; set; }

        [JsonProperty("w")]
        public int WindLevel { get; set; }

        [JsonProperty("bv")]
        public float BatteryVoltage { get; set; }

        [JsonProperty("bci")]
        public float BatteryCurrentIdle { get; set; }

        [JsonProperty("bcw")]
        public float BatteryCurrencyWifiOn { get; set; }


        [JsonProperty("wsl")]
        public int WifiSignalLevel { get; set; }

        [JsonProperty("we")]
        public int WifiErrorsCount { get; set; }
    }
}
