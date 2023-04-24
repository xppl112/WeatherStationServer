using WeatherStationServer.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WeatherStationServer.Repositories
{
    public interface IReportsRepository
    {
        List<OutdoorWeatherDataItem> GetLastReports(int count = 30);

        List<OverseasWeatherDataItem> GetLastOverseasOutdoorReports(int count = 30);

        Task<bool> StoreOutdoorWeatherReport(OutdoorWeatherReport reportModel);

        Task<bool> StoreOverseasWeatherReport(OverseasWeatherReport reportModel);

        Task<bool> StoreOverseasWeatherIndoorReport(OverseasWeatherIndoorReport reportModel);

        Task<bool> StoreGermanyWeatherReport(GermanyWeatherReport reportModel);
    }
}
