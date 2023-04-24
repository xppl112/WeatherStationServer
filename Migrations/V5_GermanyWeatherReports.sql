CREATE TABLE GermanyWeatherReports (
    Id bigint AUTO_INCREMENT PRIMARY KEY,
    Date datetime NOT NULL,

    TemperatureAht FLOAT,
    HumidityAht int,
    TemperatureBmp FLOAT,
    Pressure FLOAT,
    RaindropLevel int,

    IsAirQualityMeasured boolean,
    PM_1_0 int,
    PM_2_5 int,
    PM_10_0 int,
    GasResistance FLOAT,
    TemperatureBme FLOAT,
    HumidityBme int,
    PressureBme FLOAT,

    BatteryVoltageIdle FLOAT,
    BatteryCurrentIdle FLOAT,
    BatteryVoltageAirSensorsOn FLOAT,
    BatteryCurrencyAirSensorsOn FLOAT,
    BatteryVoltageWifiOn FLOAT,
    BatteryCurrencyWifiOn FLOAT,

    WifiSignalLevel int,
    WifiConnectionErrorsCount int,
    WifiSendingErrorsCount int
);

ALTER TABLE GermanyWeatherReports ADD COLUMN BootCounter int AFTER BatteryCurrencyWifiOn;