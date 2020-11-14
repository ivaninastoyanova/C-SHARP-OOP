using Polymorphism.Contracts;
using Polymorphism.Factories;
using Polymorphism.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Polymorphism.Core
{
    public class Engine : IEngine
    {

        private readonly VehicleFactory vehicleFactory;
        public Engine()
        {
            this.vehicleFactory = new VehicleFactory();
        }
        public void Run()
        {
            Vehicle car = this.ProcessVehicleInfo();
            Vehicle truck  = this.ProcessVehicleInfo();

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] commandArgs = Console.ReadLine().Split().ToArray() ;
                string commandType = commandArgs[0];
                string vehicleType = commandArgs[1];
                double arg = double.Parse(commandArgs[2]);
                try
                {
                    if (commandType == "Drive")
                    {
                        if (vehicleType == "Car")
                        {
                            this.Drive(car, arg);
                        }
                        else if (vehicleType == "Truck")
                        {
                            this.Drive(truck, arg);
                        }
                    }
                    else if (commandType == "Refuel")
                    {
                        if (vehicleType == "Car")
                        {
                            this.Refuel(car, arg);
                        }
                        else if (vehicleType == "Truck")
                        {
                            this.Refuel(truck, arg);
                        }
                    }
                }
                catch (InvalidOperationException ioe)
                {
                    Console.WriteLine(ioe.Message); ;
                }
            }
            Console.WriteLine(car.ToString());
            Console.WriteLine(truck.ToString());
        }
        public void Refuel(Vehicle vehicle , double amount)
        {
            vehicle.Refuel(amount);
        }
        private void Drive (Vehicle vehicle , double kilometers)
        {
            Console.WriteLine(vehicle.Drive(kilometers));
        }
        private Vehicle ProcessVehicleInfo()
        {
            string[] vehicleArgs = Console.ReadLine().Split().ToArray();
            string vehicleType = vehicleArgs[0];
            double  fuelQuantity = double.Parse(vehicleArgs[1]);
            double  fuelConsumption = double.Parse(vehicleArgs[2]);
            Vehicle currentVehicle = this.vehicleFactory.CreateVehicle(vehicleType, fuelQuantity, fuelConsumption);
            return currentVehicle;
        }
    }
}
