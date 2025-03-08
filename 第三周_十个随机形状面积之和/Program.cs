using System;
using System.Collections.Generic;

namespace 第三周_十个随机形状面积之和
{
    abstract class Shape//抽象类
    {
        public abstract double GetArea();//面积
        public abstract bool isValid();//形状是否合法
    }

    class Rectangle : Shape//矩形
    {
        public double Width { get; set; }
        public double Height { get; set; }
        public Rectangle(double width, double height)
        {
            Width = width;
            Height = height;
        }
        public override double GetArea()
        {
            return Width * Height;
        }
        public override bool isValid()
        {
            return Width > 0 && Height > 0;
        }
    }

    class Sqaure : Shape//正方形
    {
        public double Width { get; set; }
        public Sqaure(double width)
        {
            Width = width;
        }
        public override double GetArea()
        {
            return Width * Width;
        }
        public override bool isValid()
        {
            return Width > 0;
        }
    }

    class Triangle : Shape//三角形
    {
        public double sideFirst { get; set; }
        public double sideSecond { get; set; }
        public double sideThird { get; set; }
        public Triangle(double sideFirst, double sideSecond, double sideThird)
        {
            this.sideFirst = sideFirst;
            this.sideSecond = sideSecond;
            this.sideThird = sideThird;
        }
        public override double GetArea()
        {
            //这里使用海伦公式
            double s = (sideFirst + sideSecond + sideThird) / 2;
            return Math.Sqrt(s * (s - sideFirst) * (s - sideSecond) * (s - sideThird));
        }
        public override bool isValid()
        {
            //三角形还要检验两边之和大于第三边
            return sideFirst > 0 && sideSecond > 0 && sideThird > 0 && sideFirst + sideSecond > sideThird && sideFirst + sideThird > sideSecond && sideSecond + sideThird > sideFirst;
        }
    }

    class Circle : Shape//圆形
    {
        public double Radius { get; set; }
        public Circle(double radius)
        {
            Radius = radius;
        }
        public override double GetArea()
        {
            return Math.PI * Radius * Radius;
        }
        public override bool isValid()
        {
            return Radius > 0;
        }
    }

    class Factory
    {
        private static Random random = new Random();
        public static Shape CreateRandomShape()
        {
            int type = random.Next(1, 5);
            switch (type)
            {
                case 1:
                    return new Rectangle(random.Next(1, 10), random.Next(1, 10));
                case 2:
                    return new Sqaure(random.Next(1, 10));
                case 3:
                    return new Triangle(random.Next(1, 10), random.Next(1, 10), random.Next(1, 10));
                case 4:
                    return new Circle(random.Next(1, 10));
                default:
                    return null;
            }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            List<Shape> shapes = new List<Shape>();
            for (int i = 0; i < 10; i++)
            {
                Shape shape = Factory.CreateRandomShape();
                while(!shape.isValid())//如果不合法就一直生成
                {
                    shape = Factory.CreateRandomShape();
                }
                shapes.Add(shape);
            }
            double sum = 0;
            int num = 0;
            int t = 1;
            foreach (Shape shape in shapes)
            {
                if (!shape.isValid())
                {
                    //前面做了优化，使得一定生成合法的形状
                    Console.WriteLine($"第{t+1}个形状不合法，跳过");
                    t++;
                    continue;
                }
                if (shape.isValid())
                {
                    Console.WriteLine($"第{t}个形状的面积为：{shape.GetArea()}");
                    t++;
                    sum += shape.GetArea();
                    num++;
                }
            }
            Console.WriteLine($"10个图形中共有{num}个形状合法，这些形状的面积这和为: " + sum);
            Console.ReadKey();
        }
    }
}