using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SA_Group_Z__21._1_
{
    public class Rectangle:Shape
    {
        public Rectangle(List<double> rectangleParams) : base("Rectangle", rectangleParams)
        {
        }

        public override double ComputePerimeter()
        {
            double width = parameters[0];
            double height = parameters[1];
            return 2 * (width + height);
        }
    }
}