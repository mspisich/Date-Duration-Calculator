using System;

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
            Console.ReadLine();
        }
        
        
        //Returns duration between two dates
        static public string GetDateDifference(DateTime firstDate, DateTime secondDate)
        {
            //Final values will be years, months, and/or finalDays. "daysTracker" used for counting months and years only!
            //"finalDays" set to -1 so first day is not counted.
            int years = 0, months = 0, daysTracker = 0, finalDays=-1;
            //Number of days in first and final months tallied separately.
            int firstMonthDays = 0, finalMonthDays = 0;


            //Find out which date is earlier than the other, assign to earlierDate and laterDate variables
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
            

            //Tally up number of months and years between dates, as well as days in beginning and end months.
            for (DateTime i = earlierDate; i <= laterDate; i = i.AddDays(1))
            {
                //If same month and year is given for both inputs, find number of days between dates.
                if (earlierDate.Month == laterDate.Month && earlierDate.Year == laterDate.Year)
                {
                    finalDays++;
                }
                //Find number of days left of first month, tally separately.
                else if (i.Month == earlierDate.Month && i.Year == earlierDate.Year)
                {
                    firstMonthDays++;
                }
                //Find number of days left of final month, tally separately.
                else if (i.Month == laterDate.Month && i.Year == laterDate.Year)
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

            //Calculate total number of days.
            
            //Same month and year for both inputs
            if (earlierDate.Month == laterDate.Month && earlierDate.Year == laterDate.Year)
            {
                //Return string with final result in days only.
                if (finalDays == 1)
                {
                    return "1 day";
                }
                else
                {
                    return Convert.ToString(finalDays) + " days";
                }
            }
            //Different year and month for both inputs.
            //If number of days in the later month is equal to or higher than the earlier month, add one month to total months and subtract "Day" value of first month
            //from number of days in later month to get final number of days left over.  If this brings the number of months to 12, set months to zero and add one year.
            else if (laterDate.Day >= earlierDate.Day)
            {
                finalDays = finalMonthDays - Convert.ToInt16(earlierDate.Day);
                months++;
                if (months >= 12)
                {
                    months = 0;
                    years++;
                }
            }
            //If number of days in the later month is less than the earlier month, just add days in first and final months.
            else
            {
                finalDays = firstMonthDays + finalMonthDays;
            }

            //If number of years is zero, return string with final result in months and days only. Otherwise, return in years, months, and days.
            if (years == 0)
            {
                if (finalDays == 1 && months == 1)
                {
                    return "1 month and 1 day";
                }
                else if (finalDays == 1)
                {
                    return Convert.ToString(months) + " months and 1 day";
                }
                else if (months == 1)
                {
                    return "1 month and " + Convert.ToString(finalDays) + " days";
                }
                else
                {
                    return Convert.ToString(months) + " months and " + Convert.ToString(finalDays) + " days";
                }
            }
            //Return final total of years, months, and days.
            else
            {

                if (finalDays == 1 && months == 1 && years == 1)
                {
                    return "1 year, 1 month, and 1 day";
                }
                else if (finalDays == 1 && months == 1)
                {
                    return Convert.ToString(years) + " years, 1 month, and 1 day";
                }
                else if (finalDays == 1 && years == 1)
                {
                    return "1 year, " + Convert.ToString(months) + " months, and 1 day";
                }
                else if (months == 1 && years == 1)
                {
                    return "1 year, 1 month, and " + Convert.ToString(finalDays) + " days";
                }
                else if (finalDays == 1)
                {
                    return Convert.ToString(years) + " years, " + Convert.ToString(months) + " months, and 1 day";
                }
                else if (months == 1)
                {
                    return Convert.ToString(years) + " years, 1 month, and " + Convert.ToString(finalDays) + " days";
                }
                else if (years == 1)
                {
                    return "1 year, " + Convert.ToString(months) + " months, and " + Convert.ToString(finalDays) + " days";
                }
                else
                {
                    return Convert.ToString(years) + " years, " + Convert.ToString(months) + " months, and " + Convert.ToString(finalDays) + " days";
                } 
            }
        } 
    }
}
