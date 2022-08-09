using System;
using System.Diagnostics;
using System.Threading;

namespace DZ_3m_19l
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Рекурсия");
            Time(5, RecursionFibonacci);
            Time(10, RecursionFibonacci);
            Time(20, RecursionFibonacci);
            Console.WriteLine("Цикл");
            Time(5,IterationFibonacci);
            Time(10, IterationFibonacci);
            Time(20, IterationFibonacci);

        }

        //Методы рекурсия и итерация
        static int RecursionFibonacci(int n)
        {
            if (n == 0 || n == 1) return n;

            return RecursionFibonacci(n - 1) + RecursionFibonacci(n - 2);
        }

        static int IterationFibonacci(int n)
        {
            int result = 0;
            int b = 1;
            int tmp;

            for (int i = 0; i < n; i++)
            {
                tmp = result;
                result = b;
                b += tmp;
            }

            return result;
        }

        //Метод для учёта времени

        static void Time(int n, FibonacciDel fibonacciDel)
        {

            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            Console.WriteLine(fibonacciDel(n));
            Thread.Sleep(1000);
            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
            ts.Hours, ts.Minutes, ts.Seconds,
            ts.Milliseconds / 10);
            Console.WriteLine("RunTime " + elapsedTime);

        }

        delegate int FibonacciDel(int n);

    }
}
