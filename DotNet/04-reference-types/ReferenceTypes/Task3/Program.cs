using System;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.Write("Enter said A: ");
                double saidA = CheckValue(Console.ReadLine());
                Console.Write("Enter said B: ");
                double saidB = CheckValue(Console.ReadLine());
                Console.Write("Enter said C: ");
                double saidC = CheckValue(Console.ReadLine());

                Triangle triangle = new Triangle(saidA, saidB, saidC);

                Console.WriteLine("\n");

                Console.WriteLine("Area triangle - {0,3:f1}", triangle.AreaTriangle());
                Console.WriteLine("Perimeter triangle - {0,3:f1}", triangle.Perimeter());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        static double CheckValue(string str)
        {
            double said;

            if (!double.TryParse(str, out said))
            {
                throw new Exception("Invalid value enter");
            }

            return said;
        }
    }
}
