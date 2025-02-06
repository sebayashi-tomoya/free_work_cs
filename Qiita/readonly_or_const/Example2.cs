namespace free_work_cs.Qiita.readonly_or_const
{
    public class Example2
    {
        public Example2()
        {
            if (VersionDefinition.CurrentVersion >= VersionDefinition.AvailableVersion)
            {
                Console.WriteLine($"This version is available!");
            }
        }
    }
}