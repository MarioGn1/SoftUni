using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AutoMapper;
using CarDealer.Data;
using CarDealer.DTO;
using CarDealer.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace CarDealer
{
    public class StartUp
    {
        public static IMapper mapper;

        public static void Main(string[] args)
        {
            var db = new CarDealerContext();

            var carsPath = Path.Combine("Datasets", "cars.json");
            var customersPath = Path.Combine("Datasets", "customers.json");
            var partsPath = Path.Combine("Datasets", "parts.json");
            var salesPath = Path.Combine("Datasets", "sales.json");
            var suppliersPath = Path.Combine("Datasets", "suppliers.json");

            //Change the path for tasks 1 to 5
            //var jsonSuppliers = File.ReadAllText(suppliersPath);
            //var jsonParts = File.ReadAllText(partsPath);
            //var jsonCars = File.ReadAllText(carsPath);
            //var jsonCustomers = File.ReadAllText(customersPath);
            //var jsonSales = File.ReadAllText(salesPath);

            //Task 1
            //Console.WriteLine(ImportSuppliers(db, jsonSuppliers));
            //Task 2
            //Console.WriteLine(ImportParts(db, jsonParts));
            //Task 3
            //Console.WriteLine(ImportCars(db, jsonCars));
            //TASK 4
            //Console.WriteLine(ImportCustomers(db, jsonCustomers));
            //TASK 5
            //Console.WriteLine(ImportSales(db, jsonSales));
            //TASK 6
            //Console.WriteLine(GetOrderedCustomers(db));
            //TASK 7
            //Console.WriteLine(GetCarsFromMakeToyota(db));
            //TASK 8
            //Console.WriteLine(GetLocalSuppliers(db));
            //TASK 9
            //Console.WriteLine(GetCarsWithTheirListOfParts(db));
            //TASK 10
            //Console.WriteLine(GetTotalSalesByCustomer(db));
            //TASK 11
            //Console.WriteLine(GetSalesWithAppliedDiscount(db));

        }

        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        {
            InitializeAutomaper();

            var dtoSuppliers = JsonConvert.DeserializeObject<IEnumerable<DtoSupplier>>(inputJson);

            var suppliers = mapper.Map<IEnumerable<Supplier>>(dtoSuppliers);

            context.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Count()}.";
        }

        public static string ImportParts(CarDealerContext context, string inputJson)
        {
            InitializeAutomaper();

            var dtoParts = JsonConvert.DeserializeObject<IEnumerable<DtoParts>>(inputJson)
                .Where(p => context.Suppliers.Any(s => s.Id == p.SupplierId))
                .AsEnumerable();

            var parts = mapper.Map<IEnumerable<Part>>(dtoParts);

            context.AddRange(parts);
            context.SaveChanges();

            return $"Successfully imported {parts.Count()}.";
        }

        public static string ImportCars(CarDealerContext context, string inputJson)
        {
            InitializeAutomaper();

            var dtoCars = JsonConvert.DeserializeObject<IEnumerable<DtoCar>>(inputJson);

            List<Car> cars = new List<Car>();

            foreach (var car in dtoCars)
            {
                var curCar = new Car
                {
                    Model = car.Model,
                    Make = car.Make,
                    TravelledDistance = car.TravelledDistance
                };

                foreach (var part in car.PartsId.Distinct())
                {
                    curCar.PartCars.Add(new PartCar { PartId = part });
                }

                cars.Add(curCar);
            }

            context.Cars.AddRange(cars);
            context.SaveChanges();

            return $"Successfully imported {cars.Count()}.";
        }

        public static string ImportCustomers(CarDealerContext context, string inputJson)
        {
            InitializeAutomaper();

            var dtoCustomers = JsonConvert.DeserializeObject<IEnumerable<Customer>>(inputJson);

            var customers = mapper.Map<IEnumerable<Customer>>(dtoCustomers);

            context.Customers.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {customers.Count()}.";
        }

        public static string ImportSales(CarDealerContext context, string inputJson)
        {
            InitializeAutomaper();

            var dtoSales = JsonConvert.DeserializeObject<IEnumerable<DtoSale>>(inputJson);

            var sales = mapper.Map<IEnumerable<Sale>>(dtoSales);

            context.Sales.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {sales.Count()}.";
        }

        public static string GetOrderedCustomers(CarDealerContext context)
        {
            var customers = context.Customers
                .OrderBy(c => c.BirthDate)
                .ThenBy(c => c.IsYoungDriver)
                .Select(c => new
                {
                    c.Name,
                    BirthDate = c.BirthDate.ToString("dd/MM/yyyy"),
                    c.IsYoungDriver
                })
                .ToList();

            var result = JsonConvert.SerializeObject(customers, DefaultSettingJSON());

            return result;
        }

        public static string GetCarsFromMakeToyota(CarDealerContext context)
        {
            var cars = context.Cars
                .Where(car => car.Make == "Toyota")
                .OrderBy(car => car.Model)
                .ThenByDescending(car => car.TravelledDistance)
                .Select(car => new
                {
                    car.Id,
                    car.Make,
                    car.Model,
                    car.TravelledDistance
                })
                .ToList();

            var result = JsonConvert.SerializeObject(cars, DefaultSettingJSON());

            return result;
        }

        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var suppliers = context.Suppliers
                .Where(s => s.IsImporter == false)
                .Select(s => new
                {
                    s.Id,
                    s.Name,
                    PartsCount = s.Parts.Count
                })
                .ToList();

            var result = JsonConvert.SerializeObject(suppliers, DefaultSettingJSON());

            return result;
        }

        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var cars = context.Cars
                .Select(c => new
                {
                    car = new
                    {
                        c.Make,
                        c.Model,
                        c.TravelledDistance
                    },
                    parts = c.PartCars
                    .Select(p => new
                    {
                        Name = p.Part.Name,
                        Price = $"{p.Part.Price:F2}"
                    })
                })
                .ToList();

            var result = JsonConvert.SerializeObject(cars, DefaultSettingJSON());

            return result;
        }

        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var customers = context.Customers
                .Where(c => c.Sales.Count > 0)
                .Select(c => new
                {
                    FullName = c.Name,
                    BoughtCars = c.Sales.Count,
                    SpentMoney = c.Sales
                    .Sum(s => s.Car.PartCars.Sum(pc => pc.Part.Price))
                })
                .OrderByDescending(oc => oc.SpentMoney)
                .ThenByDescending(oc => oc.BoughtCars)
                .ToList();

            var result = JsonConvert.SerializeObject(customers, DefaultSettingJSON());

            return result;
        }

        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            var sales = context.Sales
                .Select(s => new
                {
                    car = new
                    {
                        Make = s.Car.Make,
                        Model = s.Car.Model,
                        TravelledDistance = s.Car.TravelledDistance
                    },
                    customerName = s.Customer.Name,
                    Discount = $"{s.Discount:F2}",
                    price = $"{s.Car.PartCars.Sum(p => p.Part.Price):F2}",
                    priceWithDiscount = $"{s.Car.PartCars.Sum(p => p.Part.Price) * (1 - s.Discount / 100):F2}",
                })
                .Take(10)
                .ToList();

            var result = JsonConvert.SerializeObject(sales, DefaultSettingJSON());

            return result;
        }

        public static void InitializeAutomaper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CarDealerProfile>();
            });

            mapper = config.CreateMapper();
        }

        private static JsonSerializerSettings DefaultSettingJSON()
        {
            DefaultContractResolver contractor = new DefaultContractResolver
            {
                //NamingStrategy = new CamelCaseNamingStrategy()
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