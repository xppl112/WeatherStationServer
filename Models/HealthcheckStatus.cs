namespace WeatherStationServer.Models
{
    /*
    {
    "TimeStamp": 1607772810,
    "InternalVoltage": 5.3,
    "ExternalVoltage": 6.3,
    "IsOnReservePower": false,
    "IsPMSSensorOnline": true,
    "IsBMESensorOnline": true,
    "IsTVOCSensorOnline": false,
    "IsDHTSensorOnline": true,
    "IsErrorFound": false,
    "ErrorMessage": ""
    }
    */
    public class HealthcheckStatus
    {
        public long TimeStamp { get; set; }
        public float Internal5Voltage { get; set; }
        public float Internal3_3Voltage { get; set; }
        public float InputVoltage { get; set; }
        public bool IsOnReservePower { get; set; }


        public bool IsErrorFound { get; set; }
        public string ErrorMessage { get; set; }
    }
}
