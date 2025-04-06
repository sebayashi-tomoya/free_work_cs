namespace free_work_cs.GenericBeginner;

public class Main
{
    public Main()
    {
        // コンパイルは通るが、実行時にInvalidCastException発生
        // var item = new ObjectItem("String Value");
        // int intItem = (int)item.GetValue();

        var genericItem = new GenericItem<string>("string Value");
        // コンパイルエラー
        // int intItem = (int)genericItem.GetValue();
        // stringに代入する場合はキャストも不要
        string stringItem = genericItem.GetValue();


    }

    private void WriteLine<T>(T item)
    {
        Console.WriteLine(item);
    }

}
