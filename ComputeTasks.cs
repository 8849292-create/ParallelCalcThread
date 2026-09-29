using System;
using System.Collections.Generic;
using System.Threading;

namespace ParallelCalcThread
{
    public class ComputeTasks
    { 
        public static void FindPrimes(int a,int b)
        {
            string threadName = Thread.CurrentThread.Name;
            Console.WriteLine($"{threadName} Начало работы, диапазон: {a} и  {b}");

            List <int> thread = new List<int>();
            for(int n = Math.Max(2, a); n <= b; n++)
            {
                if(IsPrime(n))
                    thread.Add(n);                
            }
            Console.WriteLine($"[{threadName}] Простые числа");

            foreach(int n in thread )
            {
                Console.Write($"{n}, ");
            }
            Console.WriteLine();
            Console.WriteLine($"[{threadName}] Завершение рботы");
            Console.WriteLine("******************************");
        }
        public static void FindFibonacci(int b)
        {
            string threadName = Thread.CurrentThread.Name;
            Console.WriteLine($"\n{threadName} Начало работы, диапазон до: {b}");

            List<int> fibs = new List<int>{0, 1 };
            while (true)
            {
                int next = fibs[fibs.Count - 1] + fibs[fibs.Count - 2];
                                
                if (next < 0 || next > b)
                {
                    break;
                }

                fibs.Add(next);                
            }                        
            if (b == 0)
            {
                fibs = new List<int> { 0 };
            }

            Console.WriteLine($"[{threadName}] Числа Фибоначчм: ");

            foreach (int fb in fibs)
            {
                Console.Write($"{fb}, ");
            }
            Console.WriteLine();
            Console.WriteLine($"[{threadName}] Завершение рботы");
            Console.WriteLine("----------------------------\n");
        }
        public static void FindMaxDigitSum(int a, int b)
        {
            string threadName = Thread.CurrentThread.Name;
            Console.WriteLine($"[{threadName}] Начало работы, диапазон: [{a} до {b}]");

            int maxSum = -1;
            int numberMaxSum = a;

            for (int n = a; n <= b; n++)
            {
                int sum = DigitSum(Math.Abs(n));

                if (sum > maxSum)
                {
                    maxSum = sum;
                    numberMaxSum = n;
                }                
            }
            Console.WriteLine($"[{threadName}] Завершено " +
                              $"Mакс. суммa цифр: {numberMaxSum} (сумма = {maxSum})");
            Console.WriteLine("===================================");
        }

        private static bool IsPrime(int n)
        {
            if (n < 2) return false;
            if (n == 2) return true;
            if (n % 2 == 0) return false;

            int limit = (int)Math.Sqrt(n);
            for (int i = 3; i <= limit; i += 2)
            {
                if (n % i == 0) return false;
            }
            return true;
        }

        private static int DigitSum(int n)
        {
            int sum = 0;
            while (n > 0)
            {
                sum += n % 10;
                n /= 10;
            }
            return sum;
        }
    }
}
