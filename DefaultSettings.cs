namespace MauiApp1
{
    public static class DefaultSettings
    {
        public static string DbFileName = "dbTest.db";
        public static string PathApp = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        public static string PathDatabase = Path.Combine(PathApp, "Database");
    }
}
