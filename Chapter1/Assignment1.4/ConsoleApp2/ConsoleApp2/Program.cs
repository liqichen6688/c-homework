using System;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please input the first numbers:");
            double a = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Please input the second numbers:");
            double b = Convert.ToDouble(Console.ReadLine());
            double c = a * b;
            Console.WriteLine("The Product of these two number is {0:0.00}",c);
            
            
        }
    }
}