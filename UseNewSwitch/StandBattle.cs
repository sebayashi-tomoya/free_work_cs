namespace UseNewSwitch
{
    public class StandBattle
    {
        private void SetStand(Character character)
        {
            var stand = character switch
            {
                Character.Jotaro => "スタープラチナ",
                Character.Dio => "ザ・ワールド",
                _ => throw new ArgumentException(),
            };
        }

        private void WriteStand()
        {
            var character = Character.Dio;
            Console.Write(character switch
            {
                Character.Jotaro => "スタープラチナ",
                Character.Dio => "ザ・ワールド",
                _ => throw new ArgumentException(),
            });
        }

        private void Attack(Character character)
        {
            switch (character)
            {
                case Character.Jotaro:
                    this.StopTime();
                    this.OraOra();
                    break;
                case Character.Dio:
                    this.StopTime();
                    this.UseRoadRoller();
                    break;
            }
        }

        private void StopTime() => Console.WriteLine("時よ止まれ！");
        private void UseRoadRoller() => Console.WriteLine("ロードローラーだッ! ");
        private void OraOra() => Console.WriteLine("オラオラオラオラオラァ！");
    }
}