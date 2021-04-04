namespace BookShop.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using BookShop.Data.Models;
    using BookShop.Data.Models.Enums;
    using BookShop.DataProcessor.ImportDto;
    using BookShop.Utils;
    using Data;
    using Newtonsoft.Json;
    using ProductShop.Utils;
    using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedBook
            = "Successfully imported book {0} for {1:F2}.";

        private const string SuccessfullyImportedAuthor
            = "Successfully imported author - {0} with {1} books.";

        public static string ImportBooks(BookShopContext context, string xmlString)
        {
            var sb = new StringBuilder();
            var dtos = XMLCustomSerializer.Deserialize<ImportBooks[]>(xmlString, "Books");

            var validModels = new List<Book>();

            foreach (var dto in dtos)
            {
                if (!IsValid(dto))
                {
                    sb.AppendLine("Invalid data!");
                    continue;
                }

                var book = new Book
                {
                    Name = dto.Name,
                    Genre = (Genre)Enum.Parse(typeof(Genre), dto.Genre),
                    Price = dto.Price,
                    Pages = dto.Pages,
                    PublishedOn = DateTime.ParseExact(dto.PublishedOn, "MM/dd/yyyy", CultureInfo.InvariantCulture)
                };

                validModels.Add(book);                
                sb.AppendLine(string.Format(SuccessfullyImportedBook,book.Name, book.Price));
            }

            context.AddRange(validModels);
            context.SaveChanges();

            return sb.ToString().Trim();
        }

        public static string ImportAuthors(BookShopContext context, string jsonString)
        {
            var sb = new StringBuilder();
            var dtos = JsonConvert.DeserializeObject<IEnumerable<ImportAuthorsDTO>>(jsonString, JsonSetting.DefaultSettingJSON());

            var validModels = new List<Author>();

            foreach (var dto in dtos)
            {
                if (!IsValid(dto) || context.Authors.Any(a => a.Email == dto.Email) || !dto.Books.Any())
                {
                    sb.AppendLine("Invalid data!");
                    continue;
                }

                var author = new Author
                {
                    FirstName = dto.FirstName,
                    LastName = dto.LastName,
                    Phone = dto.Phone,
                    Email = dto.Email,
                    AuthorsBooks = dto.Books
                    .Where(b => context.Books.Any(x => x.Id == b.Id))
                    .Select(b => new AuthorBook { BookId = b.Id })
                    .ToList()
                };

                if (!author.AuthorsBooks.Any() || validModels.Any(m => m.Email == dto.Email))
                {
                    sb.AppendLine("Invalid data!");
                    continue;
                }
                validModels.Add(author);
                sb.AppendLine(string.Format(SuccessfullyImportedAuthor, author.FirstName + " " + author.LastName, author.AuthorsBooks.Count));
            }

            context.AddRange(validModels);
            context.SaveChanges();

            return sb.ToString().Trim();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}