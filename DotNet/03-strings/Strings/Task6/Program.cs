using System;
using System.Globalization;

namespace Task6
{
    class Program
    {
        static void Main(string[] args)
        {
            double answer;
            bool isScine = false;
            CultureInfo enCI = new CultureInfo("en-US");

            Console.Write("Введите число: ");
            string str = Console.ReadLine();

            if (double.TryParse(str, System.Globalization.NumberStyles.Any, enCI, out answer))
            {
                char[] c = str.ToCharArray();

                foreach (var value in c)
                {
                    if (Char.IsLetter(value))
                    {
                        isScine = true;
                    }
                }

                if (isScine)
                {
                    Console.WriteLine("Это число в научной нотации");
                }
                else
                {
                    Console.WriteLine("Это число в обычной нотации");
                }
            }
            else
            {
                Console.WriteLine("Это не число");
            }
        }
    }
}
