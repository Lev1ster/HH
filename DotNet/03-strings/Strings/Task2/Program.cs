using System;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] string1;
            char[] string2;
            string answer = "";

            Console.Write("Enter any string 1: ");
            string str1 = Console.ReadLine();
            Console.Write("Enter any string 2: ");
            string str2 = Console.ReadLine();

            string1 = str1.ToCharArray();
            string2 = str2.ToCharArray();

            for (int i = 0; i < str1.Length; i++)
            {
                answer += string1[i];
                for (int j = 0; j < str2.Length; j++)
                {
                    if (string2[j] == string1[i] && Char.IsLetter(string1[i]))
                    {
                        answer += string1[i];
                        break;
                    }
                }
            }

            Console.WriteLine(answer);
        }
    }
}
