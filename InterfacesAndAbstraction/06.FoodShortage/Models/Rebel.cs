using _04.BorderControl.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace _04.BorderControl.Models
{
    public class Rebel :IBuyer
    {
        private const int FOOD_INCREASER = 5;
        public Rebel(string name , int age , string group)
        {
            this.Name = name;
            this.Age = age;
            this.Group = group;
            this.Food = 0;
        }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Group { get; set; }
        public int Food { get; set; }
        public void BuyFood()
        {
            this.Food += FOOD_INCREASER;
        }
    }
}
