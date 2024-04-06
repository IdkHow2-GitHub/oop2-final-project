using SQLite;

namespace FinalProject.Data
{
    [SQLite.Table("book")]
    public class Book
    {
        [PrimaryKey, AutoIncrement]
        [SQLite.Column("id")]
        public int Id { get; set; }

        [SQLite.Column("title")]
        public string Title { get; set; }

        [SQLite.Column("author_name")]
        public string Author_name { get; set; }

        [SQLite.Column("genre")]
        public string Genre { get; set; }

        [SQLite.Column("stock")]
        public string Stock { get; set; }

        [SQLite.Column("released_year")]
        public string Released_year { get; set; }
    }
}
