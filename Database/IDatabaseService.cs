using SQLite;

namespace MauiApp1.Database
{
    public interface IDatabaseService
    {
        SQLiteAsyncConnection GetConnectionAsync();
    }
}
