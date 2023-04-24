using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace WeatherStationServer.DataAccess.Entities
{
    public class OverseasWeatherIndoorReportEntity
    {
        [Key]
        public long Id { get; set; }

        public DateTime Date { get; set; }

        public long TimeStamp { get; set; }

        public decimal Temperature { get; set; }
        public decimal TemperatureBME { get; set; }
        public int Humidity { get; set; }
        public int HumidityAHT { get; set; }
        public decimal Pressure { get; set; }
        public decimal GasResistance { get; set; }

        public decimal Radiation { get; set; }

        public int PM1_0 { get; set; }
        public int PM2_5 { get; set; }
        public int PM10_0 { get; set; }
    }
}
