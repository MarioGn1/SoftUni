using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Parking
{
    class Parking
    {
        private List<Car> data;

        public Parking(string type, int capacity)
        {
            this.Type = type;
            this.Capacity = capacity;

            this.data = new List<Car>();
        }

        public void Add(Car car)
        {
            if (this.Capacity > this.data.Count)
            {
                this.data.Add(car);
            }
        }

        public bool Remove(string manufacturer, string model)
        {
            bool isRemoved = false;
            if (this.data.Any(el => el.Manufacturer == manufacturer && el.Model == model))
            {
                isRemoved = true;
                this.data = this.data.Where(car => car.Manufacturer != manufacturer && car.Model != model).ToList();
            }
            return isRemoved;
        }

        public Car GetLatestCar()
        {
            Car latestCar = this.data.OrderByDescending(el => el.Year).FirstOrDefault();
            return latestCar;
        }

        public Car GetCar(string manufacturer, string model)
        {
            Car desiredCar = this.data.FirstOrDefault(car => car.Manufacturer == manufacturer && car.Model == model);
            return desiredCar;
        }

        public string GetStatistics()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"The cars are parked in {this.Type}:");
            foreach (Car car in this.data)
            {
                sb.AppendLine(car.ToString());
            }
            return sb.ToString().Trim();
        }

        public string Type { get; set; }
        public int Capacity { get; set; }

        public int Count => this.data.Count;
    }
}
