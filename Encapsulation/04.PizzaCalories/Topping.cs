using System;
using System.Collections.Generic;
using System.Text;

namespace _04.PizzaCalories
{
    public class Topping
    {
        public const string TOPPING_INVALID_TYPE = "Cannot place {0} on top of your pizza.";
        public const string TOPPING_INVALID_WEIGHT = "{0} weight should be in the range [{1}..{2}].";
        public const string MODIFIER_INVALID = "Such a modifier does not exist.";

        private const int DEFAULT_TOPPING_CALORIES_PER_GRAM = 2;
        private const double TOPPING_MIN_WEIGHT = 1;
        private const double TOPPING_MAX_WEIGHT = 50;
        private string type;
        private double weight;

        public Topping(string type, double weight)
        {
            this.Type = type;
            this.Weight = weight;
        }

        public string Type
        {
            get
            {
                return this.type;
            }
            set
            {
                if (!IsToppingValid(value))
                {
                    throw new ArgumentException(String.Format(TOPPING_INVALID_TYPE, value));
                }
                this.type = value;
            }
        }
        public double Weight
        {
            get
            {
                return this.weight;
            }
            set
            {
                if (value<TOPPING_MIN_WEIGHT || value>TOPPING_MAX_WEIGHT)
                {
                    throw new ArgumentException(String.Format(TOPPING_INVALID_WEIGHT, this.Type,TOPPING_MIN_WEIGHT,TOPPING_MAX_WEIGHT));
                }
                this.weight = value;
            }
        }

        private static readonly IDictionary<string, double> ToppingsWithModifiers = new Dictionary<string, double>
        {
            { "meat", 1.2 },
            { "veggies", 0.8 },
            { "cheese", 1.1 },
            { "sauce", 0.9 }
        };
        public bool IsToppingValid(string toppingType)
        {
            string searchedTopping = toppingType.ToLower();

            if (ToppingsWithModifiers.ContainsKey(searchedTopping))
            {
                return true;
            }

            return false;
        }

        public double GetToppingModifier(string toppingName)
        {
            string searchedToppingModifier = toppingName.ToLower();

            if (ToppingsWithModifiers.ContainsKey(searchedToppingModifier))
            {
                double toppingModifier = ToppingsWithModifiers[searchedToppingModifier];
                return toppingModifier;
            }

            throw new ArgumentException(MODIFIER_INVALID);
        }
        public double CalcCalories()
        {
            double result = this.Weight * DEFAULT_TOPPING_CALORIES_PER_GRAM * GetToppingModifier(this.Type);
            return result;
        }

    }
}

