using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;

namespace ParallelCalcThread
{
    internal class Program
    {        
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            
            Console.WriteLine("\n=========== Меню ================\n");
            Console.Write("Вводим число \"а\": "); ;
            string inputFirst = Console.ReadLine();

            Console.Write("Вводим число \"b\": "); ;
            string inputSecond = Console.ReadLine();


            if (!int.TryParse(inputFirst, out int a) || !int.TryParse(inputSecond, out int b))
            {
                Console.WriteLine("ERROR: нужно ввести целые числа");
                return;
            }

            if (a > b)
            {
                Console.WriteLine("Неверный диапазон (а<b), меняем....");
                int temp = a; a = b; b = temp;                                              
            }          

            Console.WriteLine();
            Console.WriteLine($"Диапазон чисел: a={a}, b={b}");
            Run(a, b);

            // ------
            Console.WriteLine("\n\n=== Сравнение последовательного и паралледного ===\n");
            ComparisonRun.Compare(a, b);

            // ------
            Console.WriteLine("\n\n=== Демонстрация фоновых потоков ===\n");
            BackgroundDemo.Demonstrate();

            Console.WriteLine("\nПрограма завершена");      }
        private static void Run(int a, int b)
        {
            var result = new List<int>();
            var stopwatch = Stopwatch.StartNew();

            Thread primesThread = new Thread(() => ComputeTasks.FindPrimes(a, b))
            {
                Name = "Primes"                
            };

            Console.WriteLine("Работа главного потока...\n");
            Thread fibonacciThread = new Thread(() => ComputeTasks.FindFibonacci(b))
            {
                Name = "Fibonacci"
            };

            Thread digitSumThread = new Thread(() => ComputeTasks.FindMaxDigitSum(a, b))
            {
                Name = "DigitSum"
            };
            primesThread.Start();
            fibonacciThread.Start();
            digitSumThread.Start();

            primesThread.Join();
            fibonacciThread.Join();
            digitSumThread.Join();

            stopwatch.Stop();
            Console.WriteLine($"Все потоки завершены. Время {stopwatch.ElapsedMilliseconds} ms");
        }
    }
}
