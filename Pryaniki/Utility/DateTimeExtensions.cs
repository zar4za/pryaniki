namespace Pryaniki.Utility
{
    public static class DateTimeExtensions
    {
        public static DateTime RoundToMinutes(this DateTime dateTime)
        {
            return dateTime - new TimeSpan(0, 0, dateTime.Second);
        }
    }
}
