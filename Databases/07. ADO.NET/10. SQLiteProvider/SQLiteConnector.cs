// Re-implement task 9 with SQLite embedded DB (see http://sqlite.phxsoftware.com).

using System;
using System.Linq;
using System.Data.SQLite;

public class SQLiteConnector
{
    private static readonly string connectionString = @"Data Source=..\..\sqTestDB.db;FailIfMissing=False;";
    private static SQLiteConnection sqLiteConn;

    public static void Main(string[] args)
    {
        EstablishConnection();

        using (sqLiteConn)
        {
            //CreateTableBooks();
            //InsertBook("AAA", "BBBB", DateTime.Now, "Test Isbn");
            //ListAllBooks();
            SearchBooksByTitles("AAA");            
        }
    }

    private static void EstablishConnection()
    {
        sqLiteConn = new SQLiteConnection(connectionString);
        sqLiteConn.Open();
    }

    private static void CreateTableBooks()
    {
        string createTableQuery = @"CREATE TABLE Books(
                                      BookID INTEGER PRIMARY KEY NOT NULL,
                                      Title NVARCHAR(100) NOT NULL,
                                      Author NVARCHAR(100) NOT NULL, 
                                      PublishDate DATETIME NOT NULL, 
                                      ISBN NVARCHAR(100) NOT NULL
                                    );";
        SQLiteCommand cmdCreateBooksTable = new SQLiteCommand(createTableQuery, sqLiteConn);

        cmdCreateBooksTable.ExecuteNonQuery();
    }

    private static void InsertBook(string title, string authorName, DateTime publishDate, string Isbn)
    {
        string query = @"INSERT INTO Books(Title, Author, PublishDate, ISBN) VALUES (@Title, @Author, @PublishDate, @ISBN)";
        SQLiteCommand insertNewEntryCmd = new SQLiteCommand(query, sqLiteConn);
        insertNewEntryCmd.Parameters.AddWithValue("@Title", title);
        insertNewEntryCmd.Parameters.AddWithValue("@Author", authorName);
        insertNewEntryCmd.Parameters.AddWithValue("@ISBN", Isbn);
        SQLiteParameter publishDateParameter = new SQLiteParameter("@PublishDate", System.Data.DbType.DateTime);
        publishDateParameter.Value = publishDate;
        insertNewEntryCmd.Parameters.Add(publishDateParameter);
        insertNewEntryCmd.ExecuteNonQuery();

    }

    private static void ListAllBooks()
    {
        SQLiteCommand listAllCmd = new SQLiteCommand(@"SELECT * FROM Books", sqLiteConn);
        SQLiteDataReader reader = listAllCmd.ExecuteReader();

        using (reader)
        {
            while (reader.Read())
            {
                string title = (string)reader["Title"];
                string autorName = (string)reader["Author"];
                DateTime publishDate = (DateTime)reader["PublishDate"];
                string formattedDate = publishDate.ToString("dd-MMM-yyyy", new System.Globalization.CultureInfo("bg-BG"));
                string Isnb = (string)reader["ISBN"];
                Console.WriteLine("{0}, {1}, {2}, {3}",
                    title,
                    autorName,
                    formattedDate,
                    Isnb);
            }
        }
    }

    private static void SearchBooksByTitles(string titleToMatch)
    {
        string query = @"SELECT * FROM Books WHERE Title = @Title";
        SQLiteCommand listAllCmd = new SQLiteCommand(query, sqLiteConn);
        listAllCmd.Parameters.AddWithValue("@Title", titleToMatch);

        SQLiteDataReader reader = listAllCmd.ExecuteReader();

        using (reader)
        {
            while (reader.Read())
            {
                string title = (string)reader["Title"];
                string autorName = (string)reader["Author"];
                DateTime publishDate = (DateTime)reader["PublishDate"];
                string formattedDate = publishDate.ToString("dd-MMM-yyyy", new System.Globalization.CultureInfo("bg-BG"));
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
