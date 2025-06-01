using System.Reactive.Linq;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;

public class Program
{
    public static void Main(string[] args)
    {
        var subscriber = new IntsSubscriber();
        subscriber.ChangeProperty();
    }
}

// 値の管理を行うクラス
public class IntsService
{
    // 整数値のコレクション(管理したい値)
    public ReactiveCollection<int> Ints { get; set; } = [];
}

// 変更をサブスクライブする側のクラス
public class IntsSubscriber
{
    private readonly IntsService intsService;

    public IntsSubscriber()
    {
        this.intsService = new IntsService();

        // 値の追加をサブスクライブ
        this.intsService.Ints
            .ObserveAddChanged()
            .Subscribe(x => Console.WriteLine("値が追加されました"));
    }

    public void ChangeProperty()
    {
        // ReactiveCollectionの値を変更
        this.intsService.Ints.AddRange(new List<int> { 1, 2, 3 });

        // 参照書き換えのため変更通知が飛ばない
        this.intsService.Ints = new ReactiveCollection<int>()
            .AddRange(new List<int> { 1, 2, 3 });
    }
}

/// <summary>
/// ReactiveCollectionの拡張メソッド
/// </summary>
public static class ReactiveCollectionExtensions
{
    /// <summary>
    /// 引数でリストを受け取ってそのまま追加して返す
    /// </summary>
    public static ReactiveCollection<T> AddRange<T>(this ReactiveCollection<T> collection, IEnumerable<T> items)
    {
        foreach (var item in items)
        {
            collection.Add(item);
        }
        return collection;
    }
}
