using System.Reflection;
using JsonSerializer.Signals;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace JsonSerializer
{
    public class SignalTypeConverter : JsonConverter<ISignal>
    {
        // ISignalを実装しているクラス
        private IReadOnlyCollection<Type> ConcreteTypes => Assembly.GetEntryAssembly()
            .GetTypes()
            .Where(t => typeof(ISignal).IsAssignableFrom(t) && t.IsClass && !t.IsAbstract)
            .ToList();

        private Dictionary<string, Type> AllowedTypes = new Dictionary<string, Type>();

        public SignalTypeConverter()
        {
            foreach (var type in ConcreteTypes)
            {
                this.AllowedTypes.Add(type.Name, type);
            }
        }

        public override void WriteJson(JsonWriter writer, ISignal? value, Newtonsoft.Json.JsonSerializer serializer)
        {
            if (value is null) return;

            var obj = new JObject();

            var typeKey = AllowedTypes.FirstOrDefault(at => at.Value == value.GetType()).Key;
            obj["type"] = typeKey;

            // 重要: serializerを渡さずに新しいシリアライザーを作成
            // または、このコンバーターを除外した設定で再シリアライズ
            var tempSerializer = new Newtonsoft.Json.JsonSerializer
            {
                ContractResolver = serializer.ContractResolver,
                Formatting = serializer.Formatting,
                // このコンバーターを除外
            };

            // プロパティをシリアライズ
            var properties = JObject.FromObject(value, tempSerializer);
            foreach (var prop in properties.Properties())
            {
                obj[prop.Name] = prop.Value;
            }

            obj.WriteTo(writer);
        }

        public override ISignal? ReadJson(JsonReader reader, Type objectType, ISignal? existingValue, bool hasExistingValue, Newtonsoft.Json.JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
            {
                return null;
            }

            var obj = JObject.Load(reader);
            var typeKey = obj["type"]?.ToString();

            if (string.IsNullOrEmpty(typeKey) || !AllowedTypes.ContainsKey(typeKey))
            {
                throw new JsonSerializationException($"不明または許可されていない型: {typeKey}");
            }

            var targetType = AllowedTypes[typeKey];
            obj.Remove("type");

            // 同様に新しいシリアライザーを使用
            var tempSerializer = new Newtonsoft.Json.JsonSerializer
            {
                ContractResolver = serializer.ContractResolver
            };

            return (ISignal)obj.ToObject(targetType, tempSerializer);
        }
    }
}