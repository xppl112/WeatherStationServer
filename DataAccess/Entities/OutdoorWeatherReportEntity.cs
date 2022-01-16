using System;
using System.ComponentModel.DataAnnotations;

namespace WeatherStationServer.DataAccess.Entities
{
    public class OutdoorWeatherReportEntity
    {
        [Key]
        public long Id { get; set; }

        public DateTime Date { get; set; }

        public long TimeStampOfStart { get; set; }
        public long TimeStampOfFinish { get; set; }

        public decimal TemperatureOutside { get; set; }
        public int HumidityOutside { get; set; }
        public decimal PressureOutside { get; set; }

        public decimal TemperatureInside { get; set; }
        public int HumidityInside { get; set; }

        public int PM1_0 { get; set; }
        public int PM2_5 { get; set; }
        public int PM_10_0 { get; set; }

        public long RestartsCount { get; set; }

        public int WifiErrors { get; set; }
    }
}
