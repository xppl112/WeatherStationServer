using Newtonsoft.Json;

namespace WeatherStationServer.Contracts
{
    public class GetServerDataResponse
    {
        [JsonProperty("ts")]
        public long Timestamp { get; set; }

        [JsonProperty("test")]
        public long TestEcho { get; set; }

        [JsonProperty("testString")]
        public string TestString { get; set; }
    }
}
