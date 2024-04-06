using SQLite;
using System.Diagnostics;


namespace FinalProject.Data
{
    public class SqliteManager
    {
        private const string DB_NAME = "FinalProject.db3";
        private readonly SQLiteAsyncConnection _connection;

        public SqliteManager()
        {
            _connection = new SQLiteAsyncConnection(Path.Combine(FileSystem.AppDataDirectory, DB_NAME));
            _connection.CreateTableAsync<Book>();
            var dbPath = Path.Combine(FileSystem.AppDataDirectory, DB_NAME);
            // Log the database path to debug output
            Debug.WriteLine("Database Path: " + dbPath);
        }

        //// Dispose method to release SQLite connection
        //public async Task CloseConnectionAsync()
        //{
        //    await _connection.CloseAsync().ConfigureAwait(false);
        //}

        // check the connection
        public bool IsDatabaseConnected()
        {
            //check the database connection status.
            return _connection != null;
        }

        // Check if a book with the given title exists in the database
        public async Task<bool> DoesBookExist(string title)
        {
            var existingBook = await _connection.Table<Book>().FirstOrDefaultAsync(b => b.Title == title);
            return existingBook != null;
        }

        // read all
        public async Task<List<Book>> ReadAllBooks()
        {
            return await _connection.Table<Book>().ToListAsync();
        }

        //read by ID
        public async Task<Book> ReadBookById(int id)
        {
            return await _connection.Table<Book>().Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        //Add
        public async Task AddBook(Book book)
        {
            await _connection.InsertAsync(book);
        }

        //Updatae
        public async Task UpdateBook(Book book)
        {
            await _connection.UpdateAsync(book);
        }
        //Delete
        public async Task Delete(Book book)
        {
            await _connection.DeleteAsync(book);
        }

        // Delete all records from the Book table
        public async Task DeleteAllBooks()
        {
            
            await _connection.DeleteAllAsync<Book>();
        }

    }
}
