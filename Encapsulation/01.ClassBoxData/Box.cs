using System;
using System.Collections.Generic;
using System.Text;

namespace _01.ClassBoxData
{
    public class Box
    {
        private double length;
        private double width;
        private double height;
        public Box(double length , double width , double height)
        {
            Length = length;
            Width = width;
            Height = height;
        }
        public double Length
        {
            get
            {
                return this.length;
            }
            private set
            {
                if(value < 0 )
                {
                    throw new ArgumentException("Length cannot be zero or negative.");
                }
                    this.length = value;
            }
        }
        public double Width
        {
            get
            {
                return this.width;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Width cannot be zero or negative.");
                }
                    this.width = value;
            }
        }
        public double Height
        {
            get
            {
                return this.height;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Height cannot be zero or negative.");
                }
                    this.height = value;
            }
        }

        public double GetSurfaceArea ()
        {
            //2lw + 2lh + 2wh
            double surfaceArea = 2 * (length * width + length * height + width * height);
            return surfaceArea;
        }

        public double GetLateralSurfaceArea()
        {
            //2lh + 2wh
            double lateralSurfaceArea = 2 * (length * height + width * height);
            return lateralSurfaceArea;
        }
        public double GetVolume()
        {
            //lwh
            double volume = length * width * height;
            return volume;
        }
    }
}
