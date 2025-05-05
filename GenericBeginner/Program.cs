namespace GenericBeginner
{
    public class Program
    {
        public static void Main(string[] args)
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
    }
}