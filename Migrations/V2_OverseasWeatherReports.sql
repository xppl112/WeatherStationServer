CREATE TABLE OverseasWeatherReports (
    Id bigint AUTO_INCREMENT PRIMARY KEY,
    Date datetime NOT NULL,
    TimeStamp bigint,
    Temperature FLOAT,
    Humidity int,
    Pressure FLOAT,
    RaindropLevel int,
    UvLevel FLOAT,
    LightLevel int,
    WindLevel int,
    BatteryVoltage FLOAT,
    BatteryCurrentIdle FLOAT,
    BatteryCurrencyWifiOn FLOAT,
    WifiSignalLevel int,
    WifiErrorsCount int
);