using Newtonsoft.Json;
using System.Collections.Generic;

namespace WeatherStationServer.Contracts
{
    public class OverseasWeatherIndoorResponse
    {
        //{ cts: 1641840714,data:[{ "ts":1641840714,"PM":2000,"t":-12.3,"h":30,"p":1999.7}]}
        [JsonProperty("cts")]
        public long CurrentTimeStamp { get; set; }

        [JsonProperty("data")]
        public List<OverseasWeatherDataItem> Data { get; set; }
    }

    public class OverseasWeatherDataItem
    {
        //[JsonProperty("ts")]
        //public long TimeStamp { get; set; }

        [JsonProperty("rd")]
        public int RaindropLevel { get; set; }

        [JsonProperty("w")]
        public int WindLevel { get; set; }

        [JsonProperty("t")]
        public float Temperature { get; set; }

        //[JsonProperty("h")]
        //public int Humidity { get; set; }

        [JsonProperty("p")]
        public float Pressure { get; set; }
    }
}
