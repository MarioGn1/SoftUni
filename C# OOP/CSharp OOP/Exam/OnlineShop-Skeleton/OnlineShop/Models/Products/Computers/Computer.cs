using OnlineShop.Common.Constants;
using OnlineShop.Models.Products.Components;
using OnlineShop.Models.Products.Peripherals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineShop.Models.Products.Computers
{
    public abstract class Computer : Product, IComputer
    {
        private readonly List<IComponent> components;
        private readonly List<IPeripheral> peripherals;

        protected Computer(int id, string manufacturer, string model, decimal price, double overallPerformance) 
            : base(id, manufacturer, model, price, overallPerformance)
        {
            components = new List<IComponent>();
            peripherals = new List<IPeripheral>();
        }

        public IReadOnlyCollection<IComponent> Components => components;

        public IReadOnlyCollection<IPeripheral> Peripherals => peripherals;

        public override double OverallPerformance
        {
            get
            {
                if (components.Count == 0)
                {
                    return this.OverallPerformance;
                }
                else
                {
                    return base.OverallPerformance + (components.Sum(el => el.OverallPerformance)/components.Count);
                }                
            }
        }
        public override decimal Price
        {
            get
            {
                decimal totalSum = components.Sum(el => el.Price) + peripherals.Sum(el => el.Price) + base.Price;

                return totalSum;
            }
        }

        public void AddComponent(IComponent component)
        {
            if (components.Any(el => el.Equals(component)))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.ExistingComponent, component.GetType().Name, this.GetType().Name, this.Id));
            }
            components.Add(component);
        }

        public void AddPeripheral(IPeripheral peripheral)
        {
            if (peripherals.Any(el => el.Equals(peripheral)))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.ExistingPeripheral, peripheral.GetType().Name, this.GetType().Name, this.Id));
            }
            peripherals.Add(peripheral);
        }

        public IComponent RemoveComponent(string componentType)
        {
            bool isExist = components.Any(el => el.GetType().Name == componentType);
            if (components.Count == 0 || !isExist )
            {
                throw new ArgumentException(string.Format(ExceptionMessages.NotExistingComponent, componentType, this.GetType().Name, this.Id));
            }
            IComponent component = components.First(el => el.GetType().Name == componentType);
            components.Remove(component);
            return component;
        }

        public IPeripheral RemovePeripheral(string peripheralType)
        {
            bool isExist = peripherals.Any(el => el.GetType().Name == peripheralType);
            if (peripherals.Count == 0 || !isExist)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.NotExistingPeripheral, peripheralType, this.GetType().Name, this.Id));
            }
            IPeripheral peripheral = peripherals.First(el => el.GetType().Name == peripheralType);
            peripherals.Remove(peripheral);
            return peripheral;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine($" Components ({components.Count}):");
            foreach (var item in components)
            {
                sb.AppendLine($"  {item}");
            }

            double avrgOP = 0;
            if (peripherals.Count > 0)
            {
                avrgOP = peripherals.Sum(el => el.OverallPerformance) / peripherals.Count;
            }
            
            sb.AppendLine($" Peripherals ({peripherals.Count}); Average Overall Performance ({avrgOP:F2}):");
            foreach (var item in peripherals)
            {
                sb.AppendLine($"  {item}");
            }

            return sb.ToString().Trim();
        }
    }
}
