public class Program
{
    public static void Main()
    {
        // アプリ起動時の思い処理を避けたい例
        var lazyObject = new Lazy<LargeObject>(() => new LargeObject()); // ここではオブジェクトの生成はされない
        Console.WriteLine(lazyObject.Value.Data.Count); // Valueにアクセスして初めて初期化される

        // 共通部品やキャッシュ
        var cache = new Cache();
        cache.GetValues().ForEach(x => Console.WriteLine(x));
    }
}