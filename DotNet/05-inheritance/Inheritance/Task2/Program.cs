using System;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
			try
			{
				Ring ring = new Ring(0, 0, 5, 8);
				PrintCharacteristic(ring);
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
        public static void PrintCircle(Round round)
        {
            Console.WriteLine("X: \t\t {0}", round.CenterX);
            Console.WriteLine("Y: \t\t {0}", round.CenterY);
            Console.WriteLine("Radius: \t {0}", round.Radius);
        }

        public static void PrintCharacteristic(Ring ring)
        {
            PrintCircle(ring);
            Console.WriteLine("AreaRing: \t{0,3:f1}", ring.Area());
            Console.WriteLine("Perimeter: \t{0,3:f1}", ring.Lenght());
        }
    }
}
