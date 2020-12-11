
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
        private List<IComputer> computers;
        private List<IComponent> components;
        private List<IPeripheral> peripherals;
        private IComputer computer;
        private IComponent component;
        private IPeripheral peripheral;
        public Controller()
        {
            this.computers = new List<IComputer>();
            this.components = new List<IComponent>();
            this.peripherals = new List<IPeripheral>();
        }
        public string AddComponent(int computerId, int id, string componentType, string manufacturer, string model, decimal price, double overallPerformance, int generation)
        {
            IsExistingCompWithId(computerId);
            computer = computers.FirstOrDefault(c => c.Id == computerId);
            if(this.components.Any( c => c.Id == id))
            {
                throw new ArgumentException("Component with this id already exists.");
            }
            if(componentType == "Motherboard")
            {
                component = new Motherboard(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if(componentType == "PowerSupply")
            {
                component = new PowerSupply(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType == "CentralProcessingUnit")
            {
                component = new CentralProcessingUnit(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType == "RandomAccessMemory")
            {
                component = new RandomAccessMemory(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType == "SolidStateDrive")
            {
                component = new SolidStateDrive(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType == "VideoCard")
            {
                component = new VideoCard(id, manufacturer, model, price, overallPerformance, generation);
            }
            else
            {
                throw new ArgumentException("Component type is invalid.");
            }
            computer.AddComponent(component);
            this.components.Add(component);
            return $"Component {component.GetType().Name} with id {component.Id} added successfully in computer with id {computerId}.";
        }

        public string AddComputer(string computerType, int id, string manufacturer, string model, decimal price)
        {
            if (computers.Any(c => c.Id == id))
            {
                throw new ArgumentException("Computer with this id already exists.");
            }
            if(computerType == "Laptop")
            {
                computer = new Laptop(id, manufacturer, model, price);
            }
            else if(computerType=="DesktopComputer")
            {
                computer = new DesktopComputer(id, manufacturer, model, price);
            }
            else
            {
                throw new ArgumentException("Computer type is invalid.");
            }
            computers.Add(computer);
            return $"Computer with id {id} added successfully.";
        }

        public string AddPeripheral(int computerId, int id, string peripheralType, string manufacturer, string model, decimal price, double overallPerformance, string connectionType)
        {
            IsExistingCompWithId(computerId);
            computer = computers.FirstOrDefault(c => c.Id == computerId);
            if (this.peripherals.Any(p => p.Id == id))
            {
                throw new ArgumentException("Peripheral with this id already exists.");
            }
            if (peripheralType == "Headset")
            {
                peripheral = new Headset(id, manufacturer, model, price, overallPerformance, connectionType);
            }
            else if (peripheralType == "Keyboard")
            {
                peripheral = new Keyboard(id, manufacturer, model, price, overallPerformance, connectionType);
            }
            else if (peripheralType == "Monitor")
            {
                peripheral = new Monitor(id, manufacturer, model, price, overallPerformance, connectionType);
            }
            else if (peripheralType == "Mouse")
            {
                peripheral = new Mouse(id, manufacturer, model, price, overallPerformance, connectionType);
            }
            else
            {
                throw new ArgumentException("Peripheral type is invalid.");
            }
            computer.AddPeripheral(peripheral);
            peripherals.Add(peripheral);
            return $"Peripheral  {peripheral.GetType().Name} with id {peripheral.Id} added successfully in computer with id {computerId}.";
        }

        public string BuyBest(decimal budget)
        {
            if(computers.Count == 0 )
            {
                throw new ArgumentException($"Can't buy a computer with a budget of ${budget}.");
            }
            List<IComputer> sortedComputers = computers.OrderByDescending(c => c.OverallPerformance).ToList();
           
            computer = sortedComputers.FirstOrDefault(c => c.Price <= budget);
            //moje da iska purvo proverka dali ima elementi v computrite
            if(computer ==null)
            {
                throw new ArgumentException($"Can't buy a computer with a budget of ${budget}.");
            }
            computers.Remove(computer);
            return computer.ToString();
        }

        public string BuyComputer(int id)
        {
            IsExistingCompWithId(id);
            computer = computers.FirstOrDefault(c => c.Id == id);
            computers.Remove(computer);
            return computer.ToString();
        }

        public string GetComputerData(int id)
        {
            IsExistingCompWithId(id);
            computer = computers.FirstOrDefault(c => c.Id == id);
            return computer.ToString();
        }

        public string RemoveComponent(string componentType, int computerId)
        {
            IsExistingCompWithId(computerId);
            computer = computers.FirstOrDefault(c => c.Id == computerId);
            component = components.FirstOrDefault(c => c.GetType().Name == componentType);
            //moje da iska proverka dali componenta ne e NULL
             computer.RemoveComponent(componentType);
             components.Remove(component);
             return $"Successfully removed {componentType} with id {component.Id}.";
            
        }

        public string RemovePeripheral(string peripheralType, int computerId)
        {
            IsExistingCompWithId(computerId);
            computer = computers.FirstOrDefault(c => c.Id == computerId);
            peripheral = peripherals.FirstOrDefault(c => c.GetType().Name == peripheralType);
            //moje da iska proverka dali peripherala ne e NULL
            computer.RemovePeripheral(peripheralType);
            peripherals.Remove(peripheral);
            return $"Successfully removed {peripheralType} with id {peripheral.Id}.";
        }
        private void IsExistingCompWithId(int id)
        {
            if(!computers.Any(c => c.Id==id))
            {
                throw new ArgumentException("Computer with this id does not exist.");
            }
        }
    }
}
