using System;
using System.Collections.Generic;
using System.Text;

namespace Polymorphism.Models
{
    public class Car : Vehicle
    {
        private const double FUEL_CONSUMPTION_ICR = 0.9;
        public Car(double fuelQuantity, double fuelConsumption) 
            : base(fuelQuantity, fuelConsumption)
        {
        }
        public override double FuelConsumptionPerKm =>
            base.FuelConsumptionPerKm + FUEL_CONSUMPTION_ICR;
    }
}
