using System;
using System.Collections.Generic;
using System.Text;

namespace _05.FootballTeamGenerator
{
    public class Player
    {
        public const string INVALID_NAME_EXP_MSG = "A name should not be empty.";
        private string name;
        public Player(string name , Stats stats)
        {
            this.Name = name;
            this.Stats = stats;
        }
        public string Name
        {
            get 
            {
                return this.name;
            }
            private set
            {
                if(String.IsNullOrWhiteSpace (value))
                {
                    throw new ArgumentException(INVALID_NAME_EXP_MSG);
                }
                this.name = value;
            }
        }
        public Stats Stats { get; set; }
        public double OverallSkill
        {
            get
            {
                return this.Stats.AverageStat;
            }
        }

    }
}
