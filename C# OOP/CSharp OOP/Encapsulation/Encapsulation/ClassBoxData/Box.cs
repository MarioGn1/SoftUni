using System;
using System.Collections.Generic;
using System.Text;

namespace ClassBoxData
{
    class Box
    {
        private double length;
        private double width;
        private double height;

        public Box(double length, double width, double height)
        {
            this.Length = length;
            this.Width = width;
            this.Height = height;
        }                

        public string SurfaceArea()
        {
            double surfaceArea = 2 * length * width + 2 * width * height + 2 * height * length;
            return $"Surface Area - {surfaceArea:F2}";
        }

        public string LateralSurface()
        {
            double lateralSurface = 2 * width * height + 2 * height * length;
            return $"Lateral Surface Area - {lateralSurface:F2}";
        }

        public string Volume()
        {
            double volume = width * height * length;
            return $"Volume - {volume:F2}";
        }

        public double Length
        {
            get { return length; }
            private set
            {
                if (value > 0)
                {
                    length = value;
                }
                else
                {
                    throw new ArgumentException("Length cannot be zero or negative.");
                }
            }
        }        

        public double Width
        {
            get { return width; }
            private set 
            {
                if (value > 0)
                {
                    width = value;
                }
                else
                {
                    throw new ArgumentException("Width cannot be zero or negative.");
                }
            }
        }        

        public double Height
        {
            get { return height; }
            private set 
            {
                if (value > 0)
                {
                    height = value;
                }
                else
                {
                    throw new ArgumentException("Height cannot be zero or negative.");
                }
            }
        }               
    }
}
