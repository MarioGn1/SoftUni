using BookShop.Data;
using BookShop.Initializer;
using BookShop.Models.Enums;
using System;
using System.Globalization;
using System.Linq;
using System.Text;

namespace BookShop
{
    public class StartUp
    {
        public static void Main()
        {
            using var db = new BookShopContext();
            //DbInitializer.ResetDatabase(db);

            //TASK 1
            //Console.WriteLine(GetBooksByAgeRestriction(db, "teEN"));
            //TASK 2
            //Console.WriteLine(GetGoldenBooks(db));
            //TASK 3
            //Console.WriteLine(GetBooksByPrice(db));
            //TASK 4
            //Console.WriteLine(GetBooksNotReleasedIn(db, 2000));
            //TASK 5
            //Console.WriteLine(GetBooksByCategory(db, "horRor  mystEry    draMa"));
            //TASK 6
            //Console.WriteLine(GetBooksReleasedBefore(db, "12-04-1992"));
            //TASK 7
            //Console.WriteLine(GetAuthorNamesEndingIn(db, "dy"));
            //TASK 8
            //Console.WriteLine(GetBookTitlesContaining(db, "sK"));
            //TASK 9
            Console.WriteLine(GetBooksByAuthor(db, "pO"));
            //TASK 10
            //Console.WriteLine(CountBooks(db, 40));
            //TASK 11
            //Console.WriteLine(CountCopiesByAuthor(db));
            //TASK 12
            //Console.WriteLine(GetTotalProfitByCategory(db));
            //TASK 13
            //Console.WriteLine(GetMostRecentBooks(db));
            //TASK 14
            //IncreasePrices(db);
            //TASK 15
            //Console.WriteLine(RemoveBooks(db));

        }

        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            var books = context.Books
                .Where(book => book.AgeRestriction == (AgeRestriction)Enum.Parse(typeof(AgeRestriction), command, true))
                .Select(book => book.Title)
                .OrderBy(x => x)
                .ToList();

            var sb = new StringBuilder();
            foreach (var title in books)
            {
                sb.AppendLine(title);
            }

            return sb.ToString().Trim();
        }

        public static string GetGoldenBooks(BookShopContext context)
        {
            var books = context.Books
                .Where(book => book.EditionType == (EditionType)Enum.Parse(typeof(EditionType), "gold", true) && book.Copies < 5000)
                .OrderBy(book => book.BookId)
                .Select(book => book.Title)
                .ToList();

            var result = string.Join(Environment.NewLine, books);

            return result;
        }

