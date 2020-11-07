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
            int totalFood = 0; 
            int numberOfPeople = int.Parse(Console.ReadLine());
            List<IBuyer> people = new List<IBuyer>();
            string[] input;
            for (int i = 0; i < numberOfPeople; i++)
            {
                input = Console.ReadLine().Split().ToArray();
                if (input.Length == 4)
                {
                    string name = input[0];
                    int age = int.Parse(input[1]);
                    string id = input[2];
                    string birthday = input[3];
                    IBuyer citizen = new Citizen(name, age, id, birthday);
                    people.Add(citizen);
                }
                else if (input.Length == 3)
                {
                    string name = input[0];
                    int age = int.Parse(input[1]);
                    string group = input[2];
                    IBuyer rebel = new Rebel(name, age, group);
                    people.Add(rebel);
                }
            }
            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                string name = command;
                if (people.Any(b => b.Name == name))
                {
                    var customer = people.First(b => b.Name == name);
                    customer.BuyFood();
                }
            }

            foreach (var customer in people)
            {
                totalFood += customer.Food;
            }
            Console.WriteLine(totalFood);
        }
    }
}