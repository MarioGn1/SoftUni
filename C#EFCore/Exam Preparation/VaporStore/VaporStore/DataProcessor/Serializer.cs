namespace VaporStore.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using Data;
    using Microsoft.EntityFrameworkCore;
    using Newtonsoft.Json;
    using ProductShop.Utils;
    using VaporStore.Data.Models.Enums;
    using VaporStore.DataProcessor.Dto.Export;

    public static class Serializer
    {
        public static string ExportGamesByGenres(VaporStoreDbContext context, string[] genreNames)
        {
            var dtos = context.Genres
                .Include(g => g.Games)
                .ToList()
                .Where(g => genreNames.Contains(g.Name))
                .Select(g => new AllGamesByGenreExportDTO
                {
                    Id = g.Id,
                    Genre = g.Name,
                    Games = g.Games.Where(gm => gm.Purchases.Any()).Select(gm => new GamesExportDTO
                    {
                        Id = gm.Id,
                        Title = gm.Name,
                        Developer = gm.Developer.Name,
                        Tags = String.Join(", ", gm.GameTags.Select(gt => gt.Tag.Name).ToArray()),
                        Players = gm.Purchases.Count()
                    })
                    .OrderByDescending(gm => gm.Players)
                    .ThenBy(gm => gm.Id)
                    .ToList(),
                    TotalPlayers = g.Games.Sum(gm => gm.Purchases.Count)
                })
                .OrderByDescending(g => g.TotalPlayers)
                .ThenBy(g => g.Id)
                .ToList();

            return JsonConvert.SerializeObject(dtos, Formatting.Indented);
        }

        public static string ExportUserPurchasesByType(VaporStoreDbContext context, string storeType)
        {
            var dtos = context.Users
                .Include(u => u.Cards)
                .ThenInclude(c => c.Purchases)
                .ThenInclude(p => p.Game)
                .ToList()
                .Where(u => u.Cards.Any(c => c.Purchases.Any()))
                .Select(u => new UserPurchasesByTypeExportDTO
                {
                    Username = u.Username,
                    Purchases = u.Cards.SelectMany(c => c.Purchases)
                                .Where(p => p.Type.ToString() == storeType && p != null)
                                .Select(p => new PurchaseExportDTO
                                {
                                    CardNumber = p.Card.Number,
                                    Cvc = p.Card.Cvc,
                                    Date = p.Date.ToString("yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture),
                                    Game = new GameXmlExportDTO
                                    {
                                        Title = p.Game.Name,
                                        GenreType = p.Game.Genre.Name,
                                        Price = p.Game.Price
                                    }
                                })
                                .OrderBy(p => p.Date)
                                .ToList(),
                    TotalSpent = u.Cards.Sum(c => c.Purchases
                                .Where(p => p.Type.ToString() == storeType)
                                .Sum(p => p.Game.Price))
                })
                .Where(p => p.Purchases.Any())
                .OrderByDescending(u => u.TotalSpent)
                .ThenBy(u => u.Username)
                .ToList();

            var rootName = "Users";

            return XMLCustomSerializer.Serialize(dtos, rootName);


        }
    }
}