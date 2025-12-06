namespace UseThreadPool
{
    public class Program
    {
        public static void Main()
        {
            Console.WriteLine($"Main thread ID: {Thread.CurrentThread.ManagedThreadId}");

            ThreadPool.SetMaxThreads(1, 1);

            ThreadPool.QueueUserWorkItem(Hello);
            ThreadPool.QueueUserWorkItem(Hello);
            ThreadPool.QueueUserWorkItem(Hello);
            ThreadPool.QueueUserWorkItem(Hello);
            Console.WriteLine($"メインスレッドからこんにちは! ID:{Environment.CurrentManagedThreadId}");
        }

        private static void Hello(Object stateInfo)
        {
            Console.WriteLine($"スレッドプールからこんにちは! ID:{Environment.CurrentManagedThreadId}");
        }
    }
}