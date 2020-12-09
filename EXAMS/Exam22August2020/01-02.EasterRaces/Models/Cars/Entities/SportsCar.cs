using System;
using System.Collections.Generic;
using System.Text;

namespace EasterRaces.Models.Cars.Entities
{
    public class SportsCar :Car
    {
        private const double cubicCent = 3000.0;
        private const int minHP = 250;
        private const int maxHP = 450;

        public SportsCar(string model, int horsePower)
            : base(model, horsePower, cubicCent, minHP, maxHP)
        {
        }
    }
}
