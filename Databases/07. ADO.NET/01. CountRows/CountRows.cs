// Write a program that retrieves from the Northwind sample database in
// MS SQL Server the number of  rows in the Categories table.

using System;
using System.Linq;
using System.Data.SqlClient;
using System.Data;
using _01.CountRows;

class CountRows
{
    static void Main(string[] args)
    {
        SqlConnection northwindDbCon = new SqlConnection(Settings.Default.DBConnectionString);
        northwindDbCon.Open();

        using (northwindDbCon)
        {
            SqlCommand cmdCount = new SqlCommand("SELECT Count(*) FROM Categories", northwindDbCon);
            int categoriesCount = (int)cmdCount.ExecuteScalar();
            Console.WriteLine("There is a total of {0} categories", categoriesCount);
        }
    }
}
