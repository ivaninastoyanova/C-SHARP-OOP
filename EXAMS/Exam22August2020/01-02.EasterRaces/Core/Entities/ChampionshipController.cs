using EasterRaces.Core.Contracts;
using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Models.Cars.Entities;
using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Models.Drivers.Entities;
using EasterRaces.Models.Races.Contracts;
using EasterRaces.Models.Races.Entities;
using EasterRaces.Repositories.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasterRaces.Core.Entities
{
    public class ChampionshipController : IChampionshipController
    {
        private CarRepository cars;
        private DriverRepository drivers;
        private RaceRepository races;

        public ChampionshipController()
        {
            this.cars = new CarRepository();
            this.drivers = new DriverRepository();
            this.races = new RaceRepository();
        }
        public string AddCarToDriver(string driverName, string carModel)
        {
            if(!this.drivers.GetAll().Any(d => d.Name == driverName))
            {
                throw new InvalidOperationException($"Driver {driverName} could not be found.");
            }
            if (!this.cars.GetAll().Any(c => c.Model == carModel)) 
            {
                throw new InvalidOperationException($"Car { carModel } could not be found.");
            }
            ICar car = this.cars.GetAll().FirstOrDefault(c => c.Model == carModel);
            IDriver driver = this.drivers.GetAll().FirstOrDefault(d => d.Name == driverName);
            driver.AddCar(car);
            return $"Driver {driverName} received car {carModel}.";
        }

        public string AddDriverToRace(string raceName, string driverName)
        {
            if (!this.races.GetAll().Any(r => r.Name == raceName))
            {
                throw new InvalidOperationException($"Race {raceName} could not be found.");
            }
            if (!this.drivers.GetAll().Any(d => d.Name == driverName))
            {
                throw new InvalidOperationException($"Driver {driverName} could not be found.");
            }
            IRace race = this.races.GetAll().FirstOrDefault(r => r.Name == raceName);
            IDriver driver = this.drivers.GetAll().FirstOrDefault(d => d.Name == driverName);
            race.AddDriver(driver);
            return $"Driver {driverName} added in {raceName} race.";
        }

        public string CreateCar(string type, string model, int horsePower)
        {
            ICar car = null;
            if (type == "Muscle")
            {
                if(this.cars.GetAll().Any(c => c.Model == model))
                {
                    throw new ArgumentException($"Car {model} is already created.");
                }
                car = new MuscleCar(model, horsePower);
                cars.Add(car);
                return $"MuscleCar {model} is created.";
            }
            else if(type == "Sports")
            {
                if (this.cars.GetAll().Any(c => c.Model == model))
                {
                    throw new ArgumentException($"Car {model} is already created.");
                }
                car = new SportsCar(model, horsePower);
                cars.Add(car);
                return $"SportsCar {model} is created.";
            }
            else
            {
                return "nito ednoto";
            }
        }

        public string CreateDriver(string driverName)
        {
            if(this.drivers.GetAll().Any(d => d.Name == driverName))
            {
                throw new ArgumentException($"Driver {driverName} is already created.");
            }
            IDriver driver = new Driver(driverName);
            drivers.Add(driver);
            return $"Driver {driverName} is created.";
        }

        public string CreateRace(string name, int laps)
        {
            if(this.races.GetAll().Any(r => r.Name == name))
            {
                throw new InvalidOperationException($"Race { name } is already create.");
            }
            IRace race = new Race(name, laps);
            races.Add(race);
            return $"Race {name} is created.";
        }

        public string StartRace(string raceName)
        {
            if(!this.races.GetAll().Any(r => r.Name == raceName))
            {
                throw new InvalidOperationException($"Race {raceName} could not be found.");
            }
            IRace race = this.races.GetAll().FirstOrDefault(r => r.Name == raceName);
            if (race.Drivers.Count<3)
            {
                throw new InvalidOperationException($"Race {raceName} cannot start with less than 3 participants.");
            }
            List<IDriver> sortedDrivers = race.Drivers.ToList()
                                    .OrderByDescending(d => d.Car.CalculateRacePoints(race.Laps))
                                    .Take(3).ToList();
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < sortedDrivers.Count; i++)
            {
                IDriver driver = sortedDrivers[i];
                if (i == 0)
                {
                    sb.AppendLine($"Driver {driver.Name} wins {race.Name} race.");
                }
                else if (i == 1)
                {
                    sb.AppendLine($"Driver {driver.Name} is second in {race.Name} race.");
                }
                else if (i == 2)
                {
                    sb.AppendLine($"Driver {driver.Name} is third in {race.Name} race.");
                }

            }
            this.races.Remove(race);
            return sb.ToString().Trim();
        }
    }
}
