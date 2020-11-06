using System;
using System.Collections.Generic;
using System.Text;

namespace _05.FootballTeamGenerator
{
    public class Stats
    {
        public const string INVALID_STATS_EXP_MSG = "{0} should be between 0 and 100.";
        private int endurance;
        private int sprint;
        private int dribble;
        private int passing;
        private int shooting;
        public Stats(int endurance , int sprint , int dribble , int passing , int shooting)
        {
            this.Endurance = endurance;
            this.Sprint = sprint;
            this.Dribble = dribble;
            this.Passing = passing;
            this.Shooting = shooting;
        }
        public int Endurance
        {
            get
            {
                return this.endurance;
            }
            private set
            {
                if(!IsValidStat(value))
                {
                    throw new ArgumentException(String.Format(INVALID_STATS_EXP_MSG, nameof(Endurance)));
                }
                this.endurance = value;
            }
        }
        public int Sprint
        {
            get
            {
                return this.sprint;
            }
            private set
            {
                if (!IsValidStat(value))
                {
                    throw new ArgumentException(String.Format(INVALID_STATS_EXP_MSG, nameof(Sprint)));
                }
                this.sprint = value;
            }
        }
        public int Dribble
        {
            get
            {
                return this.dribble;
            }
            private set
            {
                if (!IsValidStat(value))
                {
                    throw new ArgumentException(String.Format(INVALID_STATS_EXP_MSG, nameof(Dribble)));
                }
                this.dribble = value;
            }
        }
        public int Passing
        {
            get
            {
                return this.passing;
            }
            private set
            {
                if (!IsValidStat(value))
                {
                    throw new ArgumentException(String.Format(INVALID_STATS_EXP_MSG, nameof(Passing)));
                }
                this.passing = value;
            }
        }
        public int Shooting
        {
            get
            {
                return this.shooting;
            }
            private set
            {
                if (!IsValidStat(value))
                {
                    throw new ArgumentException(String.Format(INVALID_STATS_EXP_MSG, nameof(Shooting)));
                }
                this.shooting = value;
            }
        }

        private bool IsValidStat(int stat)
        {
            if(stat<0 || stat>100)
            {
                return false;
            }
            return true;
        }

        public double AverageStat 
        {
            get
            {
                double average = (this.Endurance + this.Sprint + this.Dribble + this.Passing + this.Shooting) / (double)5;
                return average;
            }
        }
    }
}
