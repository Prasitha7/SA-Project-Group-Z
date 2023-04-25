using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SA_Group_Z__21._1_
{
    public class Triangle:Shape
    {
        public Triangle(List<double> triangleParams) : base("Triangle", triangleParams)
        {
        }

        public override double ComputePerimeter()
        {
            double a = parameters[0];
            double b = parameters[1];
            double c = parameters[2];
            return a + b + c;
        }
    }
}