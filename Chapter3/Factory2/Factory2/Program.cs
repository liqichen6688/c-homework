using System;

namespace Factory2
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

    interface DrawFactory
    {
        Figure createFigure();
    }

    class TriaFactory : DrawFactory
    {
        Figure DrawFactory.createFigure()
        {
            return new Triangle();
        }

    }

    class CircleFactory : DrawFactory
    {
        Figure DrawFactory.createFigure()
        {
            return new Circle();
        }

    }

    class MainClass
    {
        public static void Main(string[] args)
        {
            DrawFactory factory;
            factory = new CircleFactory();
            Figure fig = factory.createFigure();
            fig.draw();
        }
    }

}