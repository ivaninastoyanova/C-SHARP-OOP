using System;
using System.Collections.Generic;
using System.Text;

namespace _04.PizzaCalories
{
    public class Dough
    {
        private const string INVALID_FLOUR_OR_TECHNIQUE_MSG_EX = "Invalid type of dough." ;
        private const string INVALID_WEIGHT_MSG_EX = "Dough weight should be in the range [1..200]." ;
        public const string MODIFIER_INVALID = "Such a modifier does not exist.";

        private const int DOUGH_MIN_WEIGHT = 1;
        private const int DOUGH_MAX_WEIGHT = 200;
        private const int DEFAULT_DOUGH_CALORIES_PER_GRAM = 2;

        private string flourType;
        private string bakingTechnique;
        private double weight;
        public Dough(string flourType , string bakingTechnique , double weight)
        {
            this.FlourType = flourType;
            this.BakingTechnique = bakingTechnique;
            this.Weight = weight;
        }
       
        public string FlourType
        {
            get
            {
                return this.flourType;
            }
            private set
            {
                if (!IsDoughValid(value))
                {
                    throw new ArgumentException(INVALID_FLOUR_OR_TECHNIQUE_MSG_EX);
                }
                 this.flourType = value;
            }
        }
        public string BakingTechnique
        {
            get
            {
                return this.bakingTechnique; ;
            }
            private set
            {
                if(!IsDoughValid(value))
                {
                    throw new ArgumentException(INVALID_FLOUR_OR_TECHNIQUE_MSG_EX);
                }
                this.bakingTechnique = value;
            }
        }
        public double Weight
        {
            get
            {
                return this.weight; ;
            }
            private set
            {
                if (value<DOUGH_MIN_WEIGHT || value>DOUGH_MAX_WEIGHT)
                {
                    throw new ArgumentException(INVALID_WEIGHT_MSG_EX);
                }
                this.weight = value;
            }
        }

        private readonly IDictionary<string, double> DoughsWithModifiers = new Dictionary<string, double>
        {
            { "white", 1.5 },
            { "wholegrain", 1.0 },
            { "crispy", 0.9 },
            { "chewy", 1.1 },
            { "homemade", 1.0 }
        };
        public  bool IsDoughValid(string doughType)
        {
            string searcherDoughType = doughType.ToLower();

            if (DoughsWithModifiers.ContainsKey(searcherDoughType))
            {
                return true;
            }

            return false;
        }

        public double GetDoughModifier(string flourTypeOrBakingTechnique)
        {
            string searcherDoughModifier = flourTypeOrBakingTechnique.ToLower();

            if (DoughsWithModifiers.ContainsKey(searcherDoughModifier))
            {
                double doughModifier = DoughsWithModifiers[searcherDoughModifier];
                return doughModifier;
            }

            throw new ArgumentException(MODIFIER_INVALID);
        }
        public double CalcCalogies()
        {
            double result = this.Weight * DEFAULT_DOUGH_CALORIES_PER_GRAM * GetDoughModifier(this.flourType) *GetDoughModifier(this.bakingTechnique);
            return result;
        }

    }
}
