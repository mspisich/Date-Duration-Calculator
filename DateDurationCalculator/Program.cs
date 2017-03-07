﻿using System;

namespace DateDurationCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            //Get dates from user
            Console.WriteLine("Please input date #1 (e.g. 5/11/1991):");
            DateTime date1 = Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine("Please input date #2:");
            DateTime date2 = Convert.ToDateTime(Console.ReadLine());

            //Call GetDateDifference method, display final result
            Console.WriteLine("The duration between " + date1.ToString("MM/dd/yyyy") + " and " + date2.ToString("MM/dd/yyyy") + " is " + GetDateDifference(date1, date2) + ".");
        }
        

        //Returns duration between two dates
        static public string GetDateDifference(DateTime firstDate, DateTime secondDate)
        {
            //Final values will be years, months, and finalDays. "daysTracker" used for counting months and years only!
            int years = 0, months = 0, daysTracker = 0, finalDays=0;
            //Number of days in first and final months added separately. "firstMonthDays" set to -1 so first day is not counted.
            int firstMonthDays = -1, finalMonthDays = 0;


            //Find out which date is earlier than the other
            DateTime earlierDate;
            DateTime laterDate;

            if (firstDate > secondDate)
            {
                earlierDate = secondDate;
                laterDate = firstDate;
            }
            else
            {
                earlierDate = firstDate;
                laterDate = secondDate;
            }
            

            //Check which date is earlier than the other
            for (DateTime i = earlierDate; i <= laterDate; i = i.AddDays(1))
            {
                //Find number of days left of first month, add separately
                if (i.Month == firstDate.Month && i.Year == firstDate.Year)
                {
                    firstMonthDays++;
                }
                //Find number of days left of final month, add separately
                else if (i.Month == secondDate.Month && i.Year == secondDate.Year)
                {
                    finalMonthDays++;
                }
                //Find number of years and months between the first and final months.    
                else
                {
                    daysTracker++;
                    if (daysTracker >= DateTime.DaysInMonth(i.Year, i.Month))
                    {
                        daysTracker = 0;
                        months++;
                    }
                    if (months >= 12)
                    {
                        months = 0;
                        years++;
                    }
                }    
            }

            //Calculate total number of days after years and months are calculated.
            //If number of days in the final month is higher than the first month, add one month to total months and subtract "Day" value of first month
            //from number of days in final month to get final number of days left over.  Otherwise, just add days in first and final months.
            if (secondDate.Day >= firstDate.Day)
            {
                finalDays = finalMonthDays - Convert.ToInt16(firstDate.Day);
                months++;
            }
            else
            {
                finalDays = firstMonthDays + finalMonthDays;
            }

            //return string with final results in years, months, and days.
            return Convert.ToString(years) + " years, " + Convert.ToString(months) + " months, and " + Convert.ToString(finalDays) + " days";
        }
    }
}
