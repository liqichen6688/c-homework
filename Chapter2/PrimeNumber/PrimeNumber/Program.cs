using System;

namespace PrimeNumber
{
    class MainClass
    {
        static bool JudgePrime(int a)
        {
            bool isPrime = true;
            for (int i = 2; i < a; i++)
            {
                if (a % i == 0)
                {
                    isPrime = false;
                    break;
                }
            }
            return isPrime;
        }

        public static void Main(string[] args)
        {
            Console.WriteLine("Pleae input the number");
            int userInput = Convert.ToInt16(Console.ReadLine());
            for (int i = 2; i < userInput; i++)
            {
                if (userInput % i == 0 && JudgePrime(i))
                {
                    Console.WriteLine(Convert.ToString(i));
                }
            }
        }

       
    }
}
