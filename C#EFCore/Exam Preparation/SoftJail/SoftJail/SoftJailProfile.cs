namespace SoftJail
{
    using AutoMapper;
    using SoftJail.Data.Models;
    using SoftJail.DataProcessor.ImportDto;
    using System;
    using System.Globalization;
    using SoftJail.DataProcessor.ExportDto;
    using System.Linq;

    public class SoftJailProfile : Profile
    {
        private DateTime releaseDate;

        // Configure your AutoMapper here if you wish to use it. If not, DO NOT DELETE THIS CLASS
        public SoftJailProfile()
        {
            this.CreateMap<DepartmetsCellsDTO, Department>()
                .ForMember(d => d.Cells, x => x.MapFrom(dto => dto.Cells));
            this.CreateMap<CellsImportDTO, Cell>();
            this.CreateMap<MailInputDTO, Mail>();
            this.CreateMap<Prisoner, PrisonersWithCellsAndOfficersExportDTO>()
                .ForMember(dto => dto.Name, x => x.MapFrom(p => p.FullName))
                .ForMember(dto => dto.CellNumber, x => x.MapFrom(p => p.Cell.CellNumber))
                .ForMember(dto => dto.TotalOfficerSalary, x => x.MapFrom(p => p.PrisonerOfficers.Sum(po => po.Officer.Salary)))
                .ForMember(dto => dto.Officers, x => x.MapFrom(p => p.PrisonerOfficers
                    .Select(po => new OfficersExportDTO { OfficerName = po.Officer.FullName, Department = po.Officer.Department.Name })
                    .OrderBy(o => o.OfficerName)));
            this.CreateMap<Prisoner, InboxForPrisonerDTO>()
                .ForMember(dto => dto.Name, x => x.MapFrom(p => p.FullName))
                .ForMember(dto => dto.IncarcerationDate, x => x.MapFrom(p => p.IncarcerationDate.Date.ToString("yyyy-MM-dd")))
                .ForMember(dto => dto.EncryptedMessages, x => x.MapFrom(p => p.Mails));
            this.CreateMap<Mail, EncriptedMessage>()
                .ForMember(dto => dto.Description, x => x.MapFrom(m => string.Join("", m.Description.Reverse())));
        }
    }
}
