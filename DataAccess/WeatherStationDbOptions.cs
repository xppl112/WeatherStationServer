namespace WeatherStationServer.DataAccess
{
    public class WeatherStationDbOptions
    {
        public const string ConfigurationDefaultKey = "dataAccess";

        public string ConnectionString { get; set; }
    }
}
