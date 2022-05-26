using System;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            //User stepan = new User("Stopkin", "Stepan", "Nickolaevich", "2000-04-06");
            // stepan.PrintUser();
            //Console.WriteLine();

            bool isFailed = false;
            User user = null;

            do
            {
                if (isFailed)
                {
                    Console.WriteLine("Fill your profile again: ");
                }
                else
                {
                    Console.WriteLine("Please fill profile: ");
                }
                try
                {
                    Anketa(ref user);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    isFailed = true;
                }
            }
            while (isFailed);

            Console.WriteLine("\n");
            PrintUser(user);
        }

        public static void Anketa(ref User user)
        {
            Console.Write("\tYour surname -  ");
            string surname = Console.ReadLine();
            Console.Write("\tYour name -  ");
            string name = Console.ReadLine();
            Console.Write("\tYour patronymic -  ");
            string patronymic = Console.ReadLine();
            Console.Write("\tYour date of birth-  ");
            string DoB = Console.ReadLine();

            DateTime DateOfBirth;
            if (!DateTime.TryParse(DoB, out DateOfBirth))
            {
                throw new Exception("Invalid 'Date_of_Birth' value entered");
            }
            user = new User(surname, name, patronymic, DateOfBirth);
        }

        public static void PrintUser(User user)
        {
            if (user.Age == 0)
            {
                Print3Characteristic(user);
            }
            else
            {
                Print3Characteristic(user);

                Console.WriteLine("Date of Birth: \t{0}", user.DayOfBirth.ToString("yyyy-MM-dd"));
                Console.WriteLine("Age: \t\t{0}", user.Age);
            }
        }

        private static void Print3Characteristic(User user)
        {
            Console.WriteLine("Surname: \t{0}", user.Surname);
            Console.WriteLine("Name: \t\t{0}", user.Name);
            Console.WriteLine("Patronymic: \t{0}", user.Patronymic);
        }
    }
}
