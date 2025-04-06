namespace free_work_cs.GenericBeginner;

/// <summary> ジェネリッククラス </summary>
public class GenericItem<T>
{
    private T value;

    public GenericItem(T initialValue)
    {
        this.value = initialValue;
    }

    public T GetValue() => this.value;

    public void SetValue(T newValue)
    {
        this.value = newValue;
    }
}

public class ObjectItem
{
    private object value;

    public ObjectItem(object initialValue)
    {
        this.value = initialValue;
    }
    public object GetValue() => this.value;

    public void SetValue(object newValue)
    {
        value = newValue;
    }
}


public class GenericList<T>
{
    private T[] items;

    public GenericList(T[] initialList)
    {
        this.items = initialList;
    }

    public int GetCount() => this.items.Count();
}
