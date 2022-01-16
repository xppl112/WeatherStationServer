using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using WeatherStationServer.DataAccess.Entities;

namespace WeatherStationServer.DataAccess
{
    public class WeatherStationDbContext : DbContext
    {
        public DbSet<OutdoorWeatherReportEntity> OutdoorWeatherReports { get; set; }

        private IOptionsMonitor<WeatherStationDbOptions> WeatherStationDbOptionsMonitor { get; }

        public WeatherStationDbContext(DbContextOptions<WeatherStationDbContext> options, IOptionsMonitor<WeatherStationDbOptions> weatherStationDbOptionsMonitor)
            : base(options)
        {
            WeatherStationDbOptionsMonitor = weatherStationDbOptionsMonitor;

            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {                
                var connectionString = WeatherStationDbOptionsMonitor.CurrentValue.ConnectionString;
                optionsBuilder.UseSqlServer(connectionString);
            }
        }
    }
}
