namespace JsonSerializer.Signals
{
    public class SignalList : List<ISignal>
    {
        public Type? ActiveSignalType { get; set; }

        // デシリアライズ用にデフォルトコンストラクタを用意    
        public SignalList() : base()
        {
        }

        public SignalList(ILookup<bool, ISignal> signals)
            : base(signals.SelectMany(g => g))
        {
            this.ActiveSignalType = signals[true].First().GetType();
        }

    }
}