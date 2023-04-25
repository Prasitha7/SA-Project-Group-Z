using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SA_Group_Z__21._1_
{
    public class ShapesService
    {
        private List<string> supportedShapes;

        public ShapesService()
        {
            supportedShapes = new List<string> { "Circle", "Triangle", "Rectangle" };
        }

        public List<string> GetSupported()
        {
            return supportedShapes;
        }

        public List<double> GetParams(string shapeType)
        {
            if (shapeType == "Circle")
            {
                return new List<double> { 1.0 };
            }
            else if (shapeType == "Triangle")
            {
                return new List<double> { 3.0, 4.0, 5.0 };
            }
            else if (shapeType == "Rectangle")
            {
                return new List<double> { 2.0, 3.0 };
            }
            else
            {
                return null;
            }
        }
    }
}