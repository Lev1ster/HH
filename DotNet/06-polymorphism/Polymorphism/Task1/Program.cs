using System;
using System.Collections.Generic;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isEnd = false;
            List<Figure> figures = new List<Figure>();
            IPrint print = new ConsolePrinter();

            do
            {
                Console.WriteLine("Выберете какую фигуру вы хотите начертить: ");
                Console.WriteLine("Треугольник: \t1");
                Console.WriteLine("Прямоугольник: \t2");
                Console.WriteLine("Круг: \t\t3");
                Console.WriteLine("Линия: \t\t4");
                string number = Console.ReadLine();
                switch (number)
                {
                    case "1":
                        {
                            Point2D Dot1;
                            Point2D Dot2;
                            Point2D Dot3;
                            Console.Write("Введите координату X точки 1: ");
                            Dot1.X = Convertt(Console.ReadLine());

                            Console.Write("Введите координату Y точки 1: ");
                            Dot1.Y = Convertt(Console.ReadLine());

                            Console.Write("Введите координату X точки 2: ");
                            Dot2.X = Convertt(Console.ReadLine());

                            Console.Write("Введите координату Y точки 2: ");
                            Dot2.Y = Convertt(Console.ReadLine());

                            Console.Write("Введите координату X точки 3: ");
                            Dot3.X = Convertt(Console.ReadLine());

                            Console.Write("Введите координату Y точки 3: ");
                            Dot3.Y = Convertt(Console.ReadLine());

                            Triangle triangle = new Triangle(Dot1, Dot2, Dot3);

                            figures.Add(triangle);
                        }
                        break;

                    case "2":
                        {
                            Point2D Dot1;
                            Point2D Dot2;
                            Console.Write("Введите координату X левой верхней точки: ");
                            Dot1.X = Convertt(Console.ReadLine());

                            Console.Write("Введите координату Y левой верхней точки: ");
                            Dot1.Y = Convertt(Console.ReadLine());

                            Console.Write("Введите координату X правой нижней точки: ");
                            Dot2.X = Convertt(Console.ReadLine());

                            Console.Write("Введите координату Y правой нижней точки: ");
                            Dot2.Y = Convertt(Console.ReadLine());

                            Rectangle rectangle = new Rectangle(Dot1, Dot2);

                            figures.Add(rectangle);
                        }
                        break;

                    case "3":
                        {
                            Point2D Dot1;
                            int radius;
                            Console.Write("Введите координату X центральной точки: ");
                            Dot1.X = Convertt(Console.ReadLine());

                            Console.Write("Введите координату Y центральной точки: ");
                            Dot1.Y = Convertt(Console.ReadLine());

                            Console.Write("Радиус окружности: ");
                            radius = Convertt(Console.ReadLine());

                            Circle circle = new Circle(Dot1, radius);

                            figures.Add(circle);
                        }
                        break;

                    case "4":
                        {
                            Point2D Dot1;
                            Point2D Dot2;

                            Console.Write("Введите координату X точки 1: ");
                            Dot1.X = Convertt(Console.ReadLine());

                            Console.Write("Введите координату Y точки 1: ");
                            Dot1.Y = Convertt(Console.ReadLine());

                            Console.Write("Введите координату X точки 2: ");
                            Dot2.X = Convertt(Console.ReadLine());

                            Console.Write("Введите координату Y точки 2: ");
                            Dot2.Y = Convertt(Console.ReadLine());

                            Line line = new Line(Dot1, Dot2);

                            figures.Add(line);
                        }
                        break;

                    default:
                        throw new Exception("Invalid value");
                }
                Console.WriteLine("\n Собираетесь ли вы создать еще 1 фигуру? \n");
                Console.WriteLine("Введите Y/N для продолжения...");
                var key = Console.ReadKey();
                do
                {

                    if (key.Key == ConsoleKey.Y)
                    {
                        isEnd = false;
                    }
                    else if (key.Key == ConsoleKey.N)
                    {
                        isEnd = true;
                    }
                    else
                    {
                        Console.WriteLine("Введите Y/N для продолжения...");
                        key = Console.ReadKey();
                    }
                }
                while (key.Key != ConsoleKey.Y && key.Key != ConsoleKey.N);
                Console.WriteLine("\n");
            }
            while (!isEnd);

            foreach (var figur in figures)
            {
                figur.Draw(print);
                Console.WriteLine("\n");
            }
        }

        public static int Convertt(string str)
        {
            if (!int.TryParse(str, out int x))
            {
                throw new Exception("Invalid value");
            }
            return x;
        }
    }
}
