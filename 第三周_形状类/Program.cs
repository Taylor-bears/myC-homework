using System;

namespace 第三周_形状类
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


    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("创建矩形");
            Console.WriteLine("请输入矩形的长与宽");
            Console.WriteLine("长:");
            double width = double.Parse(Console.ReadLine());
            Console.WriteLine("宽:");
            double height = double.Parse(Console.ReadLine());
            Rectangle rect = new Rectangle(width, height);
            if (rect.isValid())
            {
                Console.WriteLine("该矩形合法，且面积为：" + rect.GetArea());
            }
            else
            {
                Console.WriteLine("矩形的长或宽不是正数，不合法，无法计算面积");
            }

            Console.WriteLine("创建正方形");
            Console.WriteLine("请输入正方形的边长");
            Console.WriteLine("边长:");
            double side = double.Parse(Console.ReadLine());
            Sqaure sqr = new Sqaure(side);
            if (sqr.isValid())
            {
                Console.WriteLine("该正方形合法，且面积为：" + sqr.GetArea());
            }
            else
            {
                Console.WriteLine("正方形的边长不是正数，不合法，无法计算面积");
            }
                    
            Console.WriteLine("创建三角形");
            Console.WriteLine("请输入三角形的三边长");
            Console.WriteLine("边1:");
            double side1 = double.Parse(Console.ReadLine());
            Console.WriteLine("边2:");
            double side2 = double.Parse(Console.ReadLine());
            Console.WriteLine("边3:");
            double side3 = double.Parse(Console.ReadLine());
            Triangle tri = new Triangle(side1, side2, side3);
            if (tri.isValid())
            {
                Console.WriteLine("该三角形合法，且面积为：" + tri.GetArea());
            }
            else
            {
                Console.WriteLine("三角形的边长不合法，无法计算面积");
            }
        }
    }
}