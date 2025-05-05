namespace GenericBeginner
{

    /// <summary> ジェネリッククラス </summary>
    public class GenericItem<T>
    {
        private T value;

        public GenericItem(T initialValue)
        {
            value = initialValue;
        }

        public T GetValue() => value;

        public void SetValue(T newValue)
        {
            value = newValue;
        }
    }

    public class ObjectItem
    {
        private object value;

        public ObjectItem(object initialValue)
        {
            value = initialValue;
        }
        public object GetValue() => value;

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
            items = initialList;
        }

        public int GetCount() => items.Count();
    }
}