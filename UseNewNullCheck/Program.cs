using System.Reflection.PortableExecutable;

public class Program
{
    public static void Main(string[] args)
    {
        // まだC#14が使えなかった。
        Console.WriteLine("Hello World!");

        SetName(null);
    }

    public static void SetName(Item item)
    {
        item?.Name = "hoge";
    }
}

public class Item
{
    public string Name { get; set; }

    public Item(string name)
    {
        this.Name = name;
    }
}
