using System;
using System.Collections.Generic;
using System.Text;

namespace Task1
{
    public interface IPrint
    {
        void Print(string str);
    }

    public class ConsolePrinter : IPrint
    {
        public void Print(string str)
        {
            Console.WriteLine(str);
        }
    }
}
