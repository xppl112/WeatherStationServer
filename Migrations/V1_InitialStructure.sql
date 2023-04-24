CREATE TABLE OutdoorWeatherReports (
    Id bigint AUTO_INCREMENT PRIMARY KEY,
    Date datetime NOT NULL,
    TimeStampOfStart bigint,
    TimeStampOfFinish bigint,
    TemperatureOutside FLOAT,
    HumidityOutside int,
    PressureOutside FLOAT,
    TemperatureInside FLOAT,
    HumidityInside FLOAT,
    PM1_0 int,
    PM2_5 int,
    PM_10_0 int,
    RestartsCount bigint,
    WifiErrors int
);