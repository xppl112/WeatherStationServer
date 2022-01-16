using WeatherStationServer.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WeatherStationServer.Repositories
{
    public interface IReportsRepository
    {
        List<OutdoorWeatherDataItem> GetLastReports(int count = 30);

        Task<bool> StoreOutdoorWeatherReport(OutdoorWeatherReport reportModel);
    }
}
