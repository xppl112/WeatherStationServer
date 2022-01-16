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
        public ReportsRepository(IOptionsMonitor<WeatherStationDbOptions> weatherStationDbOptionsMonitor)
        {
            WeatherStationDbOptionsMonitor = weatherStationDbOptionsMonitor;

            WeatherStationDbInstance = () => {
                var optionsBuilder = new DbContextOptionsBuilder<WeatherStationDbContext>();
                var options = optionsBuilder
                    .UseSqlServer(WeatherStationDbOptions.ConnectionString)
                    .Options;

                return new WeatherStationDbContext(options, WeatherStationDbOptionsMonitor);
            };
        }

        private IOptionsMonitor<WeatherStationDbOptions> WeatherStationDbOptionsMonitor { get; }

        private WeatherStationDbOptions WeatherStationDbOptions => WeatherStationDbOptionsMonitor.CurrentValue;

        private Func<WeatherStationDbContext> WeatherStationDbInstance;

        public List<OutdoorWeatherDataItem> GetLastReports(int count = 30)
        {
            using WeatherStationDbContext db = WeatherStationDbInstance();
            var reports = db.OutdoorWeatherReports.OrderByDescending(x => x.Id).Take(count).ToList().OrderBy(x => x.Id)
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
                using WeatherStationDbContext db = WeatherStationDbInstance();
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

                db.OutdoorWeatherReports.Add(report);
                await db.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }


    }
}
