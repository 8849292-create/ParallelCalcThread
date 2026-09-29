using System;
using System.Threading;

namespace ParallelCalcThread{
    public static class BackgroundDemo
    {
        public static void Demonstrate()
        {
            Console.WriteLine($"--- Фоновый поток (IsBackground = true) ---");
            var bgThraed = new Thread(() => {
                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine($" (Background) шаг {i}");
                    Thread.Sleep(200);
                }
                Console.WriteLine(" (Background) Завершено");
            })
            {
                Name = "BackgroundWorker",
                IsBackground = true
            };

            Console.WriteLine($"--- Основной поток (Foreground) ---");
            var frThraed = new Thread(() => {
                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine($" (Foreground) шаг {i}");
                    Thread.Sleep(200);
                }
                Console.WriteLine(" (Foreground) Завершено");
            })
            {
                Name = "ForegroundWorker",
                IsBackground = false
            };

            bgThraed.Start();
            frThraed.Start();

            Console.WriteLine(" Фоновый поток (Background) завершает работу");
            Console.WriteLine(" Основной поток (Foreground) Завершено");
        }
    }
}
