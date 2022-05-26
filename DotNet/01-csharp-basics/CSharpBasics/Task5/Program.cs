using System;

namespace Task5
{
    class Program
    {
        static void Main(string[] args)
        {
            int sum = new int();



            for(int i = 1; i<1000; i++)
            {
                if (i % 3 == 0 || i % 5 == 0)
                {
                    sum += i;
                }
            }
            Console.Write(sum);
        }
    }
}
