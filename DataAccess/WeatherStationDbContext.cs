using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using WeatherStationServer.DataAccess.Entities;

namespace WeatherStationServer.DataAccess
{
    public class WeatherStationDbContext : DbContext
    {
        public DbSet<OutdoorWeatherReportEntity> OutdoorWeatherReports { get; set; }
        public DbSet<OverseasWeatherReportEntity> OverseasWeatherReports { get; set; }
        public DbSet<OverseasWeatherIndoorReportEntity> OverseasWeatherIndoorReports { get; set; }
        public DbSet<GermanyWeatherReportEntity> GermanyWeatherReports { get; set; }

        public WeatherStationDbContext(DbContextOptions<WeatherStationDbContext> options)
            : base(options)
        {
            //Database.EnsureCreated();
        }
    }
}
