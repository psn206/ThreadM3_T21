using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Task
{
    internal class Program
    {
        static int[,] garden = { { 5, 1, 15, 1 },
                          {2, 8, 1, 1 },
                          {7, 6, 2, 2 } };
        static void Main(string[] args)
        {
            ThreadStart threadStart = new ThreadStart(Gardener1);
            Thread thread = new Thread(threadStart);
            thread.Start();
            Gardener2();

            for (int i = 0; i < garden.GetLength(0); i++)
            {
                for (int j = 0; j < garden.GetLength(1); j++)
                {
                    Console.Write($"{garden[i, j]} ");
                }
                Console.WriteLine();
            }

            Console.ReadKey();
        }
        static void Gardener1()
        {
            for (int i = 0; i < garden.GetLength(0); i++)
            {
                for (int j = 0; j < garden.GetLength(1); j++)
                {
                    if (garden[i, j] >= 0)
                    {
                        int delay = garden[i, j];
                        garden[i, j] = -1;
                        Thread.Sleep(delay);
                    }
                }
            }
        }
        static void Gardener2()
        {
            for (int i = garden.GetLength(1) - 1; i >= 0; i--)
            {
                for (int j = garden.GetLength(0) - 1; j >= 0; j--)
                {
                    if (garden[j, i] >= 0)
                    {
                        int delay = garden[j, i];
                        garden[j, i] = -2;
                        Thread.Sleep(delay);
                    }
                }
            }
        }
    }
}
