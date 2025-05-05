using System.Runtime.ExceptionServices;

namespace ExceptionBestPractice
{
    public class ExceptionSample
    {
        /// <summary> コンストラクタ </summary>
        public ExceptionSample()
        {
            try
            {
                ReThrowException();
            }
            catch (Exception e)
            {
                // スタックトレースをコンソールへ出力
                Console.WriteLine(e.StackTrace);
            }
        }

        private void ReThrowException()
        {
            ExceptionDispatchInfo? edi = null;
            try
            {
                ThrowException();
            }
            catch (Exception e)
            {
                // Captureメソッドを使用して例外情報を保持する
                edi = ExceptionDispatchInfo.Capture(e);
            }

            // 例外情報が格納されている場合にThrowメソッドで再スローする
            if (edi is not null) edi.Throw();
        }

        private void ThrowException()
        {
            throw new Exception("例外が発生しました");
        }
    }
}