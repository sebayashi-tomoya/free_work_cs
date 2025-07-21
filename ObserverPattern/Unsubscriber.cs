/// <summary> 購読解除用のヘルパークラス </summary>
public class Unsubscriber : IDisposable
{
    private List<IObserver<string>> observers;
    private IObserver<string> observer;

    public Unsubscriber(List<IObserver<string>> observers, IObserver<string> observer)
    {
        this.observers = observers;
        this.observer = observer;
    }

    public void Dispose()
    {
        if (observers.Contains(observer))
        {
            observers.Remove(observer);
        }
    }
}