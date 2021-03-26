using AutoMapper;
using CarDealer.Dtos.Export;
using CarDealer.Dtos.Import;
using CarDealer.Dtos.PartialDtos;
using CarDealer.Models;
using System.Linq;

namespace CarDealer
{
    public class CarDealerProfile : Profile
    {
        public CarDealerProfile()
        {
            //Input
            this.CreateMap<SupplierDTO, Supplier>();
            this.CreateMap<PartDTO, Part>();
            this.CreateMap<CustomerDTO, Customer>();
            this.CreateMap<SaleDTO, Sale>();

            //Output
            this.CreateMap<Car, CarOutputDTO>();
            this.CreateMap<Car, CarBmwDTO>();
            this.CreateMap<Supplier, LocalSupplierDTO>()
                .ForMember(dto => dto.PartsCount, x =>x.MapFrom(s => s.Parts.Count));
            this.CreateMap<Car, CarWithAllPartsDTO>()
                .ForMember(dto => dto.Parts, x => x.MapFrom(c => c.PartCars
                        .Select(pc => new PartPartialOutputDTO 
                        { 
                            Name = pc.Part.Name, 
                            Price = pc.Part.Price
                        })
                        .OrderByDescending(p => p.Price)
                        .ToArray()));
            this.CreateMap<Customer, CustomerOutputDTO>()
                .ForMember(dto => dto.BoughtCars, x => x.MapFrom(c => c.Sales.Count))
                .ForMember(dto => dto.SpentMoney, x => x.MapFrom(c => c.Sales.Sum(s => s.Car.PartCars.Sum(pc => pc.Part.Price))));
            this.CreateMap<Sale, SaleOutputDTO>()
                .ForMember(dto => dto.Car, x => x.MapFrom(s => s.Car))
                .ForMember(dto => dto.CustomerName, x => x.MapFrom(s => s.Customer.Name))
                .ForMember(dto => dto.Price, x => x.MapFrom(s => s.Car.PartCars.Sum(pc => pc.Part.Price)))
                .ForMember(dto => dto.PriceWithDiscount, x => x.MapFrom(s => s.Car.PartCars.Sum(pc => pc.Part.Price) * (100 - s.Discount) / 100));
            this.CreateMap<Car, CarOutputAttributesDTO>();
        }
    }
}
