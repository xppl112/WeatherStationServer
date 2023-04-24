CREATE TABLE OverseasWeatherIndoorReports (
    Id bigint AUTO_INCREMENT PRIMARY KEY,
    Date datetime NOT NULL,
    TimeStamp bigint,
    Temperature FLOAT,
    Humidity int,
    Pressure FLOAT,
    Radiation FLOAT,
    PM1_0 int,
    PM2_5 int,
    PM10_0 int
);