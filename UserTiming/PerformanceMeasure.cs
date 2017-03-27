using System;
using System.Collections.Generic;
using System.Linq;

namespace UserTiming
{
    internal class PerformanceMeasure : IPerformanceMeasure
    {
        private readonly Lazy<IPerformanceEntry> startMark;

        private readonly Lazy<IPerformanceEntry> endMark;

        public PerformanceMeasure(
            string measureName,
            string startMarkName,
            string endMarkName,
            IEnumerable<IPerformanceEntry> entries)
        {
            Name = measureName;
            startMark = new Lazy<IPerformanceEntry>(
                () => entries.Last(
                    entry => string.Equals(startMarkName, entry.Name, StringComparison.Ordinal)));
            endMark = new Lazy<IPerformanceEntry>(
                () => entries.Last(
                    entry => string.Equals(endMarkName, entry.Name, StringComparison.Ordinal)));
        }

        public string Name { get; }

        public string EntryType => PerformanceEntryType.Measure;

        public double StartTime => startMark.Value.StartTime;

        public double Duration => endMark.Value.StartTime - startMark.Value.StartTime;
    }
}
