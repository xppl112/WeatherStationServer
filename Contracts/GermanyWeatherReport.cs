using Newtonsoft.Json;

namespace WeatherStationServer.Contracts
{
    /*
 {
    "t_aht": 1.1,
    "h_aht": 2,
    "t_bmp": 3.3,
    "p": 4.4,
    "rd": 5,

    "iaqm": 1,
    "pm_1": 6,
    "pm_25": 7,
    "pm_10": 8,
    "gr": 9.9,
    "t_bme": 10.1,
    "h_bme": 11,
    "p_bme": 12.12,

    "bvi": 13.3,
    "bci": 14.4,
    "bvs": 15.5,
    "bcs": 16.6,
    "bvw": 17.7,
    "bcw": 18.8,

    "wsl": 19,
    "wce": 20,
    "wse": 21
}
    */

    public class GermanyWeatherReport
    {
        [JsonProperty("t_aht")]
        public float TemperatureAht { get; set; }

        [JsonProperty("h_aht")]
        public int HumidityAht { get; set; }

        [JsonProperty("t_bmp")]
        public float TemperatureBmp { get; set; }

        [JsonProperty("p")]
        public float Pressure { get; set; }

        [JsonProperty("rd")]
        public int RaindropLevel { get; set; }


        [JsonProperty("iaqm")]
        public bool IsAirQualityMeasured { get; set; }

        [JsonProperty("pm_1")]
        public int? PM_1_0 { get; set; }

        [JsonProperty("pm_25")]
        public int? PM_2_5 { get; set; }

        [JsonProperty("pm_10")]
        public int? PM_10_0 { get; set; }

        [JsonProperty("gr")]
        public float? GasResistance { get; set; }

        [JsonProperty("t_bme")]
        public float? TemperatureBme { get; set; }

        [JsonProperty("h_bme")]
        public int? HumidityBme { get; set; }

        [JsonProperty("p_bme")]
        public float? PressureBme { get; set; }


        [JsonProperty("bvi")]
        public float BatteryVoltageIdle { get; set; }
        [JsonProperty("bci")]
        public float BatteryCurrentIdle { get; set; }

        [JsonProperty("bvs")]
        public float? BatteryVoltageAirSensorsOn { get; set; }
        [JsonProperty("bcs")]
        public float? BatteryCurrencyAirSensorsOn { get; set; }

        [JsonProperty("bvw")]
        public float BatteryVoltageWifiOn { get; set; }
        [JsonProperty("bcw")]
        public float BatteryCurrencyWifiOn { get; set; }


        [JsonProperty("bc")]
        public int BootCounter { get; set; }

        [JsonProperty("wsl")]
        public int WifiSignalLevel { get; set; }

        [JsonProperty("wce")]
        public int WifiConnectionErrorsCount { get; set; }

        [JsonProperty("wse")]
        public int WifiSendingErrorsCount { get; set; }
    }
}
