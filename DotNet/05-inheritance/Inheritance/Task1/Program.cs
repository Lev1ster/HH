using System;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            try {
                Employee employee = new Employee("", "Jack", "Sparrow", DateTime.Parse("20-12-2000"), "Capitan");

                PrintUser(employee);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void PrintUser(Employee employee)
        {
            if (employee.DayOfBirth == new DateTime())
            {
                Print3Characteristic(employee);
            }
            else
            {
                Print3Characteristic(employee);

                Console.WriteLine("Date of Birth: \t{0}", employee.DayOfBirth.ToString("yyyy-MM-dd"));
                Console.WriteLine("Age: \t\t{0}", employee.Age);
            }
            Console.WriteLine("Work experience:{0}", employee.WorkExp);
            Console.WriteLine("Post: \t\t{0}", employee.Post);
        }

        private static void Print3Characteristic(Employee employee)
        {
            Console.WriteLine("Surname: \t{0}", employee.Surname);
            Console.WriteLine("Name: \t\t{0}", employee.Name);
            Console.WriteLine("Patronymic: \t{0}", employee.Patronymic);
        }
    }
}
