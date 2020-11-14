using Polymorphism.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Polymorphism.Models
{
    public abstract class Vehicle : IDrivable, IRefuelable
    {
        private const string SUCC_DRIVED_MSG = "{0} travelled {1} km";
        public double FuelQuantuty { get; private set; }
        public virtual double FuelConsumptionPerKm { get; private set; }
        protected Vehicle(double fuelQuantity , double fuelConsumption)
        {
            this.FuelQuantuty = fuelQuantity;
            this.FuelConsumptionPerKm = fuelConsumption;
        }

        public string Drive(double amount)
        {
            double fuelNeeded = amount * FuelConsumptionPerKm;
            if (FuelQuantuty < fuelNeeded)
            {
                throw new InvalidOperationException(String.Format(Common.ExceptionMessages.NotEnoughFuel , this.GetType().Name ));
            }
            this.FuelQuantuty -= fuelNeeded;
            return String.Format(SUCC_DRIVED_MSG, this.GetType().Name , amount);
        }

        public virtual void Refuel(double amount)
        {
            if(amount<=0)
            {
                throw new InvalidOperationException(String.Format(Common.ExceptionMessages.NegativeFuel));
            }
            this.FuelQuantuty += amount;
        }
        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantuty:f2}";
        }
    }
}
