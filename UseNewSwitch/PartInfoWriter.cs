namespace UseNewSwitch
{
    public class PartInfoWriter
    {
        public PartInfoWriter()
        {
            while (true)
            {
                Console.WriteLine("1~5の好きな数字を半角で入力してね");

                var input = Console.ReadLine();

                if (int.TryParse(input, out int partNum) && partNum <= 5 && partNum >= 1)
                {
                    (var mainCharacter, var subTitle) = this.NewSwitch(partNum);
                    Console.WriteLine($"主人公：{mainCharacter}");
                    Console.WriteLine($"サブタイトル：{subTitle}");
                    break;
                }
                else
                {
                    Console.WriteLine("無駄無駄無駄ーーーっ！！");
                    continue;
                }
            }
        }

        private (string, string) NewSwitch(int partNum)
        {
            return partNum switch
            {
                1 => ("ジョナサン・ジョースター", "ファントムブラッド"),
                2 => ("ジョセフ・ジョースター", "戦闘潮流"),
                3 => ("空条承太郎", "スターダストクルセイダーズ"),
                4 => ("東方仗助", "ダイアモンドは砕けない"),
                5 => ("ジョルノ・ジョバーナ", "黄金の風"),
                _ => throw new ArgumentException("呼び出し元で制限をしているので1~5以外の数字はここに到達しない想定"),
            };
        }

        private (string, string) OldSwitch(int partNum)
        {
            (string, string) result;
            switch (partNum)
            {
                case 1:
                    result = ("ジョナサン・ジョースター", "ファントムブラッド");
                    break;
                case 2:
                    result = ("ジョセフ・ジョースター", "戦闘潮流");
                    break;
                case 3:
                    result = ("空条承太郎", "スターダストクルセイダーズ");
                    break;
                case 4:
                    result = ("東方仗助", "ダイアモンドは砕けない");
                    break;
                case 5:
                    result = ("ジョルノ・ジョバーナ", "黄金の風");
                    break;
                default:
                    throw new ArgumentException();
            }
            return result;
        }
    }
}