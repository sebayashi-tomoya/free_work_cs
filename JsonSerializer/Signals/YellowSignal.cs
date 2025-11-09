namespace JsonSerializer.Signals
{
    public class YellowSignal : ISignal
    {
        public string Color { get; set; }

        public YellowSignal()
        {
            this.Color = "Yellow";
        }
    }
}