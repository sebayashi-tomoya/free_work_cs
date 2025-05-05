namespace ExtensionMethods
{
    public class Program
    {
        static void Main()
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
}