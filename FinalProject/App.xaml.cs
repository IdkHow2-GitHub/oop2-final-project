using FinalProject.Data;

namespace FinalProject
{
    public partial class App : Application
    {
        public App()
        {

            InitializeComponent();

            // Create SQLite database manager
            var sqliteManager = new SqliteManager();

            //delete all book
            //sqliteManager.DeleteAllBooks();
            // Add 10 books to the database
            InitializeDatabase(sqliteManager);

            MainPage = new AppShell();
        }

      
        private async void InitializeDatabase(SqliteManager sqliteManager)
        {
            for (int i = 0; i < 10; i++)
            {
                // Check if the book already exists before adding it
                if (!await sqliteManager.DoesBookExist($"Book {i + 1}"))
                {
                    var newBook = new Book
                    {
                        Title = $"Book {i + 1}",
                        Author_name = $"Author {i + 1}",
                        Genre = $"Genre {i + 1}",
                        Stock = $"{i + 1}",
                        Released_year = $"{DateTime.Now.Year - i}"
                    };

                    await sqliteManager.AddBook(newBook);
                }
            }
        }

    }
}
