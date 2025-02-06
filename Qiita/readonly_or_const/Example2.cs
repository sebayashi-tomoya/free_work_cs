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