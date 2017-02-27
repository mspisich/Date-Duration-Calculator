using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DateDurationCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please input date #1: \n");
            Console.WriteLine("Year: ");
            int year1 = Convert.ToInt16(Console.ReadLine());
            Console.WriteLine("Month (1-12): ");
            int month1 = Convert.ToInt16(Console.ReadLine());
            Console.WriteLine("Day: ");
            int day1 = Convert.ToInt16(Console.ReadLine());

            Console.WriteLine("Please input date #2: \n");
            Console.WriteLine("Year: ");
            int year2 = Convert.ToInt16(Console.ReadLine());
            Console.WriteLine("Month (1-12): ");
            int month2 = Convert.ToInt16(Console.ReadLine());
            Console.WriteLine("Day: ");
            int day2 = Convert.ToInt16(Console.ReadLine());

            int totalYears, totalMonths, totalDays = 0;

            int[] daysInMonth = new int[12] { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
            int[] daysInMonthLeap = new int[12] { 31, 29, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };

            if (year2 - year1 == 0)
            {

            }

        }
    }
}
