namespace JsonSerializer.Signals
{
    public class RedSignal : ISignal
    {
        public string Color { get; set; }

        public RedSignal()
        {
            this.Color = "Red";
        }
    }
}