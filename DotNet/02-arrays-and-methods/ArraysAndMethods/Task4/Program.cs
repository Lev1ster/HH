using System;

namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] array = new int[3,3];

            GenerateArray(array);
            PrintArray(array);

            int sum = GetSumOfElementsOnEvenPositions(array);
            Console.WriteLine(sum);
        }

        public static void PrintArray(int[,] a)
        {
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < a.GetLength(1); j++)
                {
                    Console.Write(" " + a[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        public static void GenerateArray(int[,] a)
        {
            Random rnd = new Random();
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < a.GetLength(1); j++)
                {
                    a[i, j] = rnd.Next(10);
                }
            }
        }

        public static int GetSumOfElementsOnEvenPositions(int[,] a)
        {
            int sum = 0;

            for (int i = 0; i < a.GetLength(0); i++)
            {
                if (i % 2 == 0)
                {
                    for (int j = 0; j < a.GetLength(1); j += 2)
                    {
                        sum += a[i, j];
                    }
                }
                else
                {
                    for (int j = 1; j < a.GetLength(1); j += 2)
                    {
                        sum += a[i, j];
                    }
                }
            }

            return sum;
        }
    }
}
