using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using WeatherStationServer.Contracts;
using WeatherStationServer.DataAccess;
using WeatherStationServer.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherStationServer.Repositories
{
    public class ReportsRepository : IReportsRepository
    {
        public ReportsRepository(WeatherStationDbContext dbContext)
        {
            DB = dbContext;
        }

        private WeatherStationDbContext DB;

        public List<OutdoorWeatherDataItem> GetLastReports(int count = 30)
        {
            var reports = DB.OutdoorWeatherReports.OrderByDescending(x => x.Id).Take(count).ToList().OrderBy(x => x.Id)
                .Select(r => new OutdoorWeatherDataItem
                {
                    TimeStamp = r.TimeStampOfFinish,
                    TemperatureOutside = (float)r.TemperatureOutside,
                    HumidityOutside = r.HumidityOutside,
                    PM2_5 = r.PM2_5,
                    Pressure = (float)r.PressureOutside
                }).ToList();

            return reports;
        }

        public async Task<bool> StoreOutdoorWeatherReport(OutdoorWeatherReport reportModel)
        {
            try
            {
                var report = new OutdoorWeatherReportEntity()
                {
                    Date = DateTime.UtcNow,
                    TimeStampOfStart = reportModel.TimeStampOfStart,
                    TimeStampOfFinish = reportModel.TimeStampOfFinish,

                    TemperatureOutside = (decimal)reportModel.TemperatureOutside,
                    HumidityOutside = reportModel.HumidityOutside,
                    PressureOutside = (decimal)reportModel.PressureOutside,

                    TemperatureInside = (decimal)reportModel.TemperatureInside,
                    HumidityInside = reportModel.HumidityInside,
                    
                    PM1_0 = reportModel.PM1_0,
                    PM2_5 = reportModel.PM2_5,
                    PM_10_0 = reportModel.PM_10_0,

                    //RestartsCount = reportModel.RestartsCount,
                    //WifiErrors = reportModel.WifiErrors
                };

                DB.OutdoorWeatherReports.Add(report);
                await DB.SaveChangesAsync();

                Metrics.Write("OutdoorWeather",
                new Dictionary<string, object>
                {
                    { "TimeStamp", report.TimeStampOfFinish },

                    { "TemperatureOutside", report.TemperatureOutside },
                    { "HumidityOutside", report.HumidityOutside },
                    { "PressureOutside", report.PressureOutside },

                    { "TemperatureInside", report.TemperatureInside },
                    { "HumidityInside", report.HumidityInside },

                    { "PM1_0", report.PM1_0 },
                    { "PM2_5", report.PM2_5 },
                    { "PM_10_0", report.PM_10_0 }
                });

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }


        public async Task<bool> StoreOverseasWeatherReport(OverseasWeatherReport reportModel)
        {
            try
            {
                if (reportModel.Humidity > 100) reportModel.Humidity = 100;
                if (reportModel.Humidity < 0) reportModel.Humidity = 0;

                var report = new OverseasWeatherReportEntity()
                {
                    Date = DateTime.UtcNow,
                    TimeStamp = reportModel.TimeStamp,

                    Temperature = (decimal)reportModel.Temperature,
                    Humidity = reportModel.Humidity,
                    Pressure = (decimal)reportModel.Pressure,

                    RaindropLevel = reportModel.RaindropLevel,
                    UvLevel = (decimal)reportModel.UvLevel,
                    LightLevel = reportModel.LightLevel,
                    WindLevel = reportModel.WindLevel,

                    BatteryVoltage = (decimal)reportModel.BatteryVoltage,
                    BatteryCurrentIdle = (decimal)reportModel.BatteryCurrentIdle,
                    BatteryCurrencyWifiOn = (decimal)reportModel.BatteryCurrencyWifiOn,

                    WifiSignalLevel = reportModel.WifiSignalLevel,
                    WifiErrorsCount = reportModel.WifiErrorsCount
                };

                DB.OverseasWeatherReports.Add(report);
                await DB.SaveChangesAsync();

                Metrics.Write("OverseasWeather",
                new Dictionary<string, object>
                {
                    { "TimeStamp", report.TimeStamp },

                    { "Temperature", report.Temperature },
                    { "Humidity", report.Humidity },
                    { "Pressure", report.Pressure },

                    { "RaindropLevel", report.RaindropLevel },
                    { "UvLevel", report.UvLevel },
                    { "LightLevel", report.LightLevel },
                    { "WindLevel", report.WindLevel },

                    { "BatteryVoltage", report.BatteryVoltage },
                    { "BatteryCurrentIdle", report.BatteryCurrentIdle },
                    { "BatteryCurrencyWifiOn", report.BatteryCurrencyWifiOn },

                    { "WifiSignalLevel", report.WifiSignalLevel },
                    { "WifiErrorsCount", report.WifiErrorsCount },
                });

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<OverseasWeatherDataItem> GetLastOverseasOutdoorReports(int count = 30)
        {
            var reports = DB.OverseasWeatherReports.OrderByDescending(x => x.Id).Take(count).ToList().OrderBy(x => x.Id)
                .Select(r => new OverseasWeatherDataItem
                {
                    //TimeStamp = r.TimeStamp,
                    Temperature = (float)r.Temperature,
                    //Humidity = r.Humidity,
                    Pressure = (float)r.Pressure,
                    RaindropLevel = r.RaindropLevel,
                    WindLevel = r.WindLevel
                }).ToList();

            return reports;
        }

        public async Task<bool> StoreOverseasWeatherIndoorReport(OverseasWeatherIndoorReport reportModel)
        {
            try
            {
                if (reportModel.Humidity > 100) reportModel.Humidity = 100;
                if (reportModel.Humidity < 0) reportModel.Humidity = 0;

                var report = new OverseasWeatherIndoorReportEntity()
                {
                    Date = DateTime.UtcNow,
                    TimeStamp = reportModel.TimeStamp,

                    Temperature = (decimal)reportModel.Temperature,
                    TemperatureBME = (decimal)reportModel.TemperatureBME,
                    Humidity = reportModel.Humidity,
                    HumidityAHT = reportModel.HumidityAHT,
                    Pressure = (decimal)reportModel.Pressure,
                    GasResistance = (decimal)reportModel.GasResistance,

                    Radiation = (decimal)reportModel.Radiation,

                    PM1_0 = reportModel.PM1_0,
                    PM2_5 = reportModel.PM2_5,
                    PM10_0 = reportModel.PM10_0
                };

                DB.OverseasWeatherIndoorReports.Add(report);
                await DB.SaveChangesAsync();

                Metrics.Write("OverseasIndoorWeather",
                new Dictionary<string, object>
                {
                    { "TimeStamp", report.TimeStamp },

                    { "Temperature", report.Temperature },
                    { "TemperatureBME", report.TemperatureBME },
                    { "Humidity", report.Humidity },
                    { "HumidityAHT", report.HumidityAHT },
                    { "Pressure", report.Pressure },
                    { "GasResistance", report.GasResistance },
                    { "Radiation", report.Radiation },

                    { "PM1_0", report.PM1_0 },
                    { "PM2_5", report.PM2_5 },
                    { "PM10_0", report.PM10_0 },
                });

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public async Task<bool> StoreGermanyWeatherReport(GermanyWeatherReport reportModel)
        {
            try
            {
                if (reportModel.HumidityAht > 100) reportModel.HumidityAht = 100;
                if (reportModel.HumidityAht < 0) reportModel.HumidityAht = 0;
                if (reportModel.HumidityBme > 100) reportModel.HumidityBme = 100;
                if (reportModel.HumidityBme < 0) reportModel.HumidityBme = 0;

                var report = new GermanyWeatherReportEntity()
                {
                    Date = DateTime.UtcNow,

                    TemperatureAht = (decimal)reportModel.TemperatureAht,
                    HumidityAht = reportModel.HumidityAht,
                    TemperatureBmp = (decimal)reportModel.TemperatureBmp,
                    Pressure = (decimal)reportModel.Pressure,
                    RaindropLevel = reportModel.RaindropLevel,

                    IsAirQualityMeasured = reportModel.IsAirQualityMeasured,
                    PM_1_0 = reportModel.PM_1_0,
                    PM_2_5 = reportModel.PM_2_5,
                    PM_10_0 = reportModel.PM_10_0,
                    GasResistance = (decimal?)reportModel.GasResistance,
                    TemperatureBme = (decimal?)reportModel.TemperatureBme,
                    HumidityBme = reportModel.HumidityBme,
                    PressureBme = (decimal?)reportModel.PressureBme,

                    BatteryVoltageIdle = (decimal)reportModel.BatteryVoltageIdle,
                    BatteryCurrentIdle = (decimal)reportModel.BatteryCurrentIdle,
                    BatteryVoltageAirSensorsOn = (decimal?)reportModel.BatteryVoltageAirSensorsOn,
                    BatteryCurrencyAirSensorsOn = (decimal?)reportModel.BatteryCurrencyAirSensorsOn,
                    BatteryVoltageWifiOn = (decimal)reportModel.BatteryVoltageWifiOn,
                    BatteryCurrencyWifiOn = (decimal)reportModel.BatteryCurrencyWifiOn,

                    BootCounter = reportModel.BootCounter,
                    WifiSignalLevel = reportModel.WifiSignalLevel,
                    WifiConnectionErrorsCount = reportModel.WifiConnectionErrorsCount,
                    WifiSendingErrorsCount = reportModel.WifiSendingErrorsCount
                };

                DB.GermanyWeatherReports.Add(report);
                await DB.SaveChangesAsync();

                var metrics = new Dictionary<string, object>
                {
                    { "TemperatureAht", report.TemperatureAht },
                    { "HumidityAht", report.HumidityAht },
                    { "TemperatureBmp", report.TemperatureBmp },
                    { "Pressure", report.Pressure },
                    { "RaindropLevel", report.RaindropLevel },

                    { "BatteryVoltageIdle", report.BatteryVoltageIdle },
                    { "BatteryCurrentIdle", report.BatteryCurrentIdle },
                    { "BatteryVoltageWifiOn", report.BatteryVoltageWifiOn },
                    { "BatteryCurrencyWifiOn", report.BatteryCurrencyWifiOn },

                    { "BootCounter", report.BootCounter },
                    { "WifiSignalLevel", report.WifiSignalLevel },
                    { "WifiConnectionErrorsCount", report.WifiConnectionErrorsCount },
                    { "WifiSendingErrorsCount", report.WifiSendingErrorsCount }
                };

                if (report.IsAirQualityMeasured) {
                    if (report.PM_1_0 != null)metrics.Add("PM_1_0", report.PM_1_0);
                    if (report.PM_2_5 != null) metrics.Add("PM_2_5", report.PM_2_5);
                    if (report.PM_10_0 != null) metrics.Add("PM_10_0", report.PM_10_0);
                    if (report.GasResistance != null) metrics.Add("GasResistance", report.GasResistance);
                    if (report.TemperatureBme != null) metrics.Add("TemperatureBme", report.TemperatureBme);
                    if (report.HumidityBme != null) metrics.Add("HumidityBme", report.HumidityBme);
                    if (report.PressureBme != null) metrics.Add("PressureBme", report.PressureBme);

                    if (report.BatteryVoltageAirSensorsOn != null) metrics.Add("BatteryVoltageAirSensorsOn", report.BatteryVoltageAirSensorsOn);
                    if (report.BatteryCurrencyAirSensorsOn != null) metrics.Add("BatteryCurrencyAirSensorsOn", report.BatteryCurrencyAirSensorsOn);
                }

                Metrics.Write("GermanyWeather", metrics);

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
