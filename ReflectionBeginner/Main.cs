using System.Reflection;

namespace free_work_cs.ReflectionBeginner;

public class Main
{
    public Main()
    {
        // object型のアセンブリ情報を取得して出力
        Console.WriteLine($"object型のアセンブリ情報: {GetAssemblyInfo(typeof(object))}");

        // GetConstructor()を使ってstringのコンストラクタ情報を取得
        // https://learn.microsoft.com/ja-jp/dotnet/api/system.type.getconstructor?view=net-9.0
        ConstructorInfo[] constructorInfos = typeof(string).GetConstructors();

        // 一覧で出力
        foreach (ConstructorInfo info in constructorInfos)
        {
            Console.WriteLine(info);
        }

        // Type.GetMembers()を使ってメンバー情報を取得
        // http://learn.microsoft.com/ja-jp/dotnet/api/system.type.getmembers?view=net-9.0
        MemberInfo[] memberInfos = typeof(object).GetMembers();

        // 一覧で出力
        Console.WriteLine("object型のメンバー情報");
        foreach (MemberInfo member in memberInfos)
        {
            Console.WriteLine(member.Name);
        }
    }

    /// <summary>
    /// 引数で受け取ったオブジェクトのアセンブリ情報を取得して出力
    /// </summary>
    private static string GetAssemblyInfo(Type type)
    {
        Assembly assembly = type.Module.Assembly;
        return assembly.FullName ?? "Assembly not found";
    }
}
