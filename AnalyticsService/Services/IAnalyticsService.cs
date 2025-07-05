using AnalyticsService.Model;

namespace AnalyticsService.Services
{
    public interface IAnalyticsService
    {
        Task InsertEventAsync(AnalyticsModel evt);
    }
}