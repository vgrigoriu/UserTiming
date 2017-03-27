namespace UserTiming
{
    internal class PerformanceMark : IPerformanceMark
    {
        internal PerformanceMark(string markName, double startTime)
        {
            Name = markName;
            StartTime = startTime;
        }

        public string Name { get; }

        public string EntryType => PerformanceEntryType.Mark;

        public double StartTime { get; }

        public double Duration => 0;
    }
}
