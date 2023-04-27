using SQLite;

namespace MauiApp1.Database
{
    public class DatabaseService : IDatabaseService
    {
        public const SQLite.SQLiteOpenFlags Flags =
            // open the database in read/write mode
            SQLite.SQLiteOpenFlags.ReadWrite |
            // create the database if it doesn't exist
            SQLite.SQLiteOpenFlags.Create |
            // enable multi-threaded database access
            SQLite.SQLiteOpenFlags.SharedCache;


        private SQLiteAsyncConnection Connection { get; set; }
        public SQLiteAsyncConnection GetConnectionAsync()
        {
            return Connection;
        }


        private static string DbPath { get; } = Path.Combine(DefaultSettings.PathDatabase, DefaultSettings.DbFileName);

        public DatabaseService()
        {
            //Cria as pastas defaults
            CreatePasteDefaults();

            //Somente Android versão 12 pra cima
            //SQLitePCL.Batteries_V2.Init();

            //Se o banco de dados já existe, NÃO copia.
            if (!File.Exists(DbPath))
            {
                //Leitura do arquivo do MauiAssets - Raw
                using Stream stream = FileSystem.OpenAppPackageFileAsync(DefaultSettings.DbFileName).Result;
                //Verifica se o arquivo existe no manifesto
                if (stream != null)
                {
                    using MemoryStream memoryStream = new MemoryStream();
                    stream.CopyTo(memoryStream);

                    //Dando acesso negado
                    File.WriteAllBytes(DbPath, memoryStream.ToArray());
                }
            }
            Connection = new SQLiteAsyncConnection(DbPath, Flags, false);
        }

        /// <summary>
        /// Cria as pastas padrões necessários para o manuseio de arquivos
        /// </summary>
        private void CreatePasteDefaults()
        {
            //Cria a pasta do Banco de Dados se não existir
            if (!Directory.Exists(DefaultSettings.PathDatabase))
            {
                Directory.CreateDirectory(DefaultSettings.PathDatabase);
            }
        }
    }
}
