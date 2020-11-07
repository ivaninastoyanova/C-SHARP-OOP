using _04.BorderControl.Interfaces;
using _04.BorderControl.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.BorderControl
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<IId> creatures = new List<IId>();
            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] splitted = command.Split().ToArray();
                if (splitted.Length == 2)
                {
                    string model = splitted[0];
                    string id = splitted[1];
                    IId robot = new Robot(model, id);
                    creatures.Add(robot);
                }
                else if (splitted.Length == 3)
                {
                    string name = splitted[0];
                    int age = int.Parse(splitted[1]);
                    string id = splitted[2];
                    IId citizen = new Citizen(name, age, id);
                    creatures.Add(citizen);
                }
            }
            string fakeIdLastDigits = Console.ReadLine();
            
            creatures.Where(c => c.Id.EndsWith(fakeIdLastDigits))
           .Select(c => c.Id)
           .ToList()
           .ForEach(Console.WriteLine);
        }
    }
}
