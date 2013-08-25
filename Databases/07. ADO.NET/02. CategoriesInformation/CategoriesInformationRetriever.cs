// Write a program that retrieves the name and description of all categories in the Northwind DB.
 
using System;
using System.Linq;
using System.Data.SqlClient;
using System.Data;

public class CategoriesInformationRetriever
{
    public static void Main()
    {
        string localConnectionString = "Server=.\\; Database=northwind; Integrated Security=true";
        SqlConnection northwindDbConnection = new SqlConnection(localConnectionString);
        northwindDbConnection.Open();

        using (northwindDbConnection)
        {
            SqlCommand readCategoriesCmd =
                new SqlCommand("SELECT [CategoryName], [Description] FROM Categories", northwindDbConnection);

            SqlDataReader categoriesReader = readCategoriesCmd.ExecuteReader();

            using (categoriesReader)
            {
                while (categoriesReader.Read())
                {
                    string categoryName = (string)categoriesReader["CategoryName"];
                    string categoryDesc = (string)categoriesReader["Description"];
                    Console.WriteLine("{0}: {1}", categoryName, categoryDesc);
                }
            }
        }
    }
}
