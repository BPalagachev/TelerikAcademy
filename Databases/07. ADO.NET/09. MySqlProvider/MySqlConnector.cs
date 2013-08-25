// Download and install MySQL database, MySQL Connector/Net (.NET Data Provider for MySQL) + MySQL Workbench 
// GUI administration tool . Create a MySQL database to store Books (title, author, publish date and ISBN).
// Write methods for listing all books, finding a book by name and adding a book.

using System;
using System.Linq;
using MySql.Data.MySqlClient;
using System.Globalization;

/// <summary>
///  Execute install_Library.sql in the project folder to install the Library Database
/// </summary>
public class MySqlConnector
{
    private readonly static string localConnectionString = "Server=localhost;Database=Library;Uid=root;Pwd=1313;";
    private static MySqlConnection libraryDbConnection;

    static void Main()
    {
        EstablishConnection();

        using (libraryDbConnection)
        {
            //InsertBook("AAABBBCCC", "Test Author", DateTime.Now, "TEST ISBN");
            //ListAllBooks();

            SearchBooksByTitles("AAABBBCCC");
        }
    }

    private static void EstablishConnection()
    {
        libraryDbConnection = new MySqlConnection(localConnectionString);
        libraryDbConnection.Open();
    }

    private static void ListAllBooks()
    {
        MySqlCommand listAllCmd = new MySqlCommand(@"SELECT * FROM Books", libraryDbConnection);
        MySqlDataReader reader = listAllCmd.ExecuteReader();

        using (reader)
        {
            while (reader.Read())
            {
                string title = (string)reader["Title"];
                string autorName = (string)reader["Author"];
                DateTime publishDate = (DateTime)reader["PublishDate"];
                string formattedDate = publishDate.ToString("dd-MMM-yyyy", new CultureInfo("bg-BG"));
                string Isnb = (string)reader["ISBN"];
                Console.WriteLine("{0}, {1}, {2}, {3}",
                    title, 
                    autorName,
                    formattedDate,
                    Isnb);
            }
        }
    }

    private static void InsertBook(string title, string authorName, DateTime publishDate, string Isbn)
    {
        string query = @"INSERT INTO Books(Title, Author, PublishDate, ISBN) VALUES (@Title, @Author, @PublishDate, @ISBN)";
        MySqlCommand insertNewEntryCmd = new MySqlCommand(query, libraryDbConnection);
        insertNewEntryCmd.Parameters.AddWithValue("@Title", title);
        insertNewEntryCmd.Parameters.AddWithValue("@Author", authorName);
        insertNewEntryCmd.Parameters.AddWithValue("@ISBN", Isbn);
        MySqlParameter publishDateParameter = new MySqlParameter("@PublishDate", MySqlDbType.DateTime);
        publishDateParameter.Value = publishDate;
        insertNewEntryCmd.Parameters.Add(publishDateParameter);
        insertNewEntryCmd.ExecuteNonQuery();

    }

    private static void SearchBooksByTitles(string titleToMatch)
    {
        string query = @"SELECT * FROM Books WHERE Title = @Title";
        MySqlCommand listAllCmd = new MySqlCommand(query, libraryDbConnection);
        listAllCmd.Parameters.AddWithValue("@Title", titleToMatch);

        MySqlDataReader reader = listAllCmd.ExecuteReader();

        using (reader)
        {
            while (reader.Read())
            {
                string title = (string)reader["Title"];
                string autorName = (string)reader["Author"];
                DateTime publishDate = (DateTime)reader["PublishDate"];
                string formattedDate = publishDate.ToString("dd-MMM-yyyy", new CultureInfo("bg-BG"));
                string Isnb = (string)reader["ISBN"];
                Console.WriteLine("{0}, {1}, {2}, {3}",
                    title,
                    autorName,
                    formattedDate,
                    Isnb);
            }
        }
    }

}
