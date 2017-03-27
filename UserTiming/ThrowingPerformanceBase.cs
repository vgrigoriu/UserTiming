using System;
using System.Collections.Generic;

namespace UserTiming
{
    public class ThrowingPerformanceBase : IPerformance
    {
        public virtual void ClearMarks()
        {
            throw new NotImplementedException();
        }

        public virtual void ClearMarks(string markName)
        {
            throw new NotImplementedException();
        }

        public virtual void ClearMeasures()
        {
            throw new NotImplementedException();
        }

        public virtual void ClearMeasures(string measureName)
        {
            throw new NotImplementedException();
        }

        public virtual IEnumerable<IPerformanceEntry> GetEntries()
        {
            throw new NotImplementedException();
        }

        public virtual IEnumerable<IPerformanceEntry> GetEntriesByName(string name)
        {
            throw new NotImplementedException();
        }

        public virtual IEnumerable<IPerformanceEntry> GetEntriesByName(string name, string entryType)
        {
            throw new NotImplementedException();
        }

        public virtual IEnumerable<IPerformanceEntry> GetEntriesByType(string entryType)
        {
            throw new NotImplementedException();
        }

        public virtual void Mark(string markName)
        {
            throw new NotImplementedException();
        }

        public virtual void Measure(string measureName)
        {
            throw new NotImplementedException();
        }

        public virtual void Measure(string measureName, string startMark)
        {
            throw new NotImplementedException();
        }

        public virtual void Measure(string measureName, string startMark, string endMark)
        {
            throw new NotImplementedException();
        }
    }
}
