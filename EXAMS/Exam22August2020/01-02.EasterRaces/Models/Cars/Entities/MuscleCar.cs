using System;
using System.Collections.Generic;
using System.Text;

namespace EasterRaces.Models.Cars.Entities
{
    public class MuscleCar : Car
    {
        private const double cubicCent = 5000.0;
        private const int minHP = 400;
        private const int maxHP = 600;
        
        public MuscleCar(string model, int horsePower) 
            : base(model, horsePower, cubicCent, minHP, maxHP)
        {
        }
    }
}
