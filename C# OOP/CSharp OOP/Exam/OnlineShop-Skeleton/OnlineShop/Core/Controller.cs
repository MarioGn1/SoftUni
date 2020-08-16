using OnlineShop.Common.Constants;
using OnlineShop.Common.Enums;
using OnlineShop.Models.Products;
using OnlineShop.Models.Products.Components;
using OnlineShop.Models.Products.Computers;
using OnlineShop.Models.Products.Peripherals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineShop.Core
{
    public class Controller : IController
    {

        private ICollection<IComputer> computers;
        private ICollection<IComponent> components;
        private ICollection<IPeripheral> peripherals;
        private ComputerType ComputerType;        
        private ComponentType ComponentType;
        private PeripheralType PeripheralType;
        public Controller()
        {
            computers = new List<IComputer>();
            components = new List<IComponent>();
            peripherals = new List<IPeripheral>();
        }
        public string AddComponent(int computerId, int id, string componentType, string manufacturer, string model, decimal price, double overallPerformance, int generation)
        {
            IsExist(computerId);
            if (computers.First(el => el.Id == computerId).Components.Any(x => x.Id == id))
            {
                throw new ArgumentException(ExceptionMessages.ExistingComponent);
            }
            
            if (!Enum.TryParse(componentType, out ComponentType))
            {
                throw new ArgumentException(ExceptionMessages.InvalidComponentType);
            }
            IComputer comp = computers.First(el => el.Id == computerId);
             IComponent component = null;
            switch (ComponentType)
            {
                case ComponentType.CentralProcessingUnit:
                    component = new CentralProcessingUnit(id, manufacturer, model, price, overallPerformance, generation);
                    break;
                case ComponentType.Motherboard:
                    component = new Motherboard(id, manufacturer, model, price, overallPerformance, generation);
                    break;
                case ComponentType.PowerSupply:
                    component = new PowerSupply(id, manufacturer, model, price, overallPerformance, generation);
                    break;
                case ComponentType.RandomAccessMemory:
                    component = new RandomAccessMemory(id, manufacturer, model, price, overallPerformance, generation);
                    break;
                case ComponentType.SolidStateDrive:
                    component = new SolidStateDrive(id, manufacturer, model, price, overallPerformance, generation);
                    break;
                case ComponentType.VideoCard:
                    component = new VideoCard(id, manufacturer, model, price, overallPerformance, generation);
                    break;
                default:
                    break;
            }
            components.Add(component);
            comp.AddComponent(component);
                return string.Format(SuccessMessages.AddedComponent, component.GetType().Name, id, computerId);
        }

        public string AddComputer(string computerType, int id, string manufacturer, string model, decimal price)
        {
            
            if (computers.Any(el => el.Id == id))
            {
                throw new ArgumentException(ExceptionMessages.ExistingComputerId);
            }
            if (!Enum.TryParse(computerType, out ComputerType))
            {
                throw new ArgumentException(ExceptionMessages.InvalidComputerType);
            }
            IComputer comp = null;

            switch (ComputerType)
            {
                case ComputerType.DesktopComputer:
                    comp = new DesktopComputer(id, manufacturer, model, price);
                    break;
                case ComputerType.Laptop:
                    comp = new Laptop(id, manufacturer, model, price);
                    break;
                default:
                    break;
            }
            
            computers.Add(comp);
            return string.Format(SuccessMessages.AddedComputer, id);
        }

        public string AddPeripheral(int computerId, int id, string peripheralType, string manufacturer, string model, decimal price, double overallPerformance, string connectionType)
        {
            IsExist(computerId);
            if (computers.First(el => el.Id == computerId).Peripherals.Any(x => x.Id == id))
            {
                throw new ArgumentException(ExceptionMessages.ExistingPeripheral);
            }
            
            if (!Enum.TryParse(peripheralType, out PeripheralType))
            {
                throw new ArgumentException(ExceptionMessages.InvalidPeripheralType);
            }
            IComputer comp = computers.First(el => el.Id == computerId);
            IPeripheral peripheral = null;
            switch (PeripheralType)
            {
                case PeripheralType.Headset:
                    peripheral = new Headset(id, manufacturer, model, price, overallPerformance, connectionType);
                    break;
                case PeripheralType.Keyboard:
                    peripheral = new Keyboard(id, manufacturer, model, price, overallPerformance, connectionType);
                    break;
                case PeripheralType.Monitor:
                    peripheral = new Monitor(id, manufacturer, model, price, overallPerformance, connectionType);
                    break;
                case PeripheralType.Mouse:
                    peripheral = new Mouse(id, manufacturer, model, price, overallPerformance, connectionType);
                    break;
                default:
                    break;
            }
            peripherals.Add(peripheral);
            comp.AddPeripheral(peripheral);
            return string.Format(SuccessMessages.AddedPeripheral, peripheral.GetType().Name, id, computerId);
        }

        public string BuyBest(decimal budget)
        {
            IComputer comp = computers.OrderByDescending(el => el.OverallPerformance).FirstOrDefault(el => el.Price <= budget);
            if (comp == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CanNotBuyComputer, budget));
            }
            computers.Remove(comp);
            return comp.ToString();
        }

        public string BuyComputer(int id)
        {
            IsExist(id);
            IComputer comp= computers.First(el => el.Id == id);
            computers.Remove(comp);
            return comp.ToString();
        }

        public string GetComputerData(int id)
        {
            IsExist(id);
            return computers.First(el => el.Id == id).ToString();
        }

        public string RemoveComponent(string componentType, int computerId)
        {
            IsExist(computerId);
            IComputer comp = computers.First(el => el.Id == computerId);
            IComponent component = comp.Components.FirstOrDefault(el => el.GetType().Name == componentType);
            comp.RemoveComponent(componentType);             
            components.Remove(component);
            return string.Format(SuccessMessages.RemovedComponent, componentType, computerId);
        }

        public string RemovePeripheral(string peripheralType, int computerId)
        {
            IsExist(computerId);
            IComputer comp = computers.First(el => el.Id == computerId);
            IPeripheral peripheral = comp.Peripherals.FirstOrDefault(el => el.GetType().Name == peripheralType);
            comp.RemovePeripheral(peripheralType); ;
            peripherals.Remove(peripheral);
            return string.Format(SuccessMessages.RemovedPeripheral, peripheralType, computerId);
        }

        public void IsExist(int computerId)
        {
            bool isExist = computers.Any(el => el.Id == computerId);
            if (!isExist)
            {
                throw new ArgumentException(ExceptionMessages.NotExistingComputerId);
            }
        }
    }
}
