using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using ProductShop.Data;
using ProductShop.Dtos.Export;
using ProductShop.Dtos.Import;
using ProductShop.Models;
using ProductShop.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace ProductShop
{
    public class StartUp
    {
        public static IMapper mapper;        

        public static void Main(string[] args)
        {
            var db = new ProductShopContext();

            //db.Database.EnsureDeleted();
            //db.Database.EnsureCreated();

            //var categoriesPath = Path.Combine("Datasets", "categories.xml");
            //var catsProductsPath = Path.Combine("Datasets", "categories-products.xml");
            //var productsPath = Path.Combine("Datasets", "products.xml");
            //var usersPath = Path.Combine("Datasets", "users.xml");

            //var usersXml = File.ReadAllText(usersPath);
            //var productsXml = File.ReadAllText(productsPath);
            //var categoriesXml = File.ReadAllText(categoriesPath);
            //var catsProductsXml = File.ReadAllText(catsProductsPath);

            //TASK 1
            //System.Console.WriteLine(ImportUsers(db, usersXml));
            //TASK 2
            //System.Console.WriteLine(ImportProducts(db, productsXml));
            //TASK 3
            //System.Console.WriteLine(ImportCategories(db, categoriesXml));
            //TASK 4
            //System.Console.WriteLine(ImportCategoryProducts(db, catsProductsXml));
            //TASK 5
            //System.Console.WriteLine(GetProductsInRange(db));
            //TASK 6
            //System.Console.WriteLine(GetSoldProducts(db));
            //TASK 7
            //Console.WriteLine(GetCategoriesByProductsCount(db));
            //TASK 8
            Console.WriteLine(GetUsersWithProducts(db));
        }

        public static string ImportUsers(ProductShopContext context, string inputXml)
        {
            InitializeMapper();

            string rootElement = "Users";

            var usersDto = XMLCustomSerializer.Deserialize(inputXml, rootElement, new UserDTO());

            var users = mapper.Map<IEnumerable<User>>(usersDto);

            context.Users.AddRange(users);
            context.SaveChanges();

            return $"Successfully imported {users.Count()}";
        }

        public static string ImportProducts(ProductShopContext context, string inputXml)
        {
            InitializeMapper();

            string rootElement = "Products";

            var productsDto = XMLCustomSerializer.Deserialize(inputXml, rootElement, new ProductDTO());

            var products = mapper.Map<IEnumerable<Product>>(productsDto);

            context.Products.AddRange(products);
            context.SaveChanges();

            return $"Successfully imported {products.Count()}";
        }

        public static string ImportCategories(ProductShopContext context, string inputXml)
        {
            InitializeMapper();

            string rootElement = "Categories";

            var categoriesDto = XMLCustomSerializer.Deserialize(inputXml, rootElement, new CategoryDTO());

            var categories = mapper.Map<IEnumerable<Category>>(categoriesDto).Where(c => c.Name != null);

            context.Categories.AddRange(categories);
            context.SaveChanges();

            return $"Successfully imported {categories.Count()}";
        }

        public static string ImportCategoryProducts(ProductShopContext context, string inputXml)
        {
            InitializeMapper();

            string rootElement = "CategoryProducts";

            var exsitingCategories = context.Categories
                .Select(c => c.Id)
                .ToList();
            var exsitingProducts = context.Products
                .Select(p => p.Id)
                .ToList();

            var catsProductsDTO = XMLCustomSerializer.Deserialize(inputXml, rootElement, new CategoryProductDTO())
                .Where(cp => exsitingCategories.Contains(cp.CategoryId) && exsitingProducts.Contains(cp.ProductId));

            var categoriesProducts = mapper.Map<IEnumerable<CategoryProduct>>(catsProductsDTO);

            context.CategoryProducts.AddRange(categoriesProducts);
            context.SaveChanges();

            return $"Successfully imported {categoriesProducts.Count()}";
        }

        public static string GetProductsInRange(ProductShopContext context)
        {
            InitializeMapper();

            var productsDTO = context.Products
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .OrderBy(p => p.Price)
                .Take(10)
                .ProjectTo<ProductInRangeDTO>(mapper.ConfigurationProvider)
                .ToArray();

            var rootName = "Products";

            return XMLCustomSerializer.Serialize(productsDTO, rootName);
        }

        public static string GetSoldProducts(ProductShopContext context)
        {
            InitializeMapper();

            var usersDto = context.Users
                .Where(u => u.ProductsSold.Count > 0)
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.FirstName)
                .Take(5)
                .ProjectTo<UserSoldProductDTO>(mapper.ConfigurationProvider)
                .ToArray();

            var rootName = "Users";

            return XMLCustomSerializer.Serialize(usersDto, rootName);
        }

        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            InitializeMapper();

            var categoriesDto = context.Categories
                .ProjectTo<CategoriesByProductCountDTO>(mapper.ConfigurationProvider)
                .OrderByDescending(c => c.Count)
                .ThenBy(c => c.TotalRevenue)
                .ToArray();

            var rootName = "Categories";

            return XMLCustomSerializer.Serialize(categoriesDto, rootName);
        }

        public static string GetUsersWithProducts(ProductShopContext context)
        {
            InitializeMapper();

            var usersDto = context.Users                
                .Where(u => u.ProductsSold.Any(p => p.BuyerId != null))
                .OrderByDescending(u => u.ProductsSold.Count)
                .Take(10)
                .Include(u => u.ProductsSold)
                .ToArray()
                .AsQueryable()
                .ProjectTo<UserSoldProductsExtendDTO>(mapper.ConfigurationProvider)                
                .ToArray();
            
            var rootName = "Users";

            var users = new UserExportDTO { Count = context.Users
                .Where(u => u.ProductsSold.Any(p => p.BuyerId != null)).Count(), Users = usersDto };

            return XMLCustomSerializer.Serialize(users, rootName);
        }

        public static void InitializeMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ProductShopProfile>();
            });

            mapper = config.CreateMapper();
        }
    }

}