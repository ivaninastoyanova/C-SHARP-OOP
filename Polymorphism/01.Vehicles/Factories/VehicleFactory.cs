using Polymorphism.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Polymorphism.Factories
{
    public class VehicleFactory
    {
        public Vehicle CreateVehicle ( string vehicleType , double fuelQuantity , double fuelConsumption)
        {
            Vehicle vehicle;
            if(vehicleType=="Car")
            {
                vehicle = new Car(fuelQuantity, fuelConsumption);
            }
            else if(vehicleType == "Truck")
            {
                vehicle = new Truck(fuelQuantity, fuelConsumption);
            }
            else
            {
                throw new InvalidOperationException(Common.ExceptionMessages.InvalidVehicleType);
            }
            return vehicle;
        }
    }
}