        public static string GetBooksByPrice(BookShopContext context)
        {
            var books = context.Books
                .Where(book => book.Price > 40)
                .Select(book => new { book.Title, book.Price })
                .OrderByDescending(book => book.Price)
                .ToList();

            var sb = new StringBuilder();
            foreach (var book in books)
            {
                sb.AppendLine($"{book.Title} - ${book.Price:F2}");
            }

            return sb.ToString().Trim();
        }

        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            var books = context.Books
                .Where(book => book.ReleaseDate.Value.Year != year)
                .OrderBy(book => book.BookId)
                .Select(book => book.Title)
                .ToList();
            return string.Join(Environment.NewLine, books);
        }
        
        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            string[] categories = input.ToLower().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

            var books = context.Books
                .Where(book => book.BookCategories.Any(bc => categories.Contains(bc.Category.Name.ToLower())))
                .Select(book => book.Title)
                .OrderBy(title => title)
                .ToList();
            Console.WriteLine(string.Join(Environment.NewLine, books).Length);
            return string.Join(Environment.NewLine, books);
        }
        
        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            DateTime givenDate = DateTime.ParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture);

            var books = context.Books
                .Where(book => book.ReleaseDate.Value < givenDate)
                .Select(book => new { book.Title, book.EditionType, book.Price, book.ReleaseDate.Value })
                .OrderByDescending(book => book.Value)
                .ToList();

            var sb = new StringBuilder();

            foreach (var book in books)
            {
                sb.AppendLine($"{book.Title} - {book.EditionType} - ${book.Price:F2}");
            }

            Console.WriteLine(sb.Length);
            return sb.ToString().Trim();
        }

        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            var authors = context.Authors
                .Where(author => author.FirstName.EndsWith(input))
                .Select(author => ($"{author.FirstName} {author.LastName}"))
                .ToList()
                .OrderBy(fullname => fullname);

            return string.Join(Environment.NewLine, authors);
        }
        
        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            var books = context.Books
                .Where(book => book.Title.ToLower().Contains(input.ToLower()))
                .Select(book => book.Title)
                .OrderBy(book => book)
                .ToList();

            Console.WriteLine(string.Join(Environment.NewLine, books).Length);
            return string.Join(Environment.NewLine, books);
        }
        
        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            var books = context.Books
                .Where(book => book.Author.LastName.ToLower().StartsWith(input.ToLower()))                
                .Select(book => new { book.BookId, book.Title, AuthorFirstName = book.Author.FirstName, AuthorLastName = book.Author.LastName })
                .OrderBy(book => book.BookId)
                .ToList();

            var sb = new StringBuilder();

            foreach (var book in books)
            {
                sb.AppendLine($"{book.Title} ({book.AuthorFirstName} {book.AuthorLastName})");
            }
            return sb.ToString().Trim();
        }
        
        public static int CountBooks(BookShopContext context, int lengthCheck)
        {
            return context.Books
                .Where(book => book.Title.Length > lengthCheck)
                .Count();
        }
        
        public static string CountCopiesByAuthor(BookShopContext context)
        {
            var authors = context.Authors
                .Select(author => new { author.FirstName, author.LastName, bookCopies = author.Books.Select(book => book.Copies).Sum() })
                .OrderByDescending(author => author.bookCopies)
                .ToList();

            var sb = new StringBuilder();

            foreach (var author in authors)
            {
                sb.AppendLine($"{author.FirstName} {author.LastName} - {author.bookCopies}");
            }
            return sb.ToString().Trim();
        }

        public static string GetTotalProfitByCategory(BookShopContext context)
        {
            var categories = context.Categories
                .Select(category => new
                {
                    category.Name,
                    TotalProfit = category.CategoryBooks
                    .Select(cb => new { profit = cb.Book.Copies * cb.Book.Price }).Sum(x => x.profit)
                })
                .ToList()
                .OrderByDescending(category => category.TotalProfit);
            
            var sb = new StringBuilder();

            foreach (var category in categories)
            {
                sb.AppendLine($"{category.Name} ${category.TotalProfit:F2}");
            }
            return sb.ToString().Trim();
        }

        public static string GetMostRecentBooks(BookShopContext context)
        {
            var categories = context.Categories
                .Select(category => new
                {
                    category.Name,
                    mostRecentBooks = category.CategoryBooks
                        .Select(cb => new
                        {
                            Title = cb.Book.Title,
                            releaseDate = cb.Book.ReleaseDate
                        })
                        .OrderByDescending(book => book.releaseDate)
                        .Take(3)
                })
                .OrderBy(category => category.Name)
                .ToList();

            var sb = new StringBuilder();

            foreach (var category in categories)
            {
                sb.AppendLine($"--{category.Name}");
                foreach (var book in category.mostRecentBooks)
                {
                    sb.AppendLine($"{book.Title} ({((DateTime)book.releaseDate).Year})");
                }
            }
            return sb.ToString().Trim();
        }

        public static void IncreasePrices(BookShopContext context)
        {
            var books = context.Books
                .Where(book => book.ReleaseDate.Value.Year < 2010);

            foreach (var book in books)
            {
                book.Price += 5;
            }

            context.SaveChanges();
            Console.WriteLine("Done adding money");
        }

        public static int RemoveBooks(BookShopContext context)
        {
            var booksToRemove = context.Books
                .Where(book => book.Copies < 4200);

            int counter = 0;
            foreach (var book in booksToRemove)
            {
                try
                {
                    context.Books.Remove(book);
                    counter++;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message); ;
                }
                
            }
            context.SaveChanges();

            return counter;
        }
    }
}
