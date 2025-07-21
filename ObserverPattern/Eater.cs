/// <summary> 献立を食べる人: ConcreteObserver </summary>
public class Eater : IObserver<string>
{
    private readonly string name;
    private readonly string favorite;

    public Eater(string name, string favoriteFood)
    {
        this.name = name;
        this.favorite = favoriteFood;
    }

    // OnNextが正常に完了した後の処理
    public void OnCompleted()
    {
        Console.Write($"{this.name}: ");
        Console.WriteLine("ごちそうさまでした！");
    }

    // エラー発生時の処理
    public void OnError(Exception error)
    {
        Console.WriteLine($"エラー発生: {error.Message}");
    }

    // 変更通知を受け取った後に実行される処理
    public void OnNext(string value)
    {
        Console.Write($"{this.name}: ");
        Console.WriteLine(value == favorite
            ? "大好物です！いただきます！"
            : "あまり好きじゃないけど…。いただきます…。"
        );
    }
}