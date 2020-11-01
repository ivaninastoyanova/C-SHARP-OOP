using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed
{
    public class Vehicle
    {
        private const double DefaultFuelConsumption = 1.25;
        public virtual double FuelConsumption
        {
            get
            {
                return DefaultFuelConsumption;
            }
        }
        public int HorsePower { get; set; }
        public double Fuel { get; set; }
        public Vehicle(int horsePower , double fuel)
        {
            HorsePower = horsePower;
            Fuel = fuel;
        }
        public virtual void Drive(double kilometers)
        {
            Fuel = Fuel - kilometers*FuelConsumption;
        }
    }
}
