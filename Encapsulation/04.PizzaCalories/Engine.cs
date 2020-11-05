using System;
using System.Collections.Generic;
using System.Text;

namespace _04.PizzaCalories
{
    public class Engine
    {
        private Pizza pizza;
        public Engine()
        {

        }

        public void Run()
        {
            try
            {
                this.ProcessInput();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return;
            }

            this.PrintOutput();
        }

        private void ProcessInput()
        {
            string[] pizzaInfo = Console.ReadLine().Split();
            string pizzaName = pizzaInfo[1];

            string[] doughInfo = Console.ReadLine().Split();
            string flourType = doughInfo[1];
            string bakingTechnique = doughInfo[2];
            double doughWeight = double.Parse(doughInfo[3]);
            Dough dough = new Dough(flourType, bakingTechnique, doughWeight);

            this.pizza = new Pizza(pizzaName, dough);

            string toppingInfo = Console.ReadLine();
            while (toppingInfo != "END")
            {
                string[] args = toppingInfo.Split();
                string toppingType = args[1];
                double toppingWeight = double.Parse(args[2]);
                Topping topping = new Topping(toppingType, toppingWeight);
                this.pizza.AddTopping(topping);

                toppingInfo = Console.ReadLine();
            }
        }

        private void PrintOutput()
        {
            Console.WriteLine($"{pizza.Name} - {pizza.CalcTotalCalories():F2} Calories.");
        }
    }
}
