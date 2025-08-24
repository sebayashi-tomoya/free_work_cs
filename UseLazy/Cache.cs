// アプリ共通データを保持するキャッシュクラス
public class Cache
{
    private static readonly Dictionary<int, string> dic = new Dictionary<int, string>
    {
        {1, "One"},
        {2, "Two"},
        {3, "Three"},
    };

    public Lazy<Dictionary<int, string>> cache;

    public Cache()
    {
        this.cache = new Lazy<Dictionary<int, string>>(() => dic);
    }

    public List<string> GetValues()
    {
        return cache.Value
            .Select(x => x.Value)
            .ToList();
    }
}