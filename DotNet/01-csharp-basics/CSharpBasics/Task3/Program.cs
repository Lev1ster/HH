using System;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = new int();


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

            for (int i = 0; i < N; i++)
            {
                for (int l = N - i - 1; l > 0; l--)
                {
                    Console.Write(" ");
                }

                for (int j = 1; j <= i * 2 + 1; j++)
                {
                    Console.Write("*");
                }
                if (i == N - 1) { break;}
                Console.WriteLine();
            }
        }
    }
}
