using System.Collections.Generic;

namespace UserTiming
{
    public interface IPerformance
    {
        void Mark(string markName);

        void ClearMarks();
        void ClearMarks(string markName);

        void Measure(string measureName);
        void Measure(string measureName, string startMark);
        void Measure(string measureName, string startMark, string endMark);

        void ClearMeasures();
        void ClearMeasures(string measureName);

        IEnumerable<IPerformanceEntry> GetEntries();
        IEnumerable<IPerformanceEntry> GetEntriesByType(string entryType);
        IEnumerable<IPerformanceEntry> GetEntriesByName(string name);
        IEnumerable<IPerformanceEntry> GetEntriesByName(string name, string entryType);
    }
}
