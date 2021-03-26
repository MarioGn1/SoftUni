using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using CarDealer.DTO;
using CarDealer.Models;

namespace CarDealer
{
    public class CarDealerProfile : Profile
    {
        public CarDealerProfile()
        {
            this.CreateMap<DtoSupplier, Supplier>();
            this.CreateMap<DtoParts, Part>();
            this.CreateMap<DtoCustomer, Customer>();
            this.CreateMap<DtoSale, Sale>();
                                           
        }
    }
}
