// Write a program that reads a string from the console and finds all 
// products that contain this string. Ensure you handle correctly characters like ', %, ", \ and _.

using System;
using System.Linq;
using System.Data.SqlClient;
using System.Data;

public class ProductSearcher
{
    private readonly static string localConnectionString = "Server=.\\; Database=northwind; Integrated Security=true";
    private static SqlConnection northwindDbConnection;

    public static void Main()
    {
        Console.WriteLine("Establishing Connection ...");
        EstablishConnection();
        Console.WriteLine("Connection Established.");
        string userInputToMatch = ParseUserInput();

        using (northwindDbConnection)
        {
            SqlDataReader matchedProductsReader = GetMatchedProductsReader(userInputToMatch);
            Console.WriteLine("Search Results: ");
            while (matchedProductsReader.Read())
            {
                Console.WriteLine("{0}", matchedProductsReader["ProductName"]);
            }
        }
    }

    private static string ParseUserInput()
    {
        Console.Write("Search for: ");
        string userInput = Console.ReadLine();
        userInput = userInput.Replace("%", "   ");
        return userInput;
    }
    
    private static void EstablishConnection()
    {
        northwindDbConnection = new SqlConnection(localConnectionString);
        northwindDbConnection.Open();
    }

    private static SqlDataReader GetMatchedProductsReader(string productName)
    {
        //SqlCommand getProductsCmd = northwindDbConnection.CreateCommand();
        //getProductsCmd.CommandText = "SELECT ProductName FROM Products WHERE ProductName LIKE @ProductName"

        SqlCommand getProductCmd = new SqlCommand(
            @"",
            northwindDbConnection);
        getProductCmd.CommandText += "SELECT ProductName FROM Products WHERE ProductName LIKE '%' + @ProductName + '%'";
        getProductCmd.Parameters.Add("@ProductName", SqlDbType.NVarChar);
        getProductCmd.Parameters["@ProductName"].Value = productName;
        SqlDataReader reader = getProductCmd.ExecuteReader();
        return reader;
    }
}
