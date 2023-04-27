using MauiApp1.Database;
using MauiApp1.Model;
using SQLite;

namespace MauiApp1.Repositorio
{
    public class ImagesRepositorio : IDataStore<Images>
    {
        SQLiteAsyncConnection conn;

        public ImagesRepositorio(IDatabaseService dbService)
        {
            conn = dbService.GetConnectionAsync();
        }

        public Task<int> AddAsync(Images item)
        {
            return conn.InsertAsync(item);
        }

        public Task<int> UpdateAsync(Images item)
        {
            return conn.UpdateAsync(item);
        }

        public Task<int> DeleteAsync(int id)
        {
            return conn.DeleteAsync<Images>(id);
        }

        public Task<Images> GetAsync(int id)
        {
            return conn.Table<Images>().Where(u => u.Id == id).FirstOrDefaultAsync();
        }
    }
}
