using System;

namespace ArrayCalculate
{
    class MainClass
    {
        int Max(int[] a)
        {
            int max = a[0];
            foreach(int element in a)
            {
                if(element > max)
                {
                    max = element;
                }
            }
            return max;
        }

        int Min(int[] a)
        {
            int min = a[0];
            foreach (int element in a)
            {
                if (element > min)
                {
                    min = element;
                }
            }
            return min;

        }

        int Average(int[] a)
        {
            int sum = 0;
            foreach(int element in a)
            {
                sum += element;
            }
            return sum/a.Length;
        }

        int Sum(int[] a)
        {
            int sum = 0;
            foreach(int element in a)
            {
                sum += element;
            }
            return sum;

        }
        public static void Main(string[] args)
        {
            Console.WriteLine("The Method is Demonstrated in Code");
        }
        
}
