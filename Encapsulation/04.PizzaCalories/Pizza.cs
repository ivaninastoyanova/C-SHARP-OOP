using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _04.PizzaCalories
{
    public class Pizza
    {
        public const int PIZZA_MIN_TOPPING_COUNT = 0;
        public const int PIZZA_MAX_TOPPING_COUNT = 10;
        public const int PIZZA_NAME_MIN_LENGHT = 1;
        public const int PIZZA_NAME_MAX_LENGHT = 15;

        public const string INVALID_NAME_EX_MSG = "Pizza name should be between {0} and {1} symbols.";
        public const string PIZZA_INVALID_TOPPING_COUNT_MSG = "Number of toppings should be in range [{0}..{1}].";

        private readonly IList<Topping> toppings;
        private readonly Dough dough;
        private string name;
        public Pizza(string name, Dough dough)
        {
            this.Name = name;
            this.dough = dough;
            this.toppings = new List<Topping>();
        }
        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                if (string.IsNullOrEmpty(value) || value.Length > 15)
                {
                    throw new ArgumentException(String.Format(INVALID_NAME_EX_MSG,PIZZA_NAME_MIN_LENGHT , PIZZA_NAME_MAX_LENGHT));
                }

                this.name = value;
            }
        }

        public void AddTopping(Topping topping)
        {
            this.toppings.Add(topping);

            if (this.toppings.Count > PIZZA_MAX_TOPPING_COUNT)
            {
                throw new ArgumentException(string.Format(PIZZA_INVALID_TOPPING_COUNT_MSG, PIZZA_MIN_TOPPING_COUNT , PIZZA_MAX_TOPPING_COUNT));
            }
        }

        public double CalcTotalCalories()
        {
            double doughCalories = this.dough.CalcCalogies();
            double toppingsCalories = this.toppings.Sum(t => t.CalcCalories());

            return doughCalories + toppingsCalories;
        }

    }
}
