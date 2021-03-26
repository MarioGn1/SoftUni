using AutoMapper;
using AutoMapper.QueryableExtensions;
using CarDealer.Data;
using CarDealer.Dtos.Export;
using CarDealer.Dtos.Import;
using CarDealer.Models;
using Microsoft.EntityFrameworkCore;
using ProductShop.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using CarInputDTO = CarDealer.Dtos.Import.CarInputDTO;

namespace CarDealer
{
    public class StartUp
    {
        public static IMapper mapper;

        public static void Main(string[] args)
        {
            var db = new CarDealerContext();

            //db.Database.EnsureDeleted();
            //db.Database.EnsureCreated();

            //var carsPath = Path.Combine("Datasets", "cars.xml");
            //var customersPath = Path.Combine("Datasets", "customers.xml");
            //var partsPath = Path.Combine("Datasets", "parts.xml");
            //var salesPath = Path.Combine("Datasets", "sales.xml");
            //var suppliersPath = Path.Combine("Datasets", "suppliers.xml");

            //var carsXml = File.ReadAllText(carsPath);
            //var customersXml = File.ReadAllText(customersPath);
            //var partsXml = File.ReadAllText(partsPath);
            //var salesXml = File.ReadAllText(salesPath);
            //var suppliersXml = File.ReadAllText(suppliersPath);

            //TASK 1
            //Console.WriteLine(ImportSuppliers(db, suppliersXml));
            //TASK 2
            //Console.WriteLine(ImportParts(db, partsXml));
            //TASK 3
            //Console.WriteLine(ImportCars(db, carsXml));
            //TASK 4
            //Console.WriteLine(ImportCustomers(db, customersXml));
            //TASK 5
            //Console.WriteLine(ImportSales(db, salesXml));
            //TASK 6
            //Console.WriteLine(GetCarsWithDistance(db));
            //TASK 7
            //Console.WriteLine(GetCarsFromMakeBmw(db));
            //TASK 8
            //Console.WriteLine(GetLocalSuppliers(db));
            //TASK 9
            //Console.WriteLine(GetCarsWithTheirListOfParts(db));
            //TASK 10
            //Console.WriteLine(GetTotalSalesByCustomer(db));
            //TASK 11
            Console.WriteLine(GetSalesWithAppliedDiscount(db));

        }

        public static string ImportSuppliers(CarDealerContext context, string inputXml)
        {
            InitializeAutomaper();

            var rootName = "Suppliers";

            var suppliersDTO = XMLCustomSerializer.Deserialize<SupplierDTO[]>(inputXml, rootName);

            var suppliers = mapper.Map<Supplier[]>(suppliersDTO);

            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Length}";
        }

        public static string ImportParts(CarDealerContext context, string inputXml)
        {
            InitializeAutomaper();

            var rootName = "Parts";

            var partsDTO = XMLCustomSerializer.Deserialize<PartDTO[]>(inputXml, rootName);

            var parts = mapper.Map<Part[]>(partsDTO).Where(p => context.Suppliers.Any(s => s.Id == p.SupplierId)
                ).ToArray();

            context.Parts.AddRange(parts);
            context.SaveChanges();

            return $"Successfully imported {parts.Length}";
        }

        public static string ImportCars(CarDealerContext context, string inputXml)
        {
            var rootName = "Cars";

            var carsDTO = XMLCustomSerializer.Deserialize<CarInputDTO[]>(inputXml, rootName);

            var allParts = context.Parts.Select(p => p.Id).ToList();

            var cars = new List<Car>();

            foreach (var dto in carsDTO)
            {
                var uniqueParts = dto.CarPartsIds.Select(p => p.PartId).Distinct();

                var currCar = new Car()
                {
                    Model = dto.Model,
                    Make = dto.Make,
                    TravelledDistance = dto.TravelledDistance
                };
                foreach (var dtoCarPartId in uniqueParts)
                {
                    if (allParts.Contains(dtoCarPartId))
                    {
                        currCar.PartCars.Add(new PartCar { PartId = dtoCarPartId });
                    }
                }
                cars.Add(currCar);
            }

            context.Cars.AddRange(cars);
            context.SaveChanges();

            return $"Successfully imported {cars.Count}";
        }

        public static string ImportCustomers(CarDealerContext context, string inputXml)
        {
            InitializeAutomaper();

            var rootName = "Customers";

            var customersDTO = XMLCustomSerializer.Deserialize<CustomerDTO[]>(inputXml, rootName);

            var customers = mapper.Map<Customer[]>(customersDTO);

            context.Customers.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {customers.Length}";
        }

        public static string ImportSales(CarDealerContext context, string inputXml)
        {
            InitializeAutomaper();

            var rootName = "Sales";

            var salesDTO = XMLCustomSerializer.Deserialize<SaleDTO[]>(inputXml, rootName);

            var carsIds = context.Cars.Select(c => c.Id).ToList();

            var sales = mapper.Map<Sale[]>(salesDTO).Where(c => carsIds.Contains(c.CarId)).ToArray();

            context.Sales.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {sales.Length}";
        }

        public static string GetCarsWithDistance(CarDealerContext context)
        {
            InitializeAutomaper();

            var carsDTO = context.Cars
                .Where(c => c.TravelledDistance > 2000000)
                .OrderBy(c => c.Make)
                .ThenBy(c => c.Model)
                .Take(10)
                .ProjectTo<CarOutputDTO>(mapper.ConfigurationProvider)
                .ToArray();

            var rootName = "cars";

            return XMLCustomSerializer.Serialize(carsDTO, rootName);
        }

        public static string GetCarsFromMakeBmw(CarDealerContext context)
        {
            InitializeAutomaper();

            var carsDTO = context.Cars
                .Where(c => c.Make == "BMW")
                .OrderBy(c => c.Model)
                .ThenByDescending(c => c.TravelledDistance)
                .ProjectTo<CarBmwDTO>(mapper.ConfigurationProvider)
                .ToArray();

            var rootName = "cars";

            return XMLCustomSerializer.Serialize(carsDTO, rootName);
        }

        public static string GetLocalSuppliers(CarDealerContext context)
        {
            InitializeAutomaper();

            var suppliersDTO = context.Suppliers
                .Where(s => !s.IsImporter)
                .ProjectTo<LocalSupplierDTO>(mapper.ConfigurationProvider)
                .ToArray();

            var rootName = "suppliers";

            return XMLCustomSerializer.Serialize(suppliersDTO, rootName);
        }

        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            InitializeAutomaper();

            var carsDTO = context.Cars
                .OrderByDescending(c => c.TravelledDistance)
                .ThenBy(c => c.Model)
                .Take(5)
                .ProjectTo<CarWithAllPartsDTO>(mapper.ConfigurationProvider)
                .ToArray();

            var rootName = "cars";

            return XMLCustomSerializer.Serialize(carsDTO, rootName);
        }

        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            InitializeAutomaper();
            //****WORKS WITH EF CORE 2.1.1 ONLY AND IN JUDGE***//
            //var customerDTO = context.Customers
            //    .Where(c => c.Sales.Count > 0)
            //    .ProjectTo<CustomerOutputDTO>(mapper.ConfigurationProvider)
            //    .OrderByDescending(dto => dto.SpentMoney)
            //    .ToArray();

            var customerDTO = context.Customers
                .Include(c => c.Sales)
                .ThenInclude(s => s.Car)
                .ThenInclude(s => s.PartCars)
                .ThenInclude(pc => pc.Part)
                .ToArray()
                .Where(c => c.Sales.Count > 0)
                .AsQueryable()
                .ProjectTo<CustomerOutputDTO>(mapper.ConfigurationProvider)
                .OrderByDescending(c => c.SpentMoney)
                .ToArray();

            var rootName = "customers";

            return XMLCustomSerializer.Serialize(customerDTO, rootName);
        }

        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            InitializeAutomaper();

            var salesDTO = context.Sales
                .ProjectTo<SaleOutputDTO>(mapper.ConfigurationProvider)
                .ToArray();

            var rootName = "sales";

            return XMLCustomSerializer.Serialize(salesDTO, rootName);
        }

        public static void InitializeAutomaper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CarDealerProfile>();
            });

            mapper = config.CreateMapper();
        }

    }
}