namespace ExtensionMethods
{

    /// <summary>
    /// TimeSpan型の拡張メソッド群
    /// </summary>
    public static class TimeSpanExtensions
    {
        /// <summary> 05:00~09:59ならtrue </summary>
        public static bool IsEarly(this TimeSpan time)
        {
            return IsWithinRange(
                time,
                new TimeSpan(5, 0, 0),
                new TimeSpan(9, 59, 0));
        }

        /// <summary> 10:00~14:59ならtrue </summary>
        public static bool IsLate(this TimeSpan time)
        {
            return IsWithinRange(
                time,
                new TimeSpan(10, 0, 0),
                new TimeSpan(14, 59, 0));
        }

        /// <summary> 15:00~20:59ならtrue </summary>
        public static bool IsWaste(this TimeSpan time)
        {
            return IsWithinRange(
                time,
                new TimeSpan(15, 0, 0),
                new TimeSpan(20, 59, 0));
        }

        /// <summary> 対象の時刻が上限下限の範囲内が否か </summary>
        private static bool IsWithinRange(TimeSpan target, TimeSpan min, TimeSpan max)
        {
            return
                target >= min &&
                target <= max;
        }
    }
}