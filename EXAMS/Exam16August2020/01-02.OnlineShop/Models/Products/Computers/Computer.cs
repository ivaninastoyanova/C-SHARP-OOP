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
        private List<IComponent> components;
        private List<IPeripheral> peripherals;
        public Computer(int id, string manufacturer, string model, decimal price, double overallPerformance) 
            : base(id, manufacturer, model, price, overallPerformance)
        {
            this.components = new List<IComponent>();
            this.peripherals = new List<IPeripheral>();
        }

        public IReadOnlyCollection<IComponent> Components => components.AsReadOnly();

        public IReadOnlyCollection<IPeripheral> Peripherals => peripherals.AsReadOnly();

        public override double OverallPerformance => CalculateOverallPerformance();
        public override decimal Price => base.Price + this.components.Sum(c => c.Price) + this.peripherals.Sum(p => p.Price);


        public void AddComponent(IComponent component)
        {
            if(this.Components.Any( c =>c.GetType().Name == component.GetType().Name))
            {
                throw new ArgumentException($"Component {component.GetType().Name} already exists in {this.GetType().Name} with Id {this.Id}.");
            }
            components.Add(component);
        }

        public void AddPeripheral(IPeripheral peripheral)
        {
            if (this.Peripherals.Any(p => p.GetType().Name == peripheral.GetType().Name))
            {
                throw new ArgumentException($"Peripheral {peripheral.GetType().Name} already exists in {this.GetType().Name} with Id {this.Id}.");
            }
            peripherals.Add(peripheral);
        }

        public IComponent RemoveComponent(string componentType)
        {
            if(!this.Components.Any() || !this.Components.Any( c => c.GetType().Name == componentType))
            {
                throw new ArgumentException($"Component {componentType} does not exist in {this.GetType().Name} with Id {this.Id}.");
            }
            IComponent componentToReturn = this.Components.FirstOrDefault(c => c.GetType().Name == componentType);
            components.Remove(componentToReturn);
            return componentToReturn;
        }

        public IPeripheral RemovePeripheral(string peripheralType)
        {
            if (!Peripherals.Any() || !Components.Any(c => c.GetType().Name == peripheralType))
            {
                throw new ArgumentException($"Component {peripheralType} does not exist in {this.GetType().Name} with Id {this.Id}.");
            }
            IPeripheral peripheralToReturn = this.Peripherals.FirstOrDefault(p => p.GetType().Name == peripheralType);
            peripherals.Remove(peripheralToReturn);
            return peripheralToReturn;
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine($" Components ({this.Components.Count}):");
            foreach (var component in Components)
            {
                sb.AppendLine($"  {component.ToString()}");
            }
            double overrallP = this.peripherals.Any() ? this.Peripherals.Average(p => p.OverallPerformance) : 0;
            sb.AppendLine($" Peripherals ({this.Peripherals.Count}); " +
                $"Average Overall Performance ({overrallP:F2}):");
            foreach (var peripheral in Peripherals)
            {
                sb.AppendLine($"  {peripheral.ToString()}");
            }
            return sb.ToString().Trim();
        }
        private double CalculateOverallPerformance()
        {
            if(components.Count==0)
            {
                return base.OverallPerformance;
            }
            else
            {
                return base.OverallPerformance + components.Average(c => c.OverallPerformance);
            }
        }

    }
}
