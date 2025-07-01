public class Program
{
    public static void Main(string[] args)
    {
        // 基本的な使い方
        var characters = new[] { "ジョナサン", "ジョセフ", "承太郎" };
        var titles = new[] { "ファントムブラッド", "戦闘潮流", "スターダストクルセイダーズ" };

        IEnumerable<string> map = characters.Zip(titles, (character, title) => $"title: {title} character:{character}");

        foreach (var item in map)
        {
            Console.WriteLine(item);
        }

        // 3つのIEnumerableを結合
        var partNumbers = new[] { 1, 2, 3 };

        IEnumerable<string> tripleMap = characters
            .Zip(titles, (character, title) => new { title, character })
            .Zip(partNumbers, (map, partNumber) => $"parNumber: {partNumber} title: {map.title} character: {map.character}");

        foreach (var item in tripleMap)
        {
            Console.WriteLine(item);
        }

        // 複数の数値リストの計算にも有効
        var numbers1 = new[] { 1, 2, 3, 4, 5 };
        var numbers2 = new[] { 5, 4, 3, 2, 1 };

        IEnumerable<int> added = numbers1
            .Zip(numbers2, (a, b) => a + b);

        numbers1[0] = 5;

        foreach (var item in added)
        {
            Console.Write(item);
        }
    }
}