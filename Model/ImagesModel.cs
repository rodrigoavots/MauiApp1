using SQLite;

namespace MauiApp1.Model
{
    public class Images
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public byte[] Thumbnail { get; set; }
    }
}
