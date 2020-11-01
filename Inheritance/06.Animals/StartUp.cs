using System;
using System.Collections.Generic;
using System.Linq;

namespace Animals
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<Animal> animals = new List<Animal>();

            Processing(animals);
            PrintOutput(animals);
        }

        private static void PrintOutput(List<Animal> animals)
        {
            foreach (var animal in animals)
            {
                Console.WriteLine(animal);
            }
        }

        private static void Processing(List<Animal> animals)
        {
            string animalType;
            while ((animalType = Console.ReadLine()) != "Beast!")
            {
                string[] animalArgs = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                string name = animalArgs[0];
                int age = int.Parse(animalArgs[1]);
                string gender = GetGender(animalArgs);
                Animal animal = GetAnimal(animalType, name, age, gender);
                if (animal != null)
                {
                    animals.Add(animal);
                }
            }
        }

        private static Animal GetAnimal(string animalType, string name, int age, string gender)
        {
            Animal animal = null;
            try
            {
                switch (animalType)
                {
                    case "Cat":
                        animal = new Cat(name, age, gender);
                        break;
                    case "Dog":
                        animal = new Dog(name, age, gender);
                        break;
                    case "Frog":
                        animal = new Frog(name, age, gender);
                        break;
                    case "Kitten":
                        animal = new Kitten(name, age);
                        break;
                    case "Tomcat":
                        animal = new Tomcat(name, age);
                        break;
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }

            return animal;
        }

        private static string GetGender(string[] animalArgs)
        {
            string gender = null;
            if (animalArgs.Length >= 3)
            {
                gender = animalArgs[2];
            }

            return gender;
        }
    
    }
}
