using System;
using System.Linq;
using EntityFrameworkHomework.Data;
using System.Transactions;

namespace _09.Transactions
{
    public class TransactionMaker
    {
        static void Main()
        {
            var dbConteext = new NorthwindEntities();
            using (dbConteext)
            {
                var productDetails = dbConteext.Products.Take(3);

                using (TransactionScope scope = new TransactionScope())
                {
                    foreach (var item in productDetails)
                    {
                        Console.WriteLine(item.CategoryID);
                    }
                    var firstProduct = productDetails.First();
                    var secondProduct = productDetails.First();
                    var thirdProduct = productDetails.First();
                    Console.WriteLine(firstProduct.ProductID);
                    Console.WriteLine(secondProduct.ProductID);
                    Console.WriteLine(thirdProduct.ProductID);      

                    
                    //var newOrder = new Order();
                    //newOrder.Order_Details.Add(firstProduct);
                    //dbConteext.SaveChanges();
                    //newOrder.Order_Details.Add(secondProduct);
                    //dbConteext.SaveChanges();
                    //newOrder.Order_Details.Add(thirdProduct);
                    //dbConteext.SaveChanges();
                    scope.Complete();
                }  
            }
        }
    }
}
