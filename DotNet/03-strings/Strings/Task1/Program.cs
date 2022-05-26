using System;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            double count = 0;
            double sum = 0;
            bool isLetter = false;
            double answer;

            Console.WriteLine("Enter any string: ");
            string str = Console.ReadLine();

            char[] symbols = str.ToCharArray();

            for (int i = 0; i < symbols.Length; i++)
            {
                if (Char.IsLetter(symbols[i]))
                {
                    sum++;
                    isLetter = true;
                }
                else
                {
                    if (isLetter)
                    {
                        isLetter = false;
                        count++;
                    }
                }
            }

            if (isLetter)
            {
                count++;
            }

            Console.WriteLine();
            answer = sum / count;

            Console.WriteLine(answer);
        }
    }
}
