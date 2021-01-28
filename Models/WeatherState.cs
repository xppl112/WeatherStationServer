namespace WeatherStationServer.Models
{
    /*
    {
    "TimeStampOfStart": 1607772810,
    "TimeStampOfFinish": 1607772820,
    "TemperatureOutside": 12.5,
    "HumidityOutside": 60,
    "PressureOutside": 121.3,
    "TemperatureInside": 16,
    "HumidityInside": 40,
    "PM1_0": 20,
    "PM2_5": 30,
    "PM_10_0": 40,
    "TVOC": 45.5
    }
    */
    public class WeatherState
    {
        public long TimeStampOfStart { get; set; }
        public long TimeStampOfFinish { get; set; }

        public float TemperatureOutside { get; set; }
        public int HumidityOutside { get; set; }
        public float PressureOutside { get; set; }

        public float TemperatureInside { get; set; }
        public int HumidityInside { get; set; }

        public int PM1_0 { get; set; }
        public int PM2_5 { get; set; }
        public int PM_10_0 { get; set; }

        public float TVOC { get; set; }
    }
}
