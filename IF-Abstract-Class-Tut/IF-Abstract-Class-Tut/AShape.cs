using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IF_Abstract_Class_Tut
{
    abstract class AShape
    {
        public abstract double GetArea();
        public abstract double GetPerimeter();
    }

    public interface IShape
    {
        double GetArea();
        double GetPerimeter();
    }

    public class Square : IShape
    {
        int _sideLength;

        public Square(int sideLength)
        {
            this._sideLength = sideLength;
        }

        public double GetArea()
        {
            return _sideLength * _sideLength;
        }

        public double GetPerimeter()
        {
            return 4 * _sideLength;
        }
    }

    public class Circle : IShape
    {
        int _radius;

        public Circle(int radius)
        {
            this._radius = radius;
        }

        public double GetArea()
        {
            return Math.PI * _radius * _radius;
        }

        public double GetPerimeter()
        {
            return 2 * _radius * Math.PI;
        }
    }
    public abstract class AQuadrilateral : IShape
    {
        public int Side1 { get; private set; }
        public int Side2 { get; private set; }
        public int Side3 { get; private set; }
        public int Side4 { get; private set; }

        public AQuadrilateral(int side1, int side2, int side3, int side4)
        {
            Side1 = side1;
            Side2 = side2;
            Side3 = side3;
            Side4 = side4;
        }

        public abstract double GetArea();

        public double GetPerimeter()
        {
            return Side1 + Side2 + Side3 + Side4;
        }
    }

    public class Rectangle : AQuadrilateral
    {
        public int Width { get; private set; }
        public int Height { get; private set; }

        public Rectangle(int width, int height)
            : base(side1: width, side2: height, side3: width, side4: height)
        {
        }

        public override double GetArea()
        {
            return Width * Height;
        }
    }
}
