using Xunit;

namespace UserTiming.Tests
{
    public class PerformanceMarkTests
    {
        [Fact]
        public void CanGetAddedMark()
        {
            var sut = new Performance();
            sut.Mark("test");
            var entries = sut.GetEntriesByType(PerformanceEntryType.Mark);

            Assert.Contains(entries, entry => entry.Name == "test");
        }

        [Fact]
        public void CanClearAddedMarks()
        {
            var sut = new Performance();
            sut.Mark("test");
            sut.Mark("another-test");
            sut.ClearMarks();
            var entries = sut.GetEntriesByType(PerformanceEntryType.Mark);

            Assert.Empty(entries);
        }
    }
}
