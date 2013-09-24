using System;
using System.Collections.Generic;
using System.Linq;
using Bookstore.Data;
using System.Globalization;
using System.Transactions;

public class BookstoreDAL
{
    public static readonly string DateTimeFormatStr = "d-MMM-yyyy";

    // Task 7
    public static IList<QueryResult> ConductByAuthorQuery(string authorName)
    {
        var dbContext = new BookstoreEntities();
        using (dbContext)
        {
            var matchedBooks =
                from r in dbContext.Reviews.Include("Authors")
                join b in dbContext.Books on r.BookId equals b.BookId
                where b.Authors.Any(a=>a.Name.ToLower() == authorName.ToLower())
                orderby r.Creatation, r.ReviewText
                select new QueryResult()
                {
                    Date = r.Creatation,
                    Content = r.ReviewText,
                    BookTitle = b.Title,
                    BookUrl = b.WebSite,
                    BookAuthors = b.Authors.Select(x => x.Name)
                };

            return matchedBooks.ToList();
        }
    }

    // Task 6
    public static IList<QueryResult> ConductByDateQuery(string startDateStr, string endDateStr)
    {
          var dbContext = new BookstoreEntities();
          using (dbContext)
          {
             
              DateTime startDate = ParseDate(DateTimeFormatStr, startDateStr);
              DateTime endDate = ParseDate(DateTimeFormatStr, endDateStr);

             var matchedBooks =
                 from r in dbContext.Reviews.Include("Authors")
                 join b in dbContext.Books on r.BookId equals b.BookId
                 where r.Creatation >= startDate && r.Creatation <= endDate
                 orderby r.Creatation, r.ReviewText
                 select new QueryResult()
                 {
                     Date = r.Creatation,
                     Content = r.ReviewText,
                     BookTitle = b.Title,
                     BookUrl = b.WebSite,
                     BookAuthors = b.Authors.Select(x=>x.Name)
                 };

             return matchedBooks.ToList();
          }
    }

    // Task 5
    public static IList<Book> SearchForBooks(string bookTitle, string authorName, string bookIsbn)
    {
         var dbContext = new BookstoreEntities();
         using (dbContext)
         {
             var matchedBooks =
                 from b in dbContext.Books.Include("Reviews")
                 select b;

             if (bookTitle != null)
             {
                 matchedBooks = matchedBooks.Where(x => x.Title.ToLower() == bookTitle.ToLower());
             }

             if (bookIsbn != null)
             {
                 matchedBooks = matchedBooks.Where(b => b.Isbn == bookIsbn);
             }

             if (authorName != null)
             {
                 matchedBooks = matchedBooks.Where(b => b.Authors.Any(a => a.Name.ToLower() == authorName.ToLower()));
             }

             matchedBooks = matchedBooks.OrderBy(x => x.Title);
             return matchedBooks.ToList();
         }
    }

    // Task 3
    public static void AddBook(IList<string> authors, string title, string isbn, string price, string webSite)
    {
        var dbContext = new BookstoreEntities();
        using (dbContext)
        {
            Book newBook = new Book();

            LoadOrCreateAuthors(dbContext, newBook, authors);
            newBook.Title = title;
            newBook.Isbn = isbn;
            if (price != null)
            {
                newBook.Price = decimal.Parse(price);
            }
            newBook.WebSite = webSite;

            dbContext.Books.Add(newBook);
            dbContext.SaveChanges();
        }

    }

    // Task 4
    public static void AddComplexBooks(IList<string> authors, string title, 
        string isbn, string price, string webSite, IList<Tuple<string, string, string>> reviews)
    {
         var dbContext = new BookstoreEntities();
         var tran = new TransactionScope();
         using (tran)
         {
             using (dbContext)
             {
                 Book newBook = new Book();

                 LoadOrCreateAuthors(dbContext, newBook, authors);
                 newBook.Title = title;
                 newBook.Isbn = isbn;
                 if (price != null)
                 {
                     newBook.Price = decimal.Parse(price);
                 }
                 newBook.WebSite = webSite;

                 dbContext.Books.Add(newBook);
                 dbContext.SaveChanges();
                 SaveReviews(dbContext, newBook, reviews);
                 tran.Complete();
             }
         }
    }

    private static void SaveReviews(BookstoreEntities dbContext, Book newBook,
        IList<Tuple<string, string, string>> reviews)
    {
        foreach (var review in reviews)
        {
            var newReview = new Review();
            newReview.ReviewText = review.Item1;
            if (review.Item2 != null)
            {
                newReview.Author = GetOrCreateSingleAuthor(dbContext, review.Item2);
            }
            if (review.Item3 != null)
            {
                newReview.Creatation = ParseDate(DateTimeFormatStr, review.Item3);
            }
            else
            {
                newReview.Creatation = DateTime.Now;
            }
            newBook.Reviews.Add(newReview);
            dbContext.Reviews.Add(newReview);
            dbContext.SaveChanges();
        }
        
    }

    private static DateTime ParseDate(string format, string dateStr)
    {
        DateTime date = DateTime.ParseExact(dateStr, format, CultureInfo.InvariantCulture);
        return date;
    }

    private static Author GetOrCreateSingleAuthor(BookstoreEntities dbContext, string authorName)
    {
        var existingAuthor =
                (from author in dbContext.Authors
                 where author.Name == authorName
                 select author).FirstOrDefault();

        if (existingAuthor == null)
        {
            Author newAuthor = new Author();
            newAuthor.Name = authorName;
            dbContext.Authors.Add(newAuthor);
            //dbContext.SaveChanges();
            return newAuthor;
        }
        else
        {
            return existingAuthor;
        }
    }

    private static void LoadOrCreateAuthors(BookstoreEntities dbContext, Book newBook, IList<string> authors)
    {
        foreach (var authorName in authors)
        {
            var existingAuthor =
                (from author in dbContext.Authors
                 where author.Name == authorName
                 select author).FirstOrDefault();

            if (existingAuthor == null)
            {
                Author newAuthor = new Author();
                newAuthor.Name = authorName;
                dbContext.Authors.Add(newAuthor);
                dbContext.SaveChanges();
                newBook.Authors.Add(newAuthor);
            }
            else
            {
                newBook.Authors.Add(existingAuthor);
            }
        }
    }
}