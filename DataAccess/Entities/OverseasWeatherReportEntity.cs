using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace WeatherStationServer.DataAccess.Entities
{
    public class OverseasWeatherReportEntity
    {
        [Key]
        public long Id { get; set; }

        public DateTime Date { get; set; }

        public long TimeStamp { get; set; }

        public decimal Temperature { get; set; }
        public int Humidity { get; set; }
        public decimal Pressure { get; set; }

        public int RaindropLevel { get; set; }
        public decimal UvLevel { get; set; }
        public int LightLevel { get; set; }
        public int WindLevel { get; set; }

        public decimal BatteryVoltage { get; set; }
        public decimal BatteryCurrentIdle { get; set; }
        public decimal BatteryCurrencyWifiOn { get; set; }

        public int WifiSignalLevel { get; set; }
        public int WifiErrorsCount { get; set; }
    }
}
