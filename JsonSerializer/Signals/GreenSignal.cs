namespace JsonSerializer.Signals
{
    public class GreenSignal : ISignal
    {
        public string Color { get; set; }

        public GreenSignal()
        {
            this.Color = "Green";
        }
    }
}