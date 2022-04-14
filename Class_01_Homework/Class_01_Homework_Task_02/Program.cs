using System;
using System.Collections.Generic;
using System.Globalization;

namespace Class_01_Homework_Task_02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //            2.Create a console application that checks if a day is a working day 🔹
            //The app should request for a user to enter a date as an input or multiple inputs(single strings formatted according to your machine settings, e.g. "04-04-2022" = DD - MM - YYYY)
            //The app should then open and see if the day is a working day
            //It should show the user a message whether the date they entered is working or not
            //Weekends are not working
            //1 January, 7 January, 20 April, 1 May, 25 May, 3 August, 8 September, 12 October, 23 October and 8 December(non - working holidays) are not working days as well
            //It should ask the user if they want to check another date
            //Yes - the app runs again
            //No - the app closes


            CheckIfTheDateIsWorkingDay();

        }

        static void CheckIfTheDateIsWorkingDay()
        {

            List<DateTime> listOfDates = new List<DateTime>();
            Console.WriteLine("Please enter one more more dates in the exact format: dd/MM/yyyy. Enter 'x' when you are done.");
            string userInput = "";

            while (userInput != "x")
            {
                try
                {
                    userInput = Console.ReadLine();
                    bool success = DateTime.TryParseExact(userInput, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime date);

                    if (userInput == "x")
                    {
                        break;
                    }
                    else if (userInput == "")
                    {
                        throw new Exception("Empty input, please try again!");
                    }
                    else if (!success)
                    {
                        throw new Exception("Invalid date input, you must enter the date in the following format: 'dd/MM/yyyy' ");
                    }
                    else
                    {
                        listOfDates.Add(date);
                    }
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(ex);
                    Console.WriteLine(ex.Message);
                    Console.WriteLine(ex.StackTrace);
                }
                finally
                {
                    Console.ResetColor();
                }

            }
            //1 January, 7 January, 20 April, 1 May, 25 May, 3 August, 8 September, 12 October, 23 October and 8 December

            foreach (DateTime date in listOfDates)
            {
                if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday)
                {
                    Console.WriteLine($"{date.ToString("d")} is {date.DayOfWeek} so it is a non-working day! Have a nice weekend!");
                }
                else if (date.Day == 1 && date.Month == 1 ||
                         date.Day == 7 && date.Month == 1 ||
                         date.Day == 20 && date.Month == 4 ||
                         date.Day == 1 && date.Month == 5 ||
                         date.Day == 25 && date.Month == 5 ||
                         date.Day == 3 && date.Month == 8 ||
                         date.Day == 8 && date.Month == 8 ||
                         date.Day == 12 && date.Month == 10 ||
                         date.Day == 23 && date.Month == 10 ||
                         date.Day == 8 && date.Month == 12)
                {
                    Console.WriteLine($"{date.ToString("d")} is a national holiday and a non-working day! Enjoy the free day!");
                }
                else
                {
                    Console.WriteLine($"{date.ToString("d")} is a working day :( ");
                }

            }

            TryAgain();

        }

        static void TryAgain()
        {
            Console.WriteLine("Do you want to try another date? (Y or N)");
            string answer = Console.ReadLine();

            //(answer.ToLower() != "y" || answer.ToLower() != "n")
            while (true)
            {
                if (answer.ToLower() == "y")
                {
                    CheckIfTheDateIsWorkingDay();
                }
                else if (answer.ToLower() == "n")
                {
                    Console.WriteLine("Thank you for using our application!");
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input, please reply with Y or N.");
                    answer = Console.ReadLine();
                }
            }

        }
    }
}
