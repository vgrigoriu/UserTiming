using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;

namespace UserTiming
{
    public class Performance : ThrowingPerformanceBase
    {
        private static readonly double MilisecondsPerTick = 1000.0 / Stopwatch.Frequency;

        private ImmutableList<IPerformanceEntry> entries = ImmutableList<IPerformanceEntry>.Empty;

        // serializes access to entries.
        private readonly object entriesLock = new object();

        public override void Mark(string markName)
        {
            var miliseconds = Stopwatch.GetTimestamp() * MilisecondsPerTick;
            lock (entriesLock)
            {
                entries = entries.Add(new PerformanceMark(markName, miliseconds));
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

        public override IEnumerable<IPerformanceEntry> GetEntriesByType(string entryType)
        {
            return entries.Where(entry => entry.EntryType == entryType);
        }
    }

    public static class PerformanceEntryType
    {
        public const string Mark = "mark";
    }
}
