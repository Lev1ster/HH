using System;
using System.Globalization;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            CultureInfo esCI = new CultureInfo("en-US");
            CultureInfo ruCI = new CultureInfo("ru-RU");
            CultureInfo invCI = CultureInfo.InvariantCulture;

            Console.WriteLine("EN vs RU table:\n");
            PrintCultureInfo(esCI, ruCI);
            Console.WriteLine("RU vs invariant table:\n");
            PrintCultureInfo(esCI, invCI);
            Console.WriteLine("EN vs invariant table:\n");
            PrintCultureInfo(ruCI, invCI);
        }

        public static void PrintCultureInfo(CultureInfo CI1, CultureInfo CI2)
        {
            Console.WriteLine("Название: \t\t\t{0}   \t{1}",CI1.DisplayName,  CI2.DisplayName);
            
            Console.WriteLine("Формат отображения \nдаты и времени:  \t\t{0} \t \t{1}", CI1.DateTimeFormat.ShortDatePattern, CI2.DateTimeFormat.ShortDatePattern);
            
            Console.WriteLine("Формат отображения \nчисловых данных: \t\t{0} \t \t{1}", CI1.NumberFormat.CurrencyGroupSizes, CI2.NumberFormat.CurrencyGroupSizes);
        }
    }
}
