using Pryaniki.Utility;

namespace Pryaniki.Tests.Utility
{
    public class DateTimeExtensionsTests
    {
        [Fact]
        public void RoundToMinutes_DateTimeZeroSeconds_ShouldRoundCorrectly()
        {
            var actual = new DateTime(2023, 2, 21, 11, 51, 00);
            var expected = new DateTime(2023, 2, 21, 11, 51, 00);

            var round = actual.RoundToMinutes();

            Assert.Equal(expected, round);
        }

        [Fact]
        public void RoundToMinutes_DateTimeFiftyNineSeconds_ShouldRoundCorrectly()
        {
            var actual = new DateTime(2023, 2, 21, 11, 51, 59);
            var expected = new DateTime(2023, 2, 21, 11, 51, 00);

            var round = actual.RoundToMinutes();

            Assert.Equal(expected, round);
        }
    }
}
