namespace AnalyticsService.Model
{
    public class AnalyticsModel
    {
        public string Event { get; set; } = default!;
        public string Url { get; set; } = default!;
        public string? Referrer { get; set; }
        public DateTime Timestamp { get; set; }
        public Guid SessionId { get; set; }
        public string UserAgent { get; set; } = default!;
        public string? Element { get; set; }
        public string? Id { get; set; }
        public string? Class { get; set; }
        public byte? Depth { get; set; }
        public ushort? DurationSec { get; set; }
    }
}