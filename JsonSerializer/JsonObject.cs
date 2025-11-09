using JsonSerializer.Signals;

namespace JsonSerializer
{
    public class JsonObject
    {
        public required SignalList Signals { get; set; }

        // TypeのままではJSONに変換不可のためstringで保持する
        public string? ActiveSignalTypeName
        {
            get => Signals.ActiveSignalType?.AssemblyQualifiedName;
            set => Signals.ActiveSignalType = value == null ? null : Type.GetType(value);
        }

        public DateTime UpdatedAt { get; set; }
    }
}