using EasterRaces.Core.Contracts;
using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Models.Cars.Entities;
using EasterRaces.Models.Drivers;
using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Models.Races;
using EasterRaces.Models.Races.Contracts;
using EasterRaces.Repositories.Contracts;
using EasterRaces.Repositories.Entities;
using EasterRaces.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasterRaces.Core.Entities
{
    public class ChampionshipController : IChampionshipController
    {
        private DriverRepository DriverRepository;
        private CarRepository CarRepository;
        private RaceRepository RaceRepository;

        public ChampionshipController()
        {
            DriverRepository = new DriverRepository();
            CarRepository = new CarRepository();
            RaceRepository = new RaceRepository();
        }

        public string AddCarToDriver(string driverName, string carModel)
        {
            ICar car = CarRepository.Colection.FirstOrDefault(el => el.Model == carModel);
            IDriver driver = DriverRepository.Colection.FirstOrDefault(el => el.Name == driverName);
            if (driver == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.DriverNotFound, driverName));
            }
            if (car == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.CarNotFound, carModel));
            }
            driver.AddCar(car);
            return string.Format(OutputMessages.CarAdded, driverName, carModel);
        }

        public string AddDriverToRace(string raceName, string driverName)
        {
            IDriver driver = DriverRepository.Colection.FirstOrDefault(el => el.Name == driverName);
            IRace race = RaceRepository.Colection.FirstOrDefault(el => el.Name == raceName);
            if (race == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceNotFound, raceName));
            }
            if (driver == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.DriverNotFound, driverName));
            }
            race.AddDriver(driver);
            return string.Format(OutputMessages.DriverAdded, driverName, raceName);
        }

        public string CreateCar(string type, string model, int horsePower)
        {
            ICar car = null;
            if (type == "Muscle")
            {
                car = new MuscleCar(model, horsePower);
            }
            else if (type == "Sports")
            {
                car = new SportsCar(model, horsePower);
            }
            if (CarRepository.Colection.Any(el => el.Model == model))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CarExists, model));
            }
            CarRepository.Add(car);
            return string.Format(OutputMessages.CarCreated, car.GetType().Name, model);
        }

        public string CreateDriver(string driverName)
        {
            IDriver driver = new Driver(driverName);
            if (DriverRepository.Colection.Any(el => el.Name == driverName))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.DriversExists, driverName));
            }
            DriverRepository.Add(driver);
            return string.Format(OutputMessages.DriverCreated, driverName);
        }

        public string CreateRace(string name, int laps)
        {
            IRace race = new Race(name, laps);
            if (RaceRepository.Colection.Any(el => el.Name == name)) 
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceExists, name));
            }
            RaceRepository.Add(race);
            return string.Format(OutputMessages.RaceCreated, name);
        }

        public string StartRace(string raceName)
        {
            IRace race = RaceRepository.Colection.FirstOrDefault(el => el.Name == raceName);
            if (race == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceNotFound, raceName));
            }
            if (race.Drivers.Count < 3)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceInvalid, raceName,3));
            }

            List<IDriver> driversRanking = race.Drivers.Where(el => el.CanParticipate == true)
                .OrderByDescending(el => el.Car.CalculateRacePoints(race.Laps)).ToList();

            StringBuilder sb = new StringBuilder();
            sb.AppendLine(string.Format(OutputMessages.DriverFirstPosition, driversRanking[0].Name, raceName));
            sb.AppendLine(string.Format(OutputMessages.DriverSecondPosition, driversRanking[1].Name, raceName));
            sb.AppendLine(string.Format(OutputMessages.DriverThirdPosition, driversRanking[2].Name, raceName));
            RaceRepository.Remove(race);
            return sb.ToString().Trim();
        }
    }
}
