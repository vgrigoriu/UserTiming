namespace UserTiming
{
    internal abstract class PerformanceMark : IPerformanceMark
    {
        public abstract string Name { get; }

        public string EntryType => "mark";

        public abstract double StartTime { get; }

        public double Duration => 0;
    }
}
