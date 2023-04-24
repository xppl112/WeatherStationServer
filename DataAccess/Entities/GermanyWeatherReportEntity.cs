using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace WeatherStationServer.DataAccess.Entities
{
    public class GermanyWeatherReportEntity
    {
        [Key]
        public long Id { get; set; }

        public DateTime Date { get; set; }

        public decimal TemperatureAht { get; set; }
        public int HumidityAht { get; set; }
        public decimal TemperatureBmp { get; set; }
        public decimal Pressure { get; set; }
        public int RaindropLevel { get; set; }

        public bool IsAirQualityMeasured { get; set; }
        public int? PM_1_0 { get; set; }
        public int? PM_2_5 { get; set; }
        public int? PM_10_0 { get; set; }
        public decimal? GasResistance { get; set; }
        public decimal? TemperatureBme { get; set; }
        public int? HumidityBme { get; set; }
        public decimal? PressureBme { get; set; }

        public decimal BatteryVoltageIdle { get; set; }
        public decimal BatteryCurrentIdle { get; set; }
        public decimal? BatteryVoltageAirSensorsOn { get; set; }
        public decimal? BatteryCurrencyAirSensorsOn { get; set; }
        public decimal BatteryVoltageWifiOn { get; set; }
        public decimal BatteryCurrencyWifiOn { get; set; }

        public int BootCounter { get; set; }
        public int WifiSignalLevel { get; set; }
        public int WifiConnectionErrorsCount { get; set; }
        public int WifiSendingErrorsCount { get; set; }
    }
}
