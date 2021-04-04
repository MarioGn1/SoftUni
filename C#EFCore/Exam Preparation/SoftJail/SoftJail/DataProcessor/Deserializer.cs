namespace SoftJail.DataProcessor
{
    using AutoMapper;
    using Data;
    using Newtonsoft.Json;
    using ProductShop.Utils;
    using SoftJail.Data.Models;
    using SoftJail.Data.Models.Enums;
    using SoftJail.DataProcessor.ImportDto;
    using SoftJail.Utils;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.Linq;
    using System.Text;

    public class Deserializer
    {
        private static IMapper mapper;

        public static string ImportDepartmentsCells(SoftJailDbContext context, string jsonString)
        {
            mapper = Automapper.InitializeAutomaper();
            var sb = new StringBuilder();

            var departmentsCellsDtos = JsonConvert.DeserializeObject<IEnumerable<DepartmetsCellsDTO>>(jsonString);
            List<DepartmetsCellsDTO> validModels = new List<DepartmetsCellsDTO>();

            foreach (var departmentCell in departmentsCellsDtos)
            {
                if (!IsValid(departmentCell) || !departmentCell.Cells.Any() || !departmentCell.Cells.All(IsValid))
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                validModels.Add(departmentCell);
                sb.AppendLine($"Imported {departmentCell.Name} with {departmentCell.Cells.Count} cells");
            }

            var departmetsCells = mapper.Map<IEnumerable<Department>>(validModels);
            context.Departments.AddRange(departmetsCells);
            context.SaveChanges();

            return sb.ToString().Trim();
        }

        public static string ImportPrisonersMails(SoftJailDbContext context, string jsonString)
        {
            mapper = Automapper.InitializeAutomaper();
            var sb = new StringBuilder();

            var prisonersMailsDtos = JsonConvert.DeserializeObject<IEnumerable<PrisonerMailsDTO>>(jsonString);
            List<Prisoner> validModels = new List<Prisoner>();

            foreach (var prisoner in prisonersMailsDtos)
            {
                if (!IsValid(prisoner) || !prisoner.Mails.All(IsValid))
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                var isRealDate = DateTime.TryParseExact(prisoner.ReleaseDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime releaseDate);
                var incancereationDate = DateTime.ParseExact(prisoner.IncarcerationDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);

                var currentPrisoner = new Prisoner
                {
                    FullName = prisoner.FullName,
                    Nickname = prisoner.Nickname,
                    IncarcerationDate = incancereationDate,
                    ReleaseDate = isRealDate ? (DateTime?)releaseDate : null,
                    Bail = prisoner.Bail,
                    CellId = prisoner.CellId,
                    Mails = mapper.Map<List<Mail>>(prisoner.Mails)
                };

                validModels.Add(currentPrisoner);
                sb.AppendLine($"Imported {prisoner.FullName} {prisoner.Age} years old");
            }

            context.Prisoners.AddRange(validModels);
            context.SaveChanges();

            return sb.ToString().Trim();
        }

        public static string ImportOfficersPrisoners(SoftJailDbContext context, string xmlString)
        {
            mapper = Automapper.InitializeAutomaper();
            var sb = new StringBuilder();

            var rootName = "Officers";
            var officersPrisonersDTO = XMLCustomSerializer.Deserialize<OfficerPrisonerInputDTO[]>(xmlString, rootName);

            var validModels = new List<Officer>();

            foreach (var officer in officersPrisonersDTO)
            {
                var isValidWeapon = Enum.TryParse(officer.Weapon, out Weapon weapon);
                var isValidPosition = Enum.TryParse(officer.Position, out Position position);
                if (!IsValid(officer) || !isValidPosition || !isValidWeapon)
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                var curOfficer = new Officer
                {
                    FullName = officer.FullName,
                    Salary = officer.Salary,
                    Position = position,
                    Weapon = weapon,
                    DepartmentId = officer.DepartmentId,
                    OfficerPrisoners = officer.Prisoners.Select(p => new OfficerPrisoner { PrisonerId = p.Id}).ToList()
                };
                validModels.Add(curOfficer);
                sb.AppendLine($"Imported {curOfficer.FullName} ({curOfficer.OfficerPrisoners.Count} prisoners)");
            }

            context.Officers.AddRange(validModels);
            context.SaveChanges();

            return sb.ToString().Trim();
        }

        private static bool IsValid(object obj)
        {
            var validationContext = new System.ComponentModel.DataAnnotations.ValidationContext(obj);
            var validationResult = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(obj, validationContext, validationResult, true);
            return isValid;
        }


    }
}