// メモリ消費量の大きいオブジェクト
public class LargeObject
{
    public readonly List<long> Data = new List<long>();

    public LargeObject()
    {
        for (var i = 0; i < 100_000; i++)
        {
            Data.Add(i);
        }
    }
}