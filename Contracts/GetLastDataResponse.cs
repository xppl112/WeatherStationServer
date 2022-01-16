using Newtonsoft.Json;
using System.Collections.Generic;

namespace WeatherStationServer.Contracts
{
    public class GetLastDataResponse
    {
        //{ cts: 1641840714,data:[{ "ts":1641840714,"PM":2000,"t":-12.3,"h":30,"p":1999.7}]}
        [JsonProperty("cts")]
        public long CurrentTimeStamp { get; set; }

        [JsonProperty("data")]
        public List<OutdoorWeatherDataItem> Data { get; set; }
    }

    public class OutdoorWeatherDataItem
    {
        [JsonProperty("ts")]
        public long TimeStamp { get; set; }

        [JsonProperty("PM")]
        public int PM2_5 { get; set; }

        [JsonProperty("to")]
        public float TemperatureOutside { get; set; }

        [JsonProperty("ho")]
        public int HumidityOutside { get; set; }

        [JsonProperty("p")]
        public float Pressure { get; set; }
    }
}
