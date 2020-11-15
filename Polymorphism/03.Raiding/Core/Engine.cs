using _03.Raiding.Factories;
using _03.Raiding.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _03.Raiding.Core
{
    public class Engine
    {
        private readonly List<BaseHero> heroes;
        private HeroFactory heroFactory;
        public Engine()
        {
            this.heroes = new List<BaseHero>();
            this.heroFactory = new HeroFactory();
        }
        public void Run()
        {
            CreateAndAddHeroes();

            int bossPower = int.Parse(Console.ReadLine());
            int heroesPower = 0;
            if (heroes.Count != 0)
            {
                foreach (var hero in heroes)
                {
                    Console.WriteLine(hero.CastAbility()); 
                }
                heroesPower = heroes.Sum(h => h.Power);
            }

            if(heroesPower>= bossPower)
            {
                Console.WriteLine("Victory!");
            }
            else
            {
                Console.WriteLine("Defeat...");
            }
        }

        private void CreateAndAddHeroes()
        {
            int n = int.Parse(Console.ReadLine());
            while (heroes.Count < n)
            {
                BaseHero hero = null;
                try
                {
                    string heroName = Console.ReadLine();
                    string heroType = Console.ReadLine();
                    hero = this.heroFactory.CreateHero(heroName, heroType);
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                    continue;
                }

                if (heroFactory != null)
                {
                    heroes.Add(hero);
                }
            }
        }
    }    

        
    
}
