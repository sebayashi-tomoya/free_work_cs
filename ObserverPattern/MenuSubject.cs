/// <summary> 献立の変化を管理する被監視者クラス: ConcreteSubject </summary>
public class MenuSubject : IObservable<string>
{
    /// <summary> 変更通知を受け取るObserver </summary>
    private List<IObserver<string>> observers = new List<IObserver<string>>();

    /// <summary> 設定されている献立 </summary>
    private string menu = string.Empty;

    /// <inheritdoc/>
    public IDisposable Subscribe(IObserver<string> observer)
    {
        if (!this.observers.Contains(observer))
        {
            this.observers.Add(observer);
        }
        // 呼び出し側で購読解除ができるようにIDisposableを返す
        return new Unsubscriber(observers, observer);
    }

    /// <summary> 設定されている値を取得 </summary>
    public string GetMenu() => this.menu;

    /// <summary> 値を設定して変更を通知 </summary>
    public void SetMenu(string state)
    {
        this.menu = state;
        this.NotifyObservers();
    }

    /// <summary> Observerたちに変更を通知 </summary>
    private void NotifyObservers()
    {
        foreach (var observer in this.observers)
        {
            try
            {
                observer.OnNext(this.menu);
                observer.OnCompleted();
            }
            catch (Exception e)
            {
                observer.OnError(e);
            }
        }
    }
}