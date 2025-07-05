// Analytics.Infrastructure/Services/AnalyticsService.cs
using AnalyticsService.Model;
using AnalyticsService.Services;
using ClickHouse.Client.ADO;
using ClickHouse.Client.Copy;
using Microsoft.EntityFrameworkCore;

namespace AnalyticsService.Infrastructure.Services
{
    public class AnalyticsService : IAnalyticsService
    {
        private readonly string _connectionString;

        public AnalyticsService(IConfiguration config)
        {
            _connectionString = config.GetConnectionString("ClickHouse")!;
        }

        public async Task InsertEventAsync(AnalyticsModel evt)
        {
            using var conn = new ClickHouseConnection(_connectionString);
            //await conn.OpenAsync();

            using var writer = new ClickHouseBulkCopy(conn)
            {
                DestinationTableName = "web_events"
            };

            await writer.InitAsync();

            await writer.WriteToServerAsync(new[]
            {
            new object[]
            {
                evt.Event,
                evt.Url,
                evt.Referrer ?? "",
                evt.Timestamp,
                evt.SessionId,
                evt.UserAgent,
                evt.Element,
                evt.Id,
                evt.Class,
                evt.Depth,
                evt.DurationSec
            }
        });
        }
    }
}