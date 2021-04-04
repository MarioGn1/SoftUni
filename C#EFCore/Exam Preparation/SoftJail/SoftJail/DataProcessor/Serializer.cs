namespace SoftJail.DataProcessor
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Data;
    using Microsoft.EntityFrameworkCore;
    using Newtonsoft.Json;
    using ProductShop.Utils;
    using SoftJail.DataProcessor.ExportDto;
    using SoftJail.Utils;
    using System;
    using System.Linq;

    public class Serializer
    {
        private static IMapper mapper;
        public static string ExportPrisonersByCells(SoftJailDbContext context, int[] ids)
        {
            mapper = Automapper.InitializeAutomaper();

            var dtos = context.Prisoners
                .Include(p => p.PrisonerOfficers)
                .ThenInclude(p => p.Officer)
                .ToArray()
                .Where(p => ids.Contains(p.Id))
                .AsQueryable()
                .ProjectTo<PrisonersWithCellsAndOfficersExportDTO>(mapper.ConfigurationProvider)
                .OrderBy(p => p.Name)
                .ThenBy(p => p.Id)
                .ToArray();

            return JsonConvert.SerializeObject(dtos, Formatting.Indented);
        }

        public static string ExportPrisonersInbox(SoftJailDbContext context, string prisonersNames)
        {
            var names = prisonersNames.Split(",").ToArray();
            var dtos = context.Prisoners
                .Where(p => names.Contains(p.FullName))
                .OrderBy(p => p.FullName)
                .ThenBy(p => p.Id)
                .ProjectTo<InboxForPrisonerDTO>(mapper.ConfigurationProvider)
                .ToArray();

            var rootName = "Prisoners";

            return XMLCustomSerializer.Serialize(dtos, rootName);
        }
    }
}