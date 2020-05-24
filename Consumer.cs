using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KR
{
    /// <summary>
    /// Клас для задання та читання даних про споживача
    /// </summary>
    class Consumer
    {
        string name;
        int day;
        int month;
        string city;
        int ord_day;
        int ord_month;
        int hour;
        int minutes;
        public int Day
        {
            get{return day;}
        }
        public int Month
        {
            get { return month; }
        }
        public Consumer() // Конструктор за замовчуванням
        {
            name = "Alicia Patrick";
            city = "Sumy";
            ord_day = DateTime.Now.Day; 
            ord_month = DateTime.Now.Month; 
            hour = DateTime.Now.Hour; 
            minutes = DateTime.Now.Minute;
        }
        /// <summary>
        /// Метод для введення дня народження клієнта 
        /// </summary>
        public void Bday() 
        {
            Console.WriteLine("Enter day of your birthday");
            day = int.Parse(Console.ReadLine()); 
            if (day > 31 || day < 1)
            {
                Console.WriteLine("Incorrect date");
                Bday();
            }
            else
            {
                Console.WriteLine("Enter month of your birthday");
                month = int.Parse(Console.ReadLine()); 
                if (month > 12 || month < 1)
                {
                    Console.WriteLine("Incorrect date");
                    Bday();
                }
            }

        }
        public int OrdDay
        {
            get { return ord_day; }
        }
        public int Hour
        {
            get { return hour; }
        }
        public int Minutes
        {
            get { return minutes; }
        }
        public int OrdMonth
        {
            get { return ord_month; }
        }
    }
}
