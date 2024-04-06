using FinalProject.Data;
using System.Diagnostics;

namespace FinalProject;

public partial class TestDB : ContentPage
{
    private readonly SqliteManager _dbService;
    private Book _selectedBook;
    public TestDB(SqliteManager dbService)
    {
        InitializeComponent();
        _dbService = dbService;

        if (_dbService != null && _dbService.IsDatabaseConnected())
        {
            Debug.WriteLine("Database connection check: Connected.");
            LoadBooks();
        }
        else
        {
            Debug.WriteLine("Database connection check: Not connected.");
        }

    }

    private async void LoadBooks()
    {
        listView.ItemsSource = await _dbService.ReadAllBooks();
    }

    private void listView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        _selectedBook = (Book)e.SelectedItem;
        if (_selectedBook != null)
        {
            titleEntry.Text = _selectedBook.Title;
            authorFirstNameEntry.Text = _selectedBook.Author_name;
            genreEntry.Text = _selectedBook.Genre;
            stockEntry.Text = _selectedBook.Stock;
            released_yearEntry.Text = _selectedBook.Released_year;
        }
    }
    private async void saveButton_Clicked(object sender, EventArgs e)
    {
        if (_selectedBook == null)
        {
            // Add new book
            var newBook = new Book
            {
                Title = titleEntry.Text,
                Author_name = authorFirstNameEntry.Text,
                Genre = genreEntry.Text
            };
            await _dbService.AddBook(newBook);
        }
        else
        {
            // Update selected book
            _selectedBook.Title = titleEntry.Text;
            _selectedBook.Author_name = authorFirstNameEntry.Text;
            _selectedBook.Genre = genreEntry.Text;
            await _dbService.UpdateBook(_selectedBook);
        }
        // Reload books after adding or updating
        LoadBooks();

        // Clear input fields
        titleEntry.Text = string.Empty;
        authorFirstNameEntry.Text = string.Empty;
        genreEntry.Text = string.Empty;
        _selectedBook = null;
    }
}