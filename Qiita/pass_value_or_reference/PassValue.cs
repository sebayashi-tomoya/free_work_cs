namespace free_work_cs.Qiita.pass_value_or_reference
{
    class PassValue
    {
        public PassValue()
        {
            // ref (引数で渡した値も変更される)
            int before = 1;
            this.UseRef(ref before);
            Console.WriteLine(before); // 出力：2

            // out (複数の返り値を受け取ることができる)
            before = 1;
            if (this.UseOut(before, out int outNum))
            {
                Console.WriteLine(outNum); // 出力：2
            }
        }

        // refを使ったメソッド
        private void UseRef(ref int before)
        {
            before++;
        }

        //inを使ったメソッド
        // private int UseIn(in int before)
        // {
        //     return before++; // 値変更不可のためエラー
        // }

        // outを使ったメソッド
        private bool UseOut(int before, out int incremented)
        {
            // インクリメント後の値の範囲チェックとインクリメント後の値を同時にreturn
            incremented = before + 1;
            return incremented > 0;
        }
    }
}