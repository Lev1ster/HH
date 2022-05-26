using System;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = new int();

            Console.WriteLine("This program allows you to output a sequence of '*' based on the value of N");
            Console.WriteLine("Remember, you can't enter a value less than or equal to zero. " +
                "Also, you can't enter non-numeric value.");

            do
            {
                string str = Console.ReadLine();

                int.TryParse(str, out N);
                if (N <= 0)
                {
                    Console.WriteLine("Value not correct. Please enter value side 'a' again.");
                    Console.WriteLine("Remember, you can't enter a value less than or equal to zero. " +
                        "Also, you can't enter non-numeric value.");
                }
            }
            while (N <= 0);

            for (int i = 1; i <= N; i++)
            {
                for (int j = 1; j <= i; j++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }
        }
    }
}
