namespace UserTiming
{
    public interface IPerformanceEntry
    {
        string Name { get; }
        string EntryType { get; }
        double StartTime { get; }
        double Duration { get; }
    }
}
