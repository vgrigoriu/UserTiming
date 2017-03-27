using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace UserTiming
{
    public class Performance : ThrowingPerformanceBase
    {
        

        private ImmutableList<IPerformanceEntry> entries = ImmutableList<IPerformanceEntry>.Empty;

        // serializes access to entries.
        private readonly object entriesLock = new object();

        public override void Mark(string markName)
        {
            var entry = new PerformanceMark(markName);
            lock (entriesLock)
            {
                entries = entries.Add(entry);
            }
        }

        public override void ClearMarks()
        {
            lock (entriesLock)
            {
                entries = entries
                    .Where(entry => entry.EntryType != PerformanceEntryType.Mark)
                    .ToImmutableList();
            }
        }

        public override void ClearMarks(string markName)
        {
            lock (entries)
            {
                entries = entries
                    .Where(entry => !IsMarkAndHasName(entry))
                    .ToImmutableList();
            }

            bool IsMarkAndHasName(IPerformanceEntry entry)
            {
                return entry.EntryType == PerformanceEntryType.Mark
                    && string.Equals(entry.Name, markName, StringComparison.Ordinal);
            }
        }

        public override void Measure(string measureName, string startMark)
        {
            var currentMark = new PerformanceMark(Guid.NewGuid().ToString());
            lock (entries)
            {
                entries = entries.Add(new PerformanceMeasure(
                    measureName,
                    startMark,
                    currentMark,
                    entries));
            }
        }

        public override void Measure(string measureName, string startMark, string endMark)
        {
            lock (entries)
            {
                entries = entries.Add(new PerformanceMeasure(
                    measureName,
                    startMark,
                    endMark,
                    entries));
            }
        }

        public override IEnumerable<IPerformanceEntry> GetEntriesByType(string entryType)
        {
            return entries.Where(entry => entry.EntryType == entryType);
        }
    }
}
