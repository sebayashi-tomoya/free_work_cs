namespace free_work_cs.ExtensionMethod;

public class Main
{
    public Main()
    {
        GetUp(DateTime.Now.TimeOfDay);

        // 動作確認用
        // Console.WriteLine("夜行性-------------");
        // GetUp(new TimeSpan(21, 0, 0));
        // GetUp(new TimeSpan(4, 59, 0));
        // Console.WriteLine("早起き--------------");
        // GetUp(new TimeSpan(5, 0, 0));
        // GetUp(new TimeSpan(9, 59, 0));
        // Console.WriteLine("遅いよ！-----------");
        // GetUp(new TimeSpan(10, 0, 0));
        // GetUp(new TimeSpan(14, 59, 0));
        // Console.WriteLine("無駄---------------");
        // GetUp(new TimeSpan(15, 0, 0));
        // GetUp(new TimeSpan(20, 59, 0));
    }

    private static void GetUp(TimeSpan wakeUpTime)
    {
        if (wakeUpTime.IsEarly())
        {
            Console.WriteLine("早起きですね！朝活でもしちゃう？");
        }
        else if (wakeUpTime.IsLate())
        {
            Console.WriteLine("何時まで寝てるの!?");
        }
        else if (wakeUpTime.IsWaste())
        {
            Console.WriteLine("休日を無駄にしたね…");
        }
        else
        {
            Console.WriteLine("夜行性?");
        }
    }
}

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
