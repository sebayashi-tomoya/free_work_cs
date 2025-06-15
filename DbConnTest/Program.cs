using MySql.Data.MySqlClient;

public class Program
{
    // 接続文字列の設定
    static readonly string connectionString = $"Server=localhost;Database=master;Uid=root;Pwd=root;Port=3306;";


    static async Task Main(string[] args)
    {
        Console.WriteLine("MySQL接続テストを開始します...");

        using var connection = new MySqlConnection(connectionString);

        try
        {
            await TestConnectionAsync(connection);
            await ShowSimpleTableData(connection, "users");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"エラーが発生しました: {ex.Message}");
        }

        Console.WriteLine("何かキーを押してください...");
        Console.ReadKey();
    }

    /// <summary>
    /// MySQL接続テスト
    /// </summary>
    static async Task TestConnectionAsync(MySqlConnection connection)
    {
        try
        {
            await connection.OpenAsync();
            Console.WriteLine("✓ MySQLに正常に接続できました");
            Console.WriteLine($"サーバーバージョン: {connection.ServerVersion}");
            Console.WriteLine($"データベース名: {connection.Database}");
        }
        catch (MySqlException ex)
        {
            Console.WriteLine($"✗ MySQL接続エラー: {ex.Message}");
            throw;
        }
    }

    /// <summary>
    /// テーブルのデータを表示
    /// </summary>
    static async Task ShowSimpleTableData(MySqlConnection connection, string tableName)
    {
        try
        {
            Console.WriteLine($"\n=== {tableName} テーブルの全データ ===");

            var command = new MySqlCommand($"SELECT * FROM {tableName}", connection);
            using var reader = await command.ExecuteReaderAsync();

            // カラム名を表示
            for (int i = 0; i < reader.FieldCount; i++)
            {
                Console.Write($"{reader.GetName(i),-15} | ");
            }
            Console.WriteLine();
            Console.WriteLine(new string('-', reader.FieldCount * 18));

            // データを表示
            while (await reader.ReadAsync())
            {
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    var value = reader.IsDBNull(i) ? "NULL" : reader[i].ToString();
                    Console.Write($"{value,-15} | ");
                }
                Console.WriteLine();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"エラー: {ex.Message}");
        }
    }
}