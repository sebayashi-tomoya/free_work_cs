// サービスをDIで受け取るクラス
public class Consumer
{
    private readonly Lazy<IMyService> myService;

    public Consumer(Lazy<IMyService> service)
    {
        this.myService = service;
    }

    // このメソッドが呼ばれて初めてIMyServiceが解決される
    public void Execute() => this.myService.Value.DoSomething();
}

// サービスのインターフェース
public interface IMyService
{
    public void DoSomething();
}