using System;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,,] array = new int[3,2,1];

            GenerateArray(array);
            PrintArray(array);
            ReplacePositiveElementsWithZero(array);
            PrintArray(array);
        }

        public static void GenerateArray(int[,,] array)
        {
            Random rnd = new Random();

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    for (int l = 0; l < array.GetLength(2); l++)
                    {
                        array[i, j, l] = rnd.Next(-10,10);
                    }
                }
            }
        }

        public static void PrintArray(int[,,] array)
        {
            foreach(var a in array)
            {
                Console.WriteLine(a);
            }
        }

        public static void ReplacePositiveElementsWithZero(int[,,] array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    for (int l = 0; l < array.GetLength(2); l++)
                    {
                        if (array[i, j, l] > 0)
                        {
                            array[i, j, l] = 0;
                        }
                    }
                }
            }
        }

    }
}
