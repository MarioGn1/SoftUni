using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ProductShop.Data;
using ProductShop.Models;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var db = new ProductShopContext();

            string usersPath = Path.Combine("Datasets", "users.json");
            string productsPath = Path.Combine("Datasets", "products.json");
            string categoriesPath = Path.Combine("Datasets", "categories.json");
            string categoriesProductsPath = Path.Combine("Datasets", "categories-products.json");


            //Change the path for tasks 1 to 4
            var json = File.ReadAllText(categoriesProductsPath);

            //Console.WriteLine(json);

            //TASK 1
            //Console.WriteLine(ImportUsers(db, json));
            //TASK 2
            //Console.WriteLine(ImportProducts(db, json));
            //TASK 3
            //Console.WriteLine(ImportCategories(db, json));
            //TASK 4
            //Console.WriteLine(ImportCategoryProducts(db, json));
            //TASK 5
            //Console.WriteLine(GetProductsInRange(db));
            //TASK 6
            //Console.WriteLine(GetSoldProducts(db));
            //TASK 7
            //Console.WriteLine(GetCategoriesByProductsCount(db));
            //TASK 8
            Console.WriteLine(GetUsersWithProducts(db));
        }

        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            var users = JsonConvert.DeserializeObject<List<User>>(inputJson);

            foreach (var user in users)
            {
                context.Users.Add(user);
            }

            context.SaveChanges();

            return $"Successfully imported {users.Count}";
        }

        public static string ImportProducts(ProductShopContext context, string inputJson)
        {
            var products = JsonConvert.DeserializeObject<List<Product>>(inputJson);

            foreach (var product in products)
            {
                context.Products.Add(product);
            }

            context.SaveChanges();

            return $"Successfully imported {products.Count}";
        }

        public static string ImportCategories(ProductShopContext context, string inputJson)
        {
            var categories = JsonConvert.DeserializeObject<List<Category>>(inputJson);

            int count = categories.Count;

            foreach (var category in categories)
            {
                if (category.Name == null)
                {
                    count--;
                    continue;
                }
                context.Categories.Add(category);
            }

            context.SaveChanges();

            return $"Successfully imported {count}";
        }

        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {
            var categoryProducts = JsonConvert.DeserializeObject<List<CategoryProduct>>(inputJson);

            foreach (var categoryProduct in categoryProducts)
            {
                context.CategoryProducts.Add(categoryProduct);
            }

            context.SaveChanges();

            return $"Successfully imported {categoryProducts.Count}";
        }

        public static string GetProductsInRange(ProductShopContext context)
        {
            var products = context.Products
                .Where(product => product.Price >= 500 && product.Price <= 1000)
                .OrderBy(product => product.Price)
                .Select(x => new
                {
                    name = x.Name,
                    price = x.Price,
                    seller = $"{(x.Seller.FirstName != null ? x.Seller.FirstName : string.Empty)} {x.Seller.LastName}"
                })
                .ToList();

            var json = JsonConvert.SerializeObject(products);

            return json;
        }

        public static string GetSoldProducts(ProductShopContext context)
        {
            var users = context.Users
                .Where(user => user.ProductsSold.Any(x => x.BuyerId != null))
                .OrderBy(user => user.LastName)
                .ThenBy(user => user.FirstName)
                .Select(user => new
                {
                    user.FirstName,
                    user.LastName,
                    SoldProducts = user.ProductsSold
                    .Where(p => p.BuyerId != null)
                    .Select(p => new
                    {
                        p.Name,
                        p.Price,
                        BuyerFirstName = p.Buyer.FirstName,
                        BuyerLastName = p.Buyer.LastName
                    })
                })
                .ToList();

            JsonSerializerSettings settings = DefaultSettingJSON();

            var json = JsonConvert.SerializeObject(users, settings);

            return json;
        }

        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var categories = context.Categories
                .OrderByDescending(category => category.CategoryProducts.Count)
                .Select(category => new
                {
                    Category = category.Name,
                    ProductsCount = category.CategoryProducts.Count,
                    AveragePrice = $"{category.CategoryProducts.Average(x => x.Product.Price):F2}",
                    TotalRevenue = $"{category.CategoryProducts.Sum(x => x.Product.Price):F2}"
                })
                .ToList();

            JsonSerializerSettings settings = DefaultSettingJSON();

            var json = JsonConvert.SerializeObject(categories, settings);

            return json;
        }

        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var users = context.Users
                .Include(u => u.ProductsSold)
                .ToList()
                .Where(user => user.ProductsSold.Any(p => p.BuyerId != null))
                .Select(user => new
                {
                    user.FirstName,
                    user.LastName,
                    user.Age,
                    SoldProducts = new
                    {
                        Count = user.ProductsSold.Where(x => x.BuyerId != null).Count(),
                        Products = user.ProductsSold
                            .Where(product => product.BuyerId != null)
                            .Select(product => new
                            {
                                product.Name,
                                product.Price
                            })
                    }

                })                            
                .OrderByDescending(x => x.SoldProducts.Count)
                .ToList();

            JsonSerializerSettings settings = DefaultSettingJSON();

            settings.NullValueHandling = NullValueHandling.Ignore;

            var json = JsonConvert.SerializeObject(new { UsersCount = users.Count, Users = users }, settings);

            return json;
        }

        private static JsonSerializerSettings DefaultSettingJSON()
        {
            DefaultContractResolver contractor = new DefaultContractResolver
            {
                NamingStrategy = new CamelCaseNamingStrategy()
            };

            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                ContractResolver = contractor,
                Formatting = Formatting.Indented
            };
            return settings;
        }
    }
}