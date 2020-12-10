using RobotService.Core.Contracts;
using RobotService.Models.Garages;
using RobotService.Models.Garages.Contracts;
using RobotService.Models.Procedures;
using RobotService.Models.Procedures.Contracts;
using RobotService.Models.Robots;
using RobotService.Models.Robots.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RobotService.Core
{
    public class Controller : IController
    {
        private IGarage garage;
        private Dictionary<string, IProcedure> procedures;
        private IRobot robot;
        public Controller()
        {
            this.garage = new Garage();
            this.procedures = new Dictionary<string, IProcedure>()
            {
                {"Chip", new Chip() },
                {"Charge", new Charge() },
                {"Polish", new Polish() },
                {"Rest", new Rest() },
                {"TechCheck", new TechCheck() },
                {"Work", new Work() }
            };
        }
        public string Charge(string robotName, int procedureTime)
        {
            IsExisting(robotName);
            robot = garage.Robots[robotName];
            procedures["Charge"].DoService(robot, procedureTime);
            return $"{robotName} had charge procedure";
        }

        public string Chip(string robotName, int procedureTime)
        {
            IsExisting(robotName);
            robot = garage.Robots[robotName];
            procedures["Chip"].DoService(robot, procedureTime);
            return $"{robotName} had chip procedure";
        }

        public string History(string procedureType)
        {
            IProcedure procedure = this.procedures.FirstOrDefault(p => p.Key == procedureType).Value;
            return procedure.History();
        }

        public string Manufacture(string robotType, string name, int energy, int happiness, int procedureTime)
        {
            if(robotType == "HouseholdRobot")
            {
               robot = new HouseholdRobot(name, energy, happiness, procedureTime);
            }
            else if( robotType == "PetRobot")
            {
               robot = new PetRobot(name, energy, happiness, procedureTime);
            }
            else if (robotType == "WalkerRobot")
            {
               robot = new WalkerRobot(name, energy, happiness, procedureTime);
            }
            else
            {
                throw new ArgumentException($"{robotType} type doesn't exist");
            }
            garage.Manufacture(robot);
            return $"Robot {name} registered successfully";
        }

        public string Polish(string robotName, int procedureTime)
        {
            IsExisting(robotName);
            robot = garage.Robots[robotName];
            procedures["Polish"].DoService(robot, procedureTime);
            return $"{robotName} had polish procedure";
        }

        public string Rest(string robotName, int procedureTime)
        {
            IsExisting(robotName);
            robot = garage.Robots[robotName];
            procedures["Rest"].DoService(robot, procedureTime);
            return $"{robotName} had rest procedure";
        }

        public string Sell(string robotName, string ownerName)
        {
            IsExisting(robotName);
            robot = garage.Robots[robotName];
            garage.Sell(robotName, ownerName);
            if(robot.IsChipped == true)
            {
                return $"{ownerName} bought robot with chip";
            }
            else
            {
                return $"{ownerName} bought robot without chip";
            }
            
        }

        public string TechCheck(string robotName, int procedureTime)
        {
            IsExisting(robotName);
            robot = garage.Robots[robotName];
            procedures["TechCheck"].DoService(robot, procedureTime);
            return $"{robotName} had tech check procedure";
        }

        public string Work(string robotName, int procedureTime)
        {
            IsExisting(robotName);
            robot = garage.Robots[robotName];
            procedures["Work"].DoService(robot, procedureTime);
            return $"{robotName} was working for {procedureTime} hours";
        }
        private void IsExisting(string name)
        {
            if (!garage.Robots.ContainsKey(name))
            {
                throw new ArgumentException($"Robot {name} does not exist");
            }
        }
    }
}
