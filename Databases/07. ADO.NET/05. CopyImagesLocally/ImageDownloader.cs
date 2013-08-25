// Write a program that retrieves the images for all categories in the Northwind database and stores them as JPG files in the file system.

using System;
using System.Linq;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Text.RegularExpressions;

public class ImageDownloader
{
    private readonly static string fileRoot = @"..\..\CategoriesImages\";
    private readonly static string localConnectionString = "Server=.\\; Database=northwind; Integrated Security=true";
    private static SqlConnection northwindDbConnection;

    public static void Main()
    {
        EstablishConnection();
        Console.WriteLine("Connection Established");

        using (northwindDbConnection)
        {
            SqlDataReader imagesReader = GetImageReader();

            while (imagesReader.Read())
            {
                string categoryName = EscapeFileName((string)imagesReader["CategoryName"]);
                string fileName =  string.Format("{0}{1}{2}", fileRoot, categoryName, ".jpg");
                byte[] image = (byte[])imagesReader["Picture"];
                WriteBinaryFile(fileName, image);
            }
        }

    }

    private static void EstablishConnection()
    {
        northwindDbConnection = new SqlConnection(localConnectionString);
        northwindDbConnection.Open();
    }

    private static void WriteBinaryFile(string fileName, byte[] fileContents)
    {
        FileStream stream = File.OpenWrite(fileName);
        using (stream)
        {
            stream.Write(fileContents, 0, fileContents.Length);
        }
    }

    private static SqlDataReader GetImageReader()
    {
        SqlCommand getImagesCmd = new SqlCommand("SELECT CategoryName, Picture FROM Categories", northwindDbConnection);
        SqlDataReader imagesReader = getImagesCmd.ExecuteReader();
        return imagesReader;
    }


    static string EscapeFileName(string fileName)
    {
        string validFileName = Regex.Replace(fileName, @"(\\+|/+)", d => "");
        return validFileName;
    }
}
