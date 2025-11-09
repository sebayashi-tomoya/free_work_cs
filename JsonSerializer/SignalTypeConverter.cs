using System.Reflection;
using JsonSerializer.Signals;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace JsonSerializer
{
    public class SignalTypeConverter : JsonConverter<ISignal>
    {
        // JSON変換時に型名を保持しておくプロパティ名
        private static readonly string TYPE_PROPERTY = "type";

        private Dictionary<string, Type> AllowedTypes = new Dictionary<string, Type>();

        public SignalTypeConverter()
        {
            // ISignalを実装しているクラス一覧をリフレクションで取得
            var concreteTypes = Assembly.GetEntryAssembly()
                .GetTypes()
                .Where(t => typeof(ISignal).IsAssignableFrom(t) && t.IsClass && !t.IsAbstract)
                .ToList();

            // Dictionary化
            foreach (var type in concreteTypes)
            {
                this.AllowedTypes.Add(type.Name, type);
            }
        }

        // シリアライズ時
        public override void WriteJson(JsonWriter writer, ISignal? value, Newtonsoft.Json.JsonSerializer serializer)
        {
            if (value is null) return;

            var obj = new JObject();

            var typeKey = AllowedTypes.FirstOrDefault(at => at.Value == value.GetType()).Key;
            obj[TYPE_PROPERTY] = typeKey; // JSONのtypeプロパティにキーを格納

            // serializerをそのまま渡すとSignalTypeConverterの循環参照になってしまう
            // このコンバーターを除外した設定で再シリアライズ
            var tempSerializer = new Newtonsoft.Json.JsonSerializer
            {
                ContractResolver = serializer.ContractResolver,
                Formatting = serializer.Formatting,
            };

            // プロパティをシリアライズ
            var properties = JObject.FromObject(value, tempSerializer);
            foreach (var prop in properties.Properties())
            {
                obj[prop.Name] = prop.Value;
            }

            obj.WriteTo(writer);
        }

        // デシリアライズ時
        public override ISignal? ReadJson(JsonReader reader, Type objectType, ISignal? existingValue, bool hasExistingValue, Newtonsoft.Json.JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
            {
                return null;
            }

            var obj = JObject.Load(reader);
            var typeKey = obj[TYPE_PROPERTY]?.ToString(); // シリアライズ時に指定した文字列を取得
            var targetType = AllowedTypes[typeKey]; // C#で扱うTypeへ変換
            obj.Remove(TYPE_PROPERTY); // 文字列で設定していたプロパティは削除

            // シリアライズと同様に新しいシリアライザーを使用
            var tempSerializer = new Newtonsoft.Json.JsonSerializer
            {
                ContractResolver = serializer.ContractResolver
            };

            return (ISignal)obj.ToObject(targetType, tempSerializer);
        }
    }
}