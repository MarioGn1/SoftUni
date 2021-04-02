namespace VaporStore.DataProcessor
{
	using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using Data;
    using Newtonsoft.Json;
    using ProductShop.Utils;
    using VaporStore.Data.Models;
    using VaporStore.Data.Models.Enums;
    using VaporStore.DataProcessor.Dto.Import;

    public static class Deserializer
	{
		public static string ImportGames(VaporStoreDbContext context, string jsonString)
		{
			var sb = new StringBuilder();
			var dtos = JsonConvert.DeserializeObject<IEnumerable<GameDevGenreTagsImportDTO>>(jsonString);

			var validModels = new List<Game>();
			var developers = new List<Developer>();
			var genres = new List<Genre>();
			var tags = new List<Tag>();

            foreach (var dto in dtos)
            {
				Developer developer = null; 
				Genre genre = null; 
				Tag curtag = null; 
                if (!IsValid(dto) || !(dto.Tags.Any()))
                {
					sb.AppendLine("Invalid Data");
					continue;
                }
                if (!developers.Any(d => d.Name == dto.Developer))
                {
					developer = new Developer { Name = dto.Developer };
					developers.Add(developer);
                }                
				if (!genres.Any(g => g.Name == dto.Genre))
                {
					genre = new Genre { Name = dto.Genre};
					genres.Add(genre);
                }
                foreach (var name in dto.Tags)
                {
					if (!tags.Any(t => t.Name == name))
					{
						curtag = new Tag { Name = name };
						tags.Add(curtag);
					}
				}
                var game = new Game
                {
                    Name = dto.Name,
                    Price = dto.Price,
                    ReleaseDate = DateTime.ParseExact(dto.ReleaseDate, "yyyy-MM-dd", CultureInfo.InvariantCulture),
                    Developer = developers.FirstOrDefault(d => d.Name == dto.Developer),
                    Genre = genres.FirstOrDefault(g => g.Name == dto.Genre),
                    GameTags = dto.Tags.Select(t => new GameTag { Tag = tags.FirstOrDefault(x => x.Name == t) }).ToList()
                };

                validModels.Add(game);
                sb.AppendLine($"Added {dto.Name} ({dto.Genre}) with {dto.Tags.Count} tags");
            }
			context.Developers.AddRange(developers);
			context.Genres.AddRange(genres);
			context.Tags.AddRange(tags);
            context.Games.AddRange(validModels);
            context.SaveChanges();

            return sb.ToString().Trim();
		}

		public static string ImportUsers(VaporStoreDbContext context, string jsonString)
		{
			var sb = new StringBuilder();
			var dtos = JsonConvert.DeserializeObject<IEnumerable<UserAndCardsDTO>>(jsonString);

			var validModels = new List<User>();

            foreach (var dto in dtos)
            {
                if (!IsValid(dto) || !dto.Cards.Any() || !dto.Cards.All(IsValid))
                {
					sb.AppendLine("Invalid Data");
					continue;
				}

				var user = new User
				{
					FullName = dto.FullName,
					Username = dto.Username,
					Email = dto.Email,
					Age = dto.Age,
					Cards = dto.Cards.Select(c => new Card { Number = c.Number, Cvc = c.CVC, Type = (CardType)Enum.Parse(typeof(CardType), c.Type) }).Distinct().ToList()
				};

				validModels.Add(user);
				sb.AppendLine($"Imported {user.Username} with {user.Cards.Count} cards");
            }

			context.Users.AddRange(validModels);
			context.SaveChanges();

			return sb.ToString().Trim();
		}

		public static string ImportPurchases(VaporStoreDbContext context, string xmlString)
		{
			var sb = new StringBuilder();
			var rootName = "Purchases";
			var dtos = XMLCustomSerializer.Deserialize<PurchaseImportDTO[]>(xmlString, rootName);

			var validModels = new List<Purchase>();

            foreach (var dto in dtos)
            {
                if (!IsValid(dto))
                {
					sb.AppendLine("Invalid Data");
					continue;
				}

				var purchase = new Purchase
				{
					Type = (PurchaseType)Enum.Parse(typeof(PurchaseType), dto.Type),
					ProductKey = dto.ProductKey,
					Date = DateTime.ParseExact(dto.Date, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture),
					Card = context.Cards.FirstOrDefault(c => c.Number == dto.Card),
					Game = context.Games.FirstOrDefault(g => g.Name == dto.Game)
				};

				validModels.Add(purchase);
				sb.AppendLine($"Imported {purchase.Game.Name} for {purchase.Card.User.Username}");
            }

			context.Purchases.AddRange(validModels);
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