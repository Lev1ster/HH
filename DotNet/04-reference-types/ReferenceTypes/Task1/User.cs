using System;
using System.Collections.Generic;
using System.Text;

namespace Task1
{
    public class User
    {
        public string Surname { get; private set; }
        public string Name{get; private set; }
        public string Patronymic{get; private set; }
        private DateTime dayOfBirth = new DateTime();
        public DateTime DayOfBirth 
        { 
            get
            {
                if (dayOfBirth != null)
                    return dayOfBirth;
                else
                    throw new Exception("Unable to get the value");
            }
            set
            {
                if (DateTime.Now > value)
                {
                    DayOfBirth = value;
                }
                else
                {
                    throw new Exception("Invalid value DateOfBirth");
                }
            }
        }
        public int Age 
        { 
            get
            {
                return CalculateAge(); 
            }
        }

        public User(string surname, string name, string patronymic)
        {
            Surname = surname;
            Name = name;
            Patronymic = patronymic;
        }

        public User(string surname, string name, string patronymic, DateTime DayOfBirth) : this(surname, name, patronymic)
        {
            this.DayOfBirth = DayOfBirth;
        }

        int CalculateAge()
        {
            int age;

                if (DateTime.Now.Month - DayOfBirth.Month >= 0 && DateTime.Now.Day - DayOfBirth.Day >= 0)
                    age = DateTime.Now.Year - DayOfBirth.Year;
                else
                    age = DateTime.Now.Year - DayOfBirth.Year - 1;

            return age;
        }
    }
}
