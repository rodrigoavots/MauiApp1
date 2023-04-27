namespace MauiApp1.Repositorio
{
    public interface IDataStore<T>
    {
        Task<int> AddAsync(T item);
        Task<int> UpdateAsync(T item);
        Task<int> DeleteAsync(int id);
        Task<T> GetAsync(int id);
    }
}
