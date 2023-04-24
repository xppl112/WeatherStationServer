namespace WeatherStationServer.DomainServices
{
    public static class TimeInfoProvider
    {
        public static long GetCurrentTimestamp()
        {
            return new DateTimeOffset(DateTime.Now).ToUnixTimeSeconds();
        }

        public static bool IsNightTime(NightTimeConfiguration config)
        {
            if (!config.IsEnabled) return false;

            TimeZoneInfo? localTimeZone = null;
            try
            {
                localTimeZone = TimeZoneInfo.FindSystemTimeZoneById("FLE Standard Time");
            }
            catch
            { }

            var localDateTime = DateTime.Now.ToLocalTime();
            if (localTimeZone != null) { localDateTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, localTimeZone); }

            return localDateTime.Hour >= config.FromHour && localDateTime.Hour < config.ToHour;
        }
    }
}
