using System;

namespace GeometryLibrary
{
    public interface IShape
    {
        double CalculateArea();
    }

    public class CircleShape : IShape
    {
        private readonly double _radius;

        public CircleShape(double radius)
        {
            _radius = radius;
        }

        public double CalculateArea()
        {
            return Math.PI * _radius * _radius;
        }
    }

    public class TriangleShape : IShape
    {
        private readonly double _side1;
        private readonly double _side2;
        private readonly double _side3;

        public TriangleShape(double side1, double side2, double side3)
        {
            _side1 = side1;
            _side2 = side2;
            _side3 = side3;
        }

        public double CalculateArea()
        {
            double s = (_side1 + _side2 + _side3) / 2;
            return Math.Sqrt(s * (s - _side1) * (s - _side2) * (s - _side3));
        }

        public bool IsRightAngleTriangle()
        {
            return Math.Pow(_side1, 2) + Math.Pow(_side2, 2) == Math.Pow(_side3, 2) ||
                   Math.Pow(_side1, 2) + Math.Pow(_side3, 2) == Math.Pow(_side2, 2) ||
                   Math.Pow(_side2, 2) + Math.Pow(_side3, 2) == Math.Pow(_side1, 2);
        }
    }

    public static class ShapeFactory
    {
        public static IShape CreateShape(double[] parameters)
        {
            if (parameters.Length == 1)
            {
                return new CircleShape(parameters[0]);
            }
            else if (parameters.Length == 3)
            {
                return new TriangleShape(parameters[0], parameters[1], parameters[2]);
            }
            else
            {
                throw new ArgumentException("Invalid number of parameters.");
            }
        }
    }
}
