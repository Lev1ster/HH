using System;
using System.Text.RegularExpressions;

namespace Task7
{
    class Program
    {
        static void Main(string[] args)
        {
            Regex regex = new Regex(@"(((\D[0-9]\D+)|(\b+[0-9]\D+)|(\D[0-9]\b+)|(\b+[0-9]\b+))|((\D[0-2][0-3]\D+)|(\b+[0-2][0-3]\D+)|(\D+[0-2][0-3]\b+)|(\b+[0-2][0-3]\b+))):(([0-5][0-9]\D)|([0-5][0-9]\b+))");

            Console.Write("Enter text: ");
            string str = Console.ReadLine();

            MatchCollection matches = regex.Matches(str);
            if (matches.Count > 0)
            {
                    Console.WriteLine("Время в тексте присутствует {0} раз.", matches.Count);
            }
            else
            {
                Console.WriteLine("Время в тексте не присутствует.");
            }
        }
    }
}
