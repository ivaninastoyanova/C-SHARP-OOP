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
            List<IBirthday> petsAndPeople = new List<IBirthday>();
            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] splitted = command.Split().ToArray();
                if(splitted[0] == "Citizen")
                {
                    string name = splitted[1];
                    int age = int.Parse(splitted[2]);
                    string id = splitted[3];
                    string birthday = splitted[4];
                    IBirthday citizen = new Citizen(name, age, id,birthday);
                    petsAndPeople.Add(citizen);
                }
                else if(splitted[0] == "Pet")
                {
                    string name = splitted[1];
                    string birthday = splitted[2];
                    IBirthday pet = new Pet(name,birthday);
                    petsAndPeople.Add(pet);
                }
            }
                string year = Console.ReadLine();
            petsAndPeople.Where(y => y.Birthday.Split("/").ToArray().Last() == year)
                .Select(y => y.Birthday)
                .ToList()
                .ForEach(Console.WriteLine);
            }
        }
    }
