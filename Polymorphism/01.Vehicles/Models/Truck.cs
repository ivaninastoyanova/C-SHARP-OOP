using System;
using System.Collections.Generic;
using System.Text;

namespace Polymorphism.Models
{
    public class Truck : Vehicle
    {
        private const double FUEL_CONSUMPTION_ICR =1.6;
        private const double REFUEL_SUCC = 0.95;


        public Truck(double fuelQuantity, double fuelConsumption) 
            : base(fuelQuantity, fuelConsumption)
        {
        }
        public override double FuelConsumptionPerKm =>
            base.FuelConsumptionPerKm + FUEL_CONSUMPTION_ICR;
        public override void Refuel(double amount)
        {
            base.Refuel(amount* REFUEL_SUCC);
        }

    }
}
