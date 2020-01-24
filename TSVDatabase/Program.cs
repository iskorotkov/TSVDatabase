namespace TSVDatabase
{
    static class Program
    {
        private static void Main()
        {
            var p = new Activity(DbPreferences.ResourceManager.GetString("Path"), new ConsoleReader(), new ConsoleWriter());
            p.ProcessInput();
        }
    }
}
