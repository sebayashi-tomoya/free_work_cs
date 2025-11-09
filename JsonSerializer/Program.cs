using System.Linq;
using JsonSerializer.Signals;
using Newtonsoft.Json;

namespace JsonSerializer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // JSONへ変換するオブジェクトを生成
            var signals = new[]
            {
                new { isActive = false, value = (ISignal)new RedSignal() },
                new { isActive = true,  value = (ISignal)new GreenSignal() },
                new { isActive = false, value = (ISignal)new YellowSignal() }
            };
            var jsonObject = new JsonObject
            {
                Signals = new SignalList(signals.ToLookup(x => x.isActive, x => x.value)),
                UpdatedAt = DateTime.Now
            };

            // シリアライズ
            var settings = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto, // 型情報を含める
                Formatting = Formatting.Indented, // インデントを揃える
            };

            var json = JsonConvert.SerializeObject(jsonObject, settings);
            Console.WriteLine("=== シリアライズ結果 ==");
            Console.WriteLine(json);

            //　デシリアライズ
            var deserialized = JsonConvert.DeserializeObject<JsonObject>(json, settings);
            Console.WriteLine("\n=== デシリアライズ結果 ===");
            Console.WriteLine($"要素数: {deserialized?.Signals?.Count ?? 0}");
            Console.WriteLine($"{nameof(JsonObject.ActiveSignalTypeName)}: {deserialized?.Signals.ActiveSignalType?.Name}");

        }
    }
}