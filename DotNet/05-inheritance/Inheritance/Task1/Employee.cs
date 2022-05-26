using System;
using System.Collections.Generic;
using System.Text;

namespace Task1
{
    public class Employee : User
    {
        public int WorkExp 
        {
            get
            {
                return CalculateWorkExp();
            }
        }
        private DateTime startDate = new DateTime();
        public DateTime StartDate
        {
            get
            {
                if (startDate != null)
                    return startDate;
                else
                    throw new Exception("Unable to get the value");
            }
            set
            {
                if (DateTime.Now > value && DayOfBirth < value)
                {
                    startDate = value;
                }
                else
                {
                    throw new Exception("Invalid value DateOfBirth");
                }
            }
        }
        public string Post { get; private set; }


        public Employee(string surname, string name, string patronymic, DateTime startDate, string post) : base(
            surname, name, patronymic)
        {
            StartDate = startDate;
            this.Post = post;
        }

        public Employee(string surname, string name, string patronymic, DateTime DayOfBirth, DateTime startDate, string post) : base(
            surname, name, patronymic, DayOfBirth)
        {
            this.Post = post;

        }

        int CalculateWorkExp()
        {
            int age;

            if (DateTime.Now.Month - StartDate.Month >= 0 && DateTime.Now.Day - StartDate.Day >= 0)
                age = DateTime.Now.Year - StartDate.Year;
            else
                age = DateTime.Now.Year - StartDate.Year - 1;

            return age;
        }
    }
}
