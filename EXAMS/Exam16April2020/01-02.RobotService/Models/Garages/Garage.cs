using RobotService.Models.Garages.Contracts;
using RobotService.Models.Robots;
using RobotService.Models.Robots.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RobotService.Models.Garages
{
    public class Garage : IGarage
    {
        private readonly Dictionary<string, IRobot> robots; 
        private const int Capacity = 10;
        public Garage()
        {
            this.robots = new Dictionary<string, IRobot>();
        }
        public IReadOnlyDictionary<string, IRobot> Robots => this.robots;

        public void Manufacture(IRobot robot)
        {
            if(robots.Count>=10)
            {
                throw new InvalidOperationException("Not enough capacity");
            }
            if(robots.ContainsKey(robot.Name))
            {
                throw new ArgumentException($"Robot {robot.Name} already exist");
            }
            robots.Add(robot.Name, robot);
        }

        public void Sell(string robotName, string ownerName)
        {
            if(!robots.ContainsKey(robotName))
            {
                throw new ArgumentException($"Robot {robotName} does not exist");
            }
            IRobot robotToSell = robots.FirstOrDefault(r => r.Key == robotName).Value;
            robotToSell.Owner = ownerName;
            robotToSell.IsBought = true;
            robots.Remove(robotName);
        }
    }
}
