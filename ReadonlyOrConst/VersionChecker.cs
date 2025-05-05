namespace ReadonlyOrConst
{
    public class VersionChecker
    {
        public VersionChecker()
        {
            if (VersionDefinition.CurrentVersion >= VersionDefinition.AvailableVersion)
            {
                Console.WriteLine($"This version is available!");
            }
        }
    }
}