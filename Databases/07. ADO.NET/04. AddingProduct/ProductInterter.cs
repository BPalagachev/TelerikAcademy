// Write a method that adds a new product in the products table in 
// the Northwind database. Use a parameterized SQL command.
 
using System;
using System.Linq;
using System.Data.SqlClient;
using System.Data;

public class ProductInterter
{
    private readonly static string localConnectionString = "Server=.\\; Database=northwind; Integrated Security=true";
    private static SqlConnection northwindDbConnection;

    public static void Main()
    {
        EstablishConnection();
        ProductDescriber newProduct = new ProductDescriber("Rakiq, mnogo fkusna", 1, 1, "100 kila", 0.01m, int.MaxValue, 155, 7, 3);
        
        using (northwindDbConnection)
        {
            int newProductId = InsertProduct(newProduct);
            Console.WriteLine("Newly inserted Product has ID: {0}", newProductId);
        }
    }

    private static void EstablishConnection()
    {
        northwindDbConnection = new SqlConnection(localConnectionString);
        northwindDbConnection.Open();
    }

    private static int InsertProduct(ProductDescriber product)
    {
        SqlCommand insertProductCmd = new SqlCommand(@"
            INSERT 
            INTO Products(ProductName, SupplierID, CategoryID, QuantityPerUnit, UnitPrice, UnitsOnOrder, ReorderLevel, Discontinued)
            VALUES (@ProductName, @SupplierID, @CategoryID, @QuantityPerUnit, @UnitPrice, @UnitsOnOrder, @ReorderLevel, @Discontinued)",
            northwindDbConnection);
        insertProductCmd.Parameters.AddWithValue("@ProductName", product.ProductName);
        insertProductCmd.Parameters.AddWithValue("@SupplierID", product.SuplierID);
        insertProductCmd.Parameters.AddWithValue("@CategoryID", product.CategoryID);
        insertProductCmd.Parameters.AddWithValue("@QuantityPerUnit", product.QuantityPerUnit);
        insertProductCmd.Parameters.AddWithValue("@UnitPrice", product.UnitPrice);
        insertProductCmd.Parameters.AddWithValue("@UnitsOnOrder", product.UnitsOnOrder);
        insertProductCmd.Parameters.AddWithValue("@ReorderLevel", product.ReorderLevel);
        insertProductCmd.Parameters.AddWithValue("@Discontinued", product.Discontinued);

        insertProductCmd.ExecuteNonQuery();

        SqlCommand selectIdentityCmd = new SqlCommand("SELECT @@Identity", northwindDbConnection);
        int insertedRecordID = (int)(decimal)selectIdentityCmd.ExecuteScalar();

        return insertedRecordID;
    }

}
