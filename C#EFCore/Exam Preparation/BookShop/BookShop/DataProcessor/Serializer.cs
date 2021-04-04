namespace BookShop.DataProcessor
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    using BookShop.Data.Models.Enums;
    using BookShop.DataProcessor.ExportDto;
    using Data;
    using Microsoft.EntityFrameworkCore;
    using Newtonsoft.Json;
    using ProductShop.Utils;
    using Formatting = Newtonsoft.Json.Formatting;

    public class Serializer
    {
        public static string ExportMostCraziestAuthors(BookShopContext context)
        {
            var dtos = context.Authors
                .Select(a => new MostCraziestAuthorsDTO
                {
                    AuthorName = a.FirstName + " " + a.LastName,
                    Books = a.AuthorsBooks
                    .Select(ab => new BookExportPartial
                    {
                        BookName = ab.Book.Name,
                        RealPrice = ab.Book.Price,
                        BookPrice = $"{ab.Book.Price:F2}"
                    })
                    .OrderByDescending(b => b.RealPrice)
                    .ToList()
                })
                .ToList()
                .OrderByDescending(a => a.Books.Count)
                .ThenBy(a => a.AuthorName)
                .ToList();

            return JsonConvert.SerializeObject(dtos, Formatting.Indented);
        }

        public static string ExportOldestBooks(BookShopContext context, DateTime date)
        {            
            var dtos = context.Books
                .Where(b => b.PublishedOn < date && b.Genre == Genre.Science)
                .Select(b => new OldestBooksDTO
                {
                    Pages = b.Pages,
                    Name = b.Name,
                    Date = b.PublishedOn.ToString("d", CultureInfo.InvariantCulture)
                })                
                .OrderByDescending(b => b.Pages)
                .ThenByDescending(b => b.Date)
                .Take(10)
                .ToList();

            var rootName = "Books";

            return XMLCustomSerializer.Serialize(dtos, rootName);
        }
    }
}