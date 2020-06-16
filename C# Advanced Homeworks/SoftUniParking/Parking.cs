using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;

namespace SoftUniParking
{
    public class Parking
    {
        private List<Car> cars;

        private static int capacity;

        public static int GetCapacity()
        {
            return capacity;
        }

        public static void SetCapacity(int value)
        {
            capacity = value;
        }

        public Parking(int capacity)
        {
            this.cars = new List<Car>();
            SetCapacity(capacity);
        }
        public string AddCar(Car car)
        {
            bool isExist = cars.Any(x => x.RegistrationNumber == car.RegistrationNumber);
            string message;
            if (isExist)
            {
                message = ("Car with that registration number, already exists!");
            }
            else if (cars.Count == GetCapacity())
            {
                message = ("Parking is full!");
            }
            else
            {
                cars.Add(car);
                message = ($"Successfully added new car {car.Make} {car.RegistrationNumber}");
            }

            return message;
        }

        public string RemoveCar(string registrationNumber)
        {
            string message = string.Empty;
            bool isExist = cars.Any(x => x.RegistrationNumber == registrationNumber);

            if (!isExist)
            {
                message = ("Car with that registration number, doesn't exist!");
            }
            else
            {
                cars = cars.Where(curCar => curCar.RegistrationNumber != registrationNumber).ToList();
                message = ($"Successfully removed {registrationNumber}");
            }
            return message;
        }

        public Car GetCar(string registrationNumber)
        {
            Car car = new Car();
            foreach (var item in cars)
            {
                if (item.RegistrationNumber == registrationNumber)
                {
                    car = item;
                    break;
                }
            }
            return car;
            //return this.cars.FirstOrDefault(x => x.RegistrationNumber == registrationNumber);
        }
        public void RemoveSetOfRegistrationNumber(List<string> RegistrationNumbers)
        {
            for (int i = 0; i < cars.Count; i++)
            {
                for (int j = 0; j < RegistrationNumbers.Count; j++)
                {
                    if (cars[i].RegistrationNumber == RegistrationNumbers[j])
                    {
                        cars.Remove(cars[i]);
                        i--;
                        break;
                    }
                }
            }

            //foreach (var item in RegistrationNumbers)
            //{
            //    Car car = this.cars.FirstOrDefault(x => x.RegistrationNumber == item);

            //    if (car != null)
            //    {
            //        this.cars.Remove(car);
            //    }
            //}
        }
        public int Count
        {
            get
            {
                return cars.Count;
            }
        }
    }
}
