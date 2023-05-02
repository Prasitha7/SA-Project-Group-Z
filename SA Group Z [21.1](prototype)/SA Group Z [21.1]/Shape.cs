using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SA_Group_Z__21._1_
{
    public class Shape
    {
        protected string type;
        protected List<double> parameters;

        public Shape(string shapeType, List<double> shapeParams)
        {
            type = shapeType;
            parameters = shapeParams;
        }

        public abstract double ComputePerimeter();

    }
}