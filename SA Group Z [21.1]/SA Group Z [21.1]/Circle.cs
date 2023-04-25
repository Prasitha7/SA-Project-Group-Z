using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SA_Group_Z__21._1_
{
    public class Circle:Shape
    {
        public Circle(List<double> circleParams) : base("Circle", circleParams)
        {
        }

        public override double ComputePerimeter()
        {
            double radius = parameters[0];
            return 2 * Math.PI * radius;
        }
    }
}