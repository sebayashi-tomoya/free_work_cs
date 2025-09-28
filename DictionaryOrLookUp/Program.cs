using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        // ========== Dictionary の実装例 ==========
        Console.WriteLine("=== Dictionary の実装例 ===");

        // ユーザーIDと年齢の組み合わせ
        var userAges = new Dictionary<string, int>
        {
            ["user1"] = 25,
            ["user2"] = 30,
            ["user3"] = 28
        };

        // Dictionary の基本操作
        Console.WriteLine("Dictionary の内容:");
        foreach (var kvp in userAges)
        {
            Console.WriteLine($"  {kvp.Key} → {kvp.Value}歳");
        }

        // 特定のユーザーの年齢を取得
        Console.WriteLine($"\nuser2の年齢: {userAges["user2"]}歳");

        // 要素の追加・更新（変更可能）
        userAges["user4"] = 35;  // 新しい要素を追加
        userAges["user1"] = 26;  // 既存の要素を更新

        Console.WriteLine("\n要素追加・更新後:");
        foreach (var kvp in userAges)
        {
            Console.WriteLine($"  {kvp.Key} → {kvp.Value}歳");
        }

        // 安全な取得方法
        if (userAges.TryGetValue("user5", out int age))
        {
            Console.WriteLine($"user5の年齢: {age}歳");
        }
        else
        {
            Console.WriteLine("user5は存在しません");
        }

        Console.WriteLine("\n" + new string('=', 50) + "\n");

        // ========== Lookup の実装例 ==========
        Console.WriteLine("=== Lookup の実装例 ===");

        // 従業員データの準備
        var employees = new[]
        {
            new { Name = "田中", Department = "開発" },
            new { Name = "佐藤", Department = "開発" },
            new { Name = "鈴木", Department = "開発" },
            new { Name = "高橋", Department = "営業" },
            new { Name = "渡辺", Department = "営業" },
            new { Name = "山田", Department = "管理" }
        };

        // 部署別にグループ化してLookupを作成
        var departmentLookup = employees.ToLookup(emp => emp.Department, emp => emp.Name);

        // Lookup の基本操作
        Console.WriteLine("Lookup の内容:");
        foreach (var group in departmentLookup)
        {
            Console.WriteLine($"  {group.Key} → [{string.Join(", ", group)}]");
        }

        // 特定の部署のメンバーを取得
        Console.WriteLine($"\n開発部のメンバー:");
        foreach (var member in departmentLookup["開発"])
        {
            Console.WriteLine($"  - {member}");
        }

        // 存在しない部署を指定した場合（空のシーケンスが返される）
        Console.WriteLine($"\n人事部のメンバー数: {departmentLookup["人事"].Count()}");

        // グループ数とキーの一覧
        Console.WriteLine($"\n部署数: {departmentLookup.Count}");
        Console.WriteLine("部署一覧:");
        foreach (var key in departmentLookup.Select(g => g.Key))
        {
            Console.WriteLine($"  - {key}");
        }

        // 部署別の人数カウント
        Console.WriteLine("\n部署別人数:");
        foreach (var group in departmentLookup)
        {
            Console.WriteLine($"  {group.Key}: {group.Count()}人");
        }

        Console.WriteLine("\n" + new string('=', 50) + "\n");

        // ========== 実用的な使用例 ==========
        Console.WriteLine("=== 実用的な使用例 ===");

        // Dictionary: ユーザー設定の管理
        var userSettings = new Dictionary<string, string>
        {
            ["theme"] = "dark",
            ["language"] = "ja",
            ["notifications"] = "enabled"
        };

        Console.WriteLine("ユーザー設定:");
        foreach (var setting in userSettings)
        {
            Console.WriteLine($"  {setting.Key}: {setting.Value}");
        }

        // Lookup: 商品のカテゴリ別分類
        var products = new[]
        {
            new { Name = "iPhone", Category = "Electronics", Price = 80000 },
            new { Name = "MacBook", Category = "Electronics", Price = 150000 },
            new { Name = "コーヒー豆", Category = "Food", Price = 1500 },
            new { Name = "紅茶", Category = "Food", Price = 800 },
            new { Name = "Tシャツ", Category = "Clothing", Price = 3000 },
            new { Name = "ジーンズ", Category = "Clothing", Price = 8000 }
        };

        var productsByCategory = products.ToLookup(p => p.Category);

        Console.WriteLine("\nカテゴリ別商品:");
        foreach (var category in productsByCategory)
        {
            Console.WriteLine($"  {category.Key}:");
            foreach (var product in category)
            {
                Console.WriteLine($"    - {product.Name} (¥{product.Price:N0})");
            }
        }

        // カテゴリ別の平均価格を計算
        Console.WriteLine("\nカテゴリ別平均価格:");
        foreach (var category in productsByCategory)
        {
            var avgPrice = category.Average(p => p.Price);
            Console.WriteLine($"  {category.Key}: ¥{avgPrice:N0}");
        }
    }
}

/*
実行結果の例:

=== Dictionary の実装例 ===
Dictionary の内容:
  user1 → 25歳
  user2 → 30歳
  user3 → 28歳

user2の年齢: 30歳

要素追加・更新後:
  user1 → 26歳
  user2 → 30歳
  user3 → 28歳
  user4 → 35歳

user5は存在しません

==================================================

=== Lookup の実装例 ===
Lookup の内容:
  開発 → [田中, 佐藤, 鈴木]
  営業 → [高橋, 渡辺]
  管理 → [山田]

開発部のメンバー:
  - 田中
  - 佐藤
  - 鈴木

人事部のメンバー数: 0

部署数: 3
部署一覧:
  - 開発
  - 営業
  - 管理

部署別人数:
  開発: 3人
  営業: 2人
  管理: 1人

==================================================

=== 実用的な使用例 ===
ユーザー設定:
  theme: dark
  language: ja
  notifications: enabled

カテゴリ別商品:
  Electronics:
    - iPhone (¥80,000)
    - MacBook (¥150,000)
  Food:
    - コーヒー豆 (¥1,500)
    - 紅茶 (¥800)
  Clothing:
    - Tシャツ (¥3,000)
    - ジーンズ (¥8,000)

カテゴリ別平均価格:
  Electronics: ¥115,000
  Food: ¥1,150
  Clothing: ¥5,500
*/