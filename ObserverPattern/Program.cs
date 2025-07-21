public class Program
{
    public static void Main(string[] args)
    {
        // ConcreteSubject(被監視者)の作成
        var menuSubject = new MenuSubject();

        // ConcreteObserver(監視者)の作成
        var takashi = new Eater("たかし", "ラーメン");
        var hanako = new Eater("はなこ", "カレー");

        // 購読開始
        var takashiSubscription = menuSubject.Subscribe(takashi);
        var hanakoSubscription = menuSubject.Subscribe(hanako);

        // ラーメン
        Console.WriteLine("ラーメンをどうぞ！");
        menuSubject.SetMenu("ラーメン");
        // 改行用
        Console.WriteLine();
        // カレー
        Console.WriteLine("カレーをどうぞ！");
        menuSubject.SetMenu("カレー");

        // 購読を解除
        takashiSubscription.Dispose();
        hanakoSubscription.Dispose();

        // 購読解除後は変更通知されない
        menuSubject.SetMenu("ハンバーグ");
    }
}