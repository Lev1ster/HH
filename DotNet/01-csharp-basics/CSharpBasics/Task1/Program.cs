using System;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            int sideA = new int();
            int sideB = new int();
            int area = new int();

            Console.WriteLine("Hello. This program allows you to calculate the area of a rectangle. " +
            "Enter the side 'a' and 'b'. ");
            Console.WriteLine("Remember, you can't enter a value less than or equal to zero");
            Console.WriteLine();
            Console.WriteLine("Please enter value side 'a'.");

            do
            {
                string str = Console.ReadLine();

                int.TryParse(str, out sideA);
                if (sideA <= 0)
                {
                    Console.WriteLine("Value not correct. Please enter value side 'a' again.");
                    Console.WriteLine("Remember, you can't enter a value less than or equal to zero");
                }
            }
            while (sideA <= 0);

            Console.WriteLine();
            Console.WriteLine("Please enter value side 'b'.");

            do
            {
                string str = Console.ReadLine();

                int.TryParse(str, out sideB);
                if (sideB <= 0)
                {
                    Console.WriteLine("Value not correct. Please enter value side 'b' again.");
                    Console.WriteLine("Remember, you can't enter a value less than or equal to zero");
                }
            }
            while (sideB <= 0);

            area = sideA * sideB;

            Console.WriteLine(area);
        }
    }
}
