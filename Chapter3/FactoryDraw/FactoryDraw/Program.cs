using System;

namespace FactoryDraw
{

    public interface Figure
    {
        void draw();
        void erase();
    }

    class Circle : Figure
    {
        void Figure.draw()
        {
            Console.WriteLine("画圆形");
        }

        void Figure.erase()
        {
            Console.WriteLine("擦圆形");
        }
    }

    class Triangle : Figure
    {
        void Figure.draw()
        {
            Console.WriteLine("画三角形");
        }

        void Figure.erase()
        {
            Console.WriteLine("擦三角形形");
        }
    }

    class DrawFactory
    {
        public static Figure GetFigure(String name)
        {
            Figure figure = null;
            if(name == "tri")
            {
                figure = new Triangle();
                Console.WriteLine("初始化三角形");
            }
            else if (name == "cir")
            {
                figure = new Circle();
                Console.WriteLine("初始圆形");
            }
            return figure;
        }

    }

    class MainClass
    {
        public static void Main(string[] args)
        {
            Figure figure;
            figure = DrawFactory.GetFigure("tri");
            figure.draw();
        }
    }

}
