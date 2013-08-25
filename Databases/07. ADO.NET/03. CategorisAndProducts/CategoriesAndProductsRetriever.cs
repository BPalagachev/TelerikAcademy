// Write a program that retrieves from the Northwind database all product
// categories and the names of the products in each category. Can you do
// this with a single SQL query (with table join)?
 
using System;
using System.Linq;
using System.Data.SqlClient;
using System.Data;

public class CategoriesAndProductsRetriever
{
    public static void Main()
    {
        string localConnectionString = "Server=.\\; Database=northwind; Integrated Security=true";
        SqlConnection northwindDbConnection = new SqlConnection(localConnectionString);
        northwindDbConnection.Open();
        
        string query = @"
                        SELECT c.CategoryID, c.CategoryName, 
	                        STUFF( (SELECT ProductName + ', '
		                           FROM Products
		                           WHERE CategoryID = c.CategoryID
		                           FOR XML PATH(''),TYPE).value('(./text())[1]','VARCHAR(MAX)') 
		                           ,1, 2, '') AS Names
                        FROM Products p 
                        JOIN Categories c
                        ON p.CategoryID = c.CategoryID
                        GROUP BY  c.CategoryID, c.CategoryName";

        using (northwindDbConnection)
        {
            SqlCommand readCategoriesCmd =
                new SqlCommand(query, northwindDbConnection);

            SqlDataReader categoriesReader = readCategoriesCmd.ExecuteReader();

            using (categoriesReader)
            {
                while (categoriesReader.Read())
                {
                    string categoryName = (string)categoriesReader["CategoryName"];
                    string productNames = (string)categoriesReader["Names"];
                    Console.WriteLine("{0}: {1}", categoryName, productNames);
                }
            }
        }
    }
}
