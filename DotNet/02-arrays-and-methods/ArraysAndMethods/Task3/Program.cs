using System;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[10];

            GenerateArray(array);
            PrintArray(array);

            int sum = GetSumOfNonNegativeElements(array);
            Console.WriteLine(sum);
        }

        public static void GenerateArray(int[] a)
        {
            Random rnd = new Random();
            for (int i = 0; i < a.Length; i++)
            {
                a[i] = rnd.Next(-10, 10);
            }
        }

        public static void PrintArray(int[] array)
        {
            foreach (var a in array)
            {
                Console.Write(" " + a + " ");
            }
            Console.WriteLine();
        }

        public static int GetSumOfNonNegativeElements(int[] array)
        {
            int sum = 0;

            foreach (var a in array)
            {
                if (a > 0)
                {
                    sum += a;
                }
            }
            return sum;
        }
    }
}
