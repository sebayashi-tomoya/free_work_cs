using System.Data;
using Microsoft.Data.SqlClient;

namespace ExceptionBestPractice
{
    public class SqlCommands
    {
        public void ExecuteSqlCommand(string connString, string command)
        {
            var connection = new SqlConnection(connString);
            var executeCommand = new SqlCommand(command, connection);

            try
            {
                connection.Open();
                executeCommand.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                Console.WriteLine("SQL実行でエラーが起きています");
                Console.WriteLine($"{e.ToString}");
            }
        }

        // 従来のusing実装
        public void ExecuteSqlCommandUsing(string connString, string command)
        {
            using (var connection = new SqlConnection(connString))
            using (var executeCommand = new SqlCommand(command, connection))
            {
                try
                {
                    connection.Open();
                    executeCommand.ExecuteNonQuery();
                }
                catch (SqlException e)
                {
                    Console.WriteLine("SQL実行でエラーが起きています");
                    Console.WriteLine($"{e.ToString}");
                }
            }
            // 例外発生に関わらずusingブロックの終了タイミングでDisposeが実行される
        }

        // .NET8.0以降で使用可能なusing宣言
        public void ExecuteSqlCommandNewUsing(string connString, string command)
        {
            using var connection = new SqlConnection(connString);
            using var executeCommand = new SqlCommand(command, connection);
            try
            {
                connection.Open();
                executeCommand.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                Console.WriteLine("SQL実行でエラーが起きています");
                Console.WriteLine($"{e.ToString}");
            }
            // 例外の発生有無に関係なく変数のスコープが無効になったタイミングでDisposeが実行される
        }

        public void CheckConnection(string connString, string command)
        {
            using var connection = new SqlConnection(connString);
            using var executeCommand = new SqlCommand(command, connection);

            // bad
            try
            {
                // すでに閉じられている場合はInvalidOperationExceptionが発生
                connection.Close();
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine("SQL実行でエラーが起きています");
                Console.WriteLine($"{e.ToString}");
            }

            // good
            if (connection.State != ConnectionState.Closed)
            {
                // すでに閉じられていない場合のみ実行する
                connection.Close();
            }
        }
    }
}