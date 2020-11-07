using _04.BorderControl.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace _04.BorderControl.Models
{
    public class Citizen : IBuyer
    {
        private const int FOOD_INCREASER = 10;
        public Citizen(string name,int age,string id,string birthday)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
            this.Birthday = birthday;
            this.Food = 0; 
        }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Id { get; set; }
        public string Birthday { get; set; }
        public int Food { get; set; }
        public void BuyFood()
        {
            this.Food += FOOD_INCREASER;
        }
    }
}
