// Create an Excel file with 2 columns: name and score.
// Write a program that reads your MS Excel file through the OLE DB
// data provider and displays the name and score row by row.

//Implement appending new rows to the Excel file.

using System;
using System.Linq;
using System.Data.OleDb;

class ExcelReader
{
    private static readonly string excelConnectionString =
    @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=..\..\ExcelTestFile.xlsx;
Extended Properties=""Excel 12.0 Xml;HDR=YES"";";
    private static OleDbConnection dbConn;
  
    static void Main()
    {
        EstablishConnection();

        using (dbConn)
        {
            AppendRow("Lelq Zdrawka", 100d);

            OleDbDataReader infoReader = GetAllEntriesReader();
            while (infoReader.Read())
            {
                string name = infoReader.GetString(0);
                double score = infoReader.GetDouble(1);
                Console.WriteLine("{0}: {1} points", name, score);
            }
        }
    }

    private static void EstablishConnection()
    {
        dbConn = new OleDbConnection(excelConnectionString);
        dbConn.Open();
    }

    private static OleDbDataReader GetAllEntriesReader()
    {
        string getAllEntriesQuery = @"SELECT * FROM [Sheet1$]";
        OleDbCommand getInformation = new OleDbCommand(getAllEntriesQuery, dbConn);
        OleDbDataReader infoReader = getInformation.ExecuteReader();

        return infoReader;
    }

    private static void AppendRow(string name, double points)
    {
        OleDbCommand appendLineCmd = new OleDbCommand(@"INSERT INTO [Sheet1$](Name, Score) VALUES (@Name, @Score) ", dbConn);
        appendLineCmd.Parameters.AddWithValue("@Name", name);
        appendLineCmd.Parameters.AddWithValue("@Score", points);
        appendLineCmd.ExecuteNonQuery();
    }
}
