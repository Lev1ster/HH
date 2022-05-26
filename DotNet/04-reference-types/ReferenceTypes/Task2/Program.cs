using System;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            Round circle = null;
            try
            {
                ReadCircle(ref circle);
                Console.WriteLine("Area circle = {0,3:f2}", circle.AreaCircle());
                Console.WriteLine("Perimeter  =  {0,3:f2}", circle.LenghtCircle());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public static void ReadCircle(ref Round round)
        {
            int x;
            int y;
            double radius;

            Console.Write("Enter X center = ");
            if (!int.TryParse(Console.ReadLine(), out x))
            {
                throw new Exception("Invalid value X");
            }
            Console.Write("Enter Y center = ");
            if (!int.TryParse(Console.ReadLine(), out y))
            {
                throw new Exception("Invalid value Y");
            }
            Console.Write("Enter Radius center = ");
            if (!double.TryParse(Console.ReadLine(), out radius))
            {
                throw new Exception("Invalid value Radius");
            }

            round = new Round(x, y, radius);
        }
    }
}
