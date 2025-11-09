using JsonSerializer.Signals;
using Newtonsoft.Json;

namespace JsonSerializer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // JSONへ変換するオブジェクトを生成
            var signals = new List<ISignal>
            {
                new RedSignal(),
                new GreenSignal(),
                new YellowSignal()
            };

            // シリアライズ
            var settings = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto, // 型情報を含める
                Formatting = Formatting.Indented, // インデントを揃える
            };

            var json = JsonConvert.SerializeObject(signals, settings);
            Console.WriteLine("=== シリアライズ結果 ==");
            Console.WriteLine(json);

            //　デシリアライズ
            var deserialized = JsonConvert.DeserializeObject<List<ISignal>>(json, settings);
            Console.WriteLine("\n=== デシリアライズ結果 ===");
            Console.WriteLine($"要素数: {deserialized?.Count ?? 0}");
        }
    }
}