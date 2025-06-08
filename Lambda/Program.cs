public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine(Square(5));
        Console.WriteLine(SquareLambda(5));

        Console.WriteLine(Calc(5, number => number * number));

        int[] numbers = [1, 2, 3, 4, 5];
        int[] evenNumbers = numbers.Where(num => num % 2 == 0).ToArray();

        foreach (int number in evenNumbers)
        {
            Console.WriteLine(number);
        }

        // ラムダなし
        OnSomethingCompleted(CompletedA);
        OnSomethingCompleted(CompletedB);

        // ラムダあり
        OnSomethingCompleted(() => Console.WriteLine("Aの処理終了"));
        OnSomethingCompleted(() => Console.WriteLine("Bの処理終了"));

        // 自前SELECT
        var squared = numbers.Select(number => number * number);
        foreach (var item in squared)
        {
            Console.WriteLine(item);
        }
    }

    // ラムダ式を使わないパターン
    private static int Square(int number)
    {
        return number * number;
    }

    // ラムダ式を使うパターン
    private static int SquareLambda(int number) => number * number;

    // 引数にラムダ式を使うパターン
    private static int Calc(int number, Func<int, int> calcFunc)
    {
        return calcFunc(number);
    }

    private static void OnSomethingCompleted(Action onCompleted)
    {
        // 処理終了後の共通処理
        Console.WriteLine("共通処理を実行しました");

        // 処理終了後の個別処理
        onCompleted.Invoke();
    }

    private static void CompletedA()
    {
        Console.WriteLine("Aの処理終了");
    }

    private static void CompletedB()
    {
        Console.WriteLine("Bの処理終了");
    }
}
