﻿using System;
using System.Collections.Generic;
using System.Text;

namespace _03.Raiding.Models
{
    public class Druid : BaseHero
    {
        private const int POWER = 80;
        public Druid(string name) : base(name)
        {
            this.Power = POWER;
        }

        public override string CastAbility()
        {
            return $"{this.GetType().Name} - {this.Name} healed for {this.Power}";
        }
    }
}
