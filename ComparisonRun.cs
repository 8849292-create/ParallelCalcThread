using System;
using System.Diagnostics;
using System.Threading;

namespace ParallelCalcThread
{
   public static class ComparisonRun
    {
        public static void Compare(int a, int b)
        {
            var seqSw = Stopwatch.StartNew();
            ComputeTasks.FindPrimes(a, b);
            ComputeTasks.FindFibonacci(b);
            ComputeTasks.FindMaxDigitSum(a, b);

            seqSw.Stop();

            //Parallel
            var parSw = Stopwatch.StartNew();
            var t1 = new Thread(() => ComputeTasks.FindPrimes(a, b)) { Name = "Primes" };
            var t2 = new Thread(() => ComputeTasks.FindFibonacci(b)) { Name = "Fibonacci" };
            var t3 = new Thread(() => ComputeTasks.FindMaxDigitSum(a, b)) { Name = "DigitSum" };

            t1.Start();t2.Start();t3.Start();
            t1.Join();t2.Join();t3.Join();  

            parSw.Stop();

            Console.WriteLine($"Последовательное: {seqSw.ElapsedMilliseconds} ms");
            Console.WriteLine($"Параллельное: {parSw.ElapsedMilliseconds} ms");
            Console.WriteLine($"Разница: {seqSw.ElapsedMilliseconds - parSw.ElapsedMilliseconds} ms");
        }
    }
}
