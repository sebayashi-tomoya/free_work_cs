using System.Collections;

namespace Linq;

public class Program
{
    public static void Main(string[] args)
    {
        #region 基礎編

        var nums = new List<int> { 1, 2, 3, 4, 5 };

        // Select(変換や射影)
        Console.WriteLine("Select(要素をすべて2倍)");
        var doubledNums = nums.Select(n => n * 2);
        WriteNums(doubledNums);

        // Where(抽出・絞り込み)
        Console.WriteLine("Where(偶数のみを抽出)");
        var evenNums = nums.Where(n => n % 2 == 0);
        WriteNums(evenNums);

        // ToList, ToArray(コレクション化)
        Console.WriteLine("ToArray(配列化)");
        var arrayNums = nums.ToArray(); // Listから配列への変換
        Console.WriteLine(arrayNums.GetType());

        Console.WriteLine("ToList(リスト化)");
        var numList = arrayNums.ToList(); // 配列からListへの変換
        Console.WriteLine(numList.GetType());

        // OrderBy, OrderByDescending(並び替え)
        Console.WriteLine("OrderByDescending(降順)");
        var descNums = nums.OrderByDescending(n => n);
        WriteNums(descNums);

        Console.WriteLine("OrderBy(昇順)");
        var ascNums = descNums.OrderBy(n => n);
        WriteNums(ascNums);

        // First, FirstOrDefault(最初の要素を取得)
        Console.WriteLine("First(最初の要素を取得)");
        Console.WriteLine(nums.First()); // 条件なし
        Console.WriteLine(nums.First(n => n % 2 == 0)); // 条件あり(条件に合致する中で最初の要素を返す)
        // 条件に一致する要素がない場合は例外が発生する
        try
        {
            Console.WriteLine(nums.First(n => n > 5));
        }
        catch (InvalidOperationException e)
        {
            Console.WriteLine(e.Message);
        }

        Console.WriteLine("FirstOrDefault(最初の要素を取得)");
        Console.WriteLine(nums.FirstOrDefault()); // 条件なし
        Console.WriteLine(nums.FirstOrDefault(n => n % 2 == 0)); // 条件あり(条件に合致する中で最初の要素を返す)
        // 条件に一致する要素がない場合は0 (objectの場合はnull) を返す
        Console.WriteLine(nums.FirstOrDefault(n => n > 5));

        // Any, All(条件判定)
        Console.WriteLine("Any(コレクション内に条件に一致する要素が一つでも存在するか)");
        Console.WriteLine(nums.Any(n => n % 2 == 0));
        Console.WriteLine(nums.Any(n => n > 5));

        Console.WriteLine("All(コレクション内のすべての要素が条件に一致するか)");
        Console.WriteLine(nums.All(n => n < 10));
        Console.WriteLine(nums.All(n => n % 2 == 0));

        // 空リストに対してAllを使うとtrueが返ってくる
        var emptyList = new List<int>();
        Console.WriteLine(emptyList.All(n => n % 2 == 0));

        // Count(要素数のカウント)
        Console.WriteLine("Count(要素数のカウント)");
        Console.WriteLine(nums.Count());
        Console.WriteLine(emptyList.Count());

        #endregion

        #region 使う機会は少ないけど覚えてたらカッコいい

        // Reverse(逆順に並び替え)
        var strArray = new[] { "A", "C", "Z", "B" };
        Console.WriteLine("Reverse(逆順処理)");
        foreach (var item in strArray.Reverse())
        {
            // アルファベットの昇順・降順に関わらず単純に逆順で処理
            Console.WriteLine(item);
        }

        // ToLookUp(辞書的アクセス可能なオブジェクトへの変換)
        Console.WriteLine("ToLookUp(辞書的アクセス可能なオブジェクトへの変換)");

        // ジョジョキャラを部ごとにオブジェクト化してリストへ格納
        var characters = new List<Character>
        {
            new Character { Name = "Jonathan", Part = 1 },
            new Character { Name = "Elenor", Part = 1 },
            new Character { Name = "Joseph", Part = 2 },
            new Character { Name = "SuziQ", Part = 2 },
            new Character { Name = "Jotaro", Part = 3 },
            new Character { Name = "Avdol", Part = 3 }
        };

        ILookup<int, Character> lookup = characters.ToLookup(c => c.Part);

        foreach (IGrouping<int, Character> group in lookup)
        {
            // key = Character.Part
            Console.Write($"{group.Key}部:");
            foreach (var character in group)
            {
                Console.Write($" {character.Name}");
            }
            Console.WriteLine(); // 改行
        }

        // OfType(型フィルタリング)
        Console.WriteLine("OfType(型フィルタリング)");
        ArrayList arrayList = new ArrayList { "記事を", 2, 6, "読んでくれて", null, 8, "ありがとう", 10, "!" };
        IEnumerable<string> strings = arrayList.OfType<string>(); // stringだけを抽出
        foreach (var str in strings)
        {
            Console.Write(str);
        }

        #endregion
    }

    private static void WriteNums(IEnumerable<int> nums)
    {
        foreach (var n in nums)
        {
            Console.WriteLine(n);
        }
    }
}
