using System;
using System.Collections.Generic;

namespace PrimeNumber2
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            List<int> numberList = new List<int>();
            for (int i = 2; i < 101; i++)
            {
                numberList.Add(i);
            }
            for(int i = 2; i < 51; i++)
            {
                int j = 2;
                while(j < 101 && numberList.Contains(j * i))
                {
                    numberList.Remove(i * j);
                    j++;
                }
            }
            foreach(int element in numberList)
            {
                Console.WriteLine(Convert.ToString(element));
            }
        }
    }
}
