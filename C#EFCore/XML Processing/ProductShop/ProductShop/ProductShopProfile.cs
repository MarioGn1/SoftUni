using AutoMapper;
using ProductShop.Dtos.Export;
using ProductShop.Dtos.Export.PartialDtos;
using ProductShop.Dtos.Import;
using ProductShop.Models;
using System.Linq;

namespace ProductShop
{
    public class ProductShopProfile : Profile
    {
        public ProductShopProfile()
        {
            //Input DTOs
            this.CreateMap<CategoryDTO, Category>();
            this.CreateMap<UserDTO, User>();
            this.CreateMap<ProductDTO, Product>();
            this.CreateMap<CategoryProductDTO, CategoryProduct>();

            //Output DTOs
            this.CreateMap<Product, ProductInRangeDTO>()
                .ForMember(dto => dto.BuyerFullName, x => x.MapFrom(p => p.Buyer.FirstName + " " + p.Buyer.LastName));
            this.CreateMap<User, UserSoldProductDTO>()
                .ForMember(dto => dto.SoldProducts, x => x.MapFrom(u => u.ProductsSold
                    .Select(p => new ExportProductDTO
                    {
                        Name = p.Name,
                        Price = p.Price
                    })));
            this.CreateMap<Category, CategoriesByProductCountDTO>()
                .ForMember(dto => dto.Count, x => x.MapFrom(c => c.CategoryProducts.Count))
                .ForMember(dto => dto.AveragePrice, x => x.MapFrom(c => c.CategoryProducts.Average(p => p.Product.Price)))
                .ForMember(dto => dto.TotalRevenue, x => x.MapFrom(c => c.CategoryProducts.Sum(p => p.Product.Price)));
            this.CreateMap<User, UserSoldProductsExtendDTO>()
                .ForMember(dto => dto.SoldProducts, x => x.MapFrom(u =>  new SoldProductDTO
                {
                    Count = u.ProductsSold.Where(product => product.BuyerId != null).Count(),
                    Products = u.ProductsSold
                    .Where(product => product.BuyerId != null)
                    .Select(p => new ExportProductDTO
                    {
                        Name = p.Name,
                        Price = p.Price
                    })
                    .OrderByDescending(p => p.Price)
                    .ToList()
                }));
                
        }
    }
}
