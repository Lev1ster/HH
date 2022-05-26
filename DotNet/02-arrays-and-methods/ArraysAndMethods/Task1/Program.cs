using System;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[10];
            int maxValue;
            int minValue;
            int[] arrayChange = new int[10];
            
            array = GenerateArray();
            arrayChange = SortAndGetMinAndMaxValues(array, out minValue, out maxValue);
            PrintArray(arrayChange);
        }

        public static int[] GenerateArray()
        {
            Random rnd = new Random();
            int[] array = new int[10];

            for (int i = 0; i < 10; i++)
            {
                array[i] = rnd.Next(9);
            }
            return array;
        }

        public static int[] SortAndGetMinAndMaxValues(int[] arr, out int min, out int max)
        {
            int[] array = arr;
            int step = (int)(arr.Length / 2);

            while (step > 0)
            {
                int i = 0;

                while (i < array.Length - step)
                {
                    int j = i;
                    while (j >= 0 && array[j] > array[j+step])
                    {
                        int value = array[j];
                        arr[j] = array[j + step];
                        arr[j + step] = value;
                        j--;
                    }
                    i++;
                }
                step = (int)(step / 2);
            }

            min = array[0];
            max = array[array.Length - 1];
            return array; 
        }

        public static void PrintArray(int[] array)
        {
            foreach (var a in array)
            {
                Console.WriteLine(a);
            }
        }
    }
}
