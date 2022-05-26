using System;
using System.Text.RegularExpressions;

namespace Task5
{
    class Program
    {
        static void Main(string[] args)
        {
            Regex regex = new Regex(@"<.+?>");

            Console.Write("Enter HTML text: ");
            string str = Console.ReadLine();

            string answer = regex.Replace(str, "_");

            Console.WriteLine("Результат замены: " + answer);
        }
    }
}
