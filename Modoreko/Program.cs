using System;
using System.Collections.Generic;
using System.Threading;

class Program
{
    static void Main()
    {
        // Stackで位置の履歴を記録
        var history = new Stack<int>();
        // 現在の位置
        int position = 0;
        // 巻き戻しが実行中か
        bool isRewinding = false;

        Console.WriteLine("Enterでモドレコ（逆再生）を開始します。Escで終了");

        while (true)
        {
            if (Console.KeyAvailable)
            {
                var key = Console.ReadKey(true).Key;

                if (key == ConsoleKey.Enter)
                {
                    // Enterキー押下で巻き戻しを実行する
                    isRewinding = true;
                }
                else if (key == ConsoleKey.Escape)
                {
                    // Escでアプリ終了
                    break;
                }
            }

            if (isRewinding)
            {
                // 巻き戻し実行中の処理
                if (history.Count > 0)
                {
                    // 過去の位置に戻して位置を描画
                    position = history.Pop();
                    Draw(position);
                }
                else
                {
                    // Stackがない場合は巻き戻しを終了して通常の方向へ
                    isRewinding = false;
                    Console.WriteLine("巻き戻し終了！");
                }
            }
            else
            {
                // 巻き戻し実行中は現在位置を記録して前身させる
                history.Push(position);
                position++;
                Draw(position);
            }

            Thread.Sleep(300); // 動作間隔
        }
    }

    static void Draw(int pos)
    {
        Console.Clear();
        Console.WriteLine("位置: " + pos);
        Console.WriteLine(new string(' ', pos) + "●"); // ●が進んだり戻ったり
    }
}