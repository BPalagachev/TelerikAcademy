using System;

public class ProductDescriber
{
    public string ProductName { get; set; }

    public int SuplierID { get; set; }

    public int CategoryID { get; set; }

    public string QuantityPerUnit { get; set; }

    public decimal UnitPrice { get; set; }

    public int UnitsInStock { get; set; }

    public int UnitsOnOrder { get; set; }

    public int ReorderLevel { get; set; }

    public int Discontinued { get; set; }

    public ProductDescriber(string productName, int suplierID, int categoryID, string quantityPerUnit, 
        decimal unitPrice, int unitsInStock, int unitsOnOrder, int reorderLevel, int discontinued)
    {
        this.ProductName = productName;
        this.SuplierID = suplierID;
        this.CategoryID = categoryID;
        this.QuantityPerUnit = quantityPerUnit;
        this.UnitPrice = unitPrice;
        this.UnitsInStock = unitsInStock;
        this.UnitsOnOrder = unitsOnOrder;
        this.ReorderLevel = reorderLevel;
        this.Discontinued = discontinued;
    }
}
