using System;

namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            MyString a = new MyString("op top kop top kop top kop op");
            MyString b = new MyString("op to");
            a -= b;
            int y = 0;
            Console.WriteLine(a);
        }
    }
}
