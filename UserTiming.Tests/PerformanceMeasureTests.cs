using System.Linq;
using System.Threading;
using Xunit;

namespace UserTiming.Tests
{
    public class PerformanceMeasureTests
    {
        [Fact]
        public void CanAddMeasureBetweenDefinedMarks()
        {
            var sut = new Performance();
            sut.Mark("start");
            Thread.Sleep(0);
            sut.Mark("stop");

            sut.Measure("start-stop", "start", "stop");

            var measure = sut.GetEntriesByType(PerformanceEntryType.Measure).Single();

            Assert.Equal("start-stop", measure.Name);
            Assert.True(measure.Duration > 0);
        }
    }
}
