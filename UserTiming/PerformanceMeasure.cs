namespace UserTiming
{
    internal abstract class PerformanceMeasure : IPerformanceMeasure
    {
        public abstract string Name { get; }

        public string EntryType => "measure";

        public abstract double StartTime { get; }

        public abstract double Duration { get; }
    }
}
