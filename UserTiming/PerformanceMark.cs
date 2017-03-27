using System.Diagnostics;

namespace UserTiming
{
    internal class PerformanceMark : IPerformanceMark
    {
        private static readonly double MilisecondsPerTick = 1000.0 / Stopwatch.Frequency;

        internal PerformanceMark(string markName)
        {
            Name = markName;
            StartTime = Stopwatch.GetTimestamp() * MilisecondsPerTick;
        }

        public string Name { get; }

        public string EntryType => PerformanceEntryType.Mark;

        public double StartTime { get; }

        public double Duration => 0;
    }
}
