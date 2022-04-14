using System;
using System.Collections.Generic;

namespace Class_01_Homework
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //            1.Create a console application that detect count of provided names in a provided text 🔹
            //The application should ask for names to be entered until the user enteres x
            //After that the application should ask for a text (sentence)
            //When that is done the application should show how many times that name was included in the text ignoring upper / lower case -->

            CountNamesOccurences();

        }

        static void CountNamesOccurences()
        {
            List<string> names = new List<string>();

            string name = "";
            Console.WriteLine("Please enter one or more names. Enter 'x' after you are done.");

            while (name.ToLower() != "x")
            {
                try
                {
                    
                    name = Console.ReadLine().Trim();

                    if (name.ToLower() == "x")
                    {
                        break;
                    }
                    else if (string.IsNullOrEmpty(name))
                    {
                        throw new Exception("The input for a name is invalid!");
                    }
                    names.Add(name);
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

            int counter = 1;
            Console.WriteLine("Thank you, you have entered the following names:\n");
            foreach (string member in names)
            {
                Console.WriteLine($"{counter}. {member}");
                counter++;
            }

            Console.WriteLine("\nPlease write a text/sentence:\n");
            string sentence = Console.ReadLine();

            while (string.IsNullOrEmpty(sentence))
            {
                Console.WriteLine("You must enter a valid sentence.");
                sentence = Console.ReadLine();
            }

            char[] removeCharacters = new char[] { '.', ',', '!', '?', ';', ':', ' ' };
            string[] wordsInTheSentence = sentence.Split(removeCharacters, StringSplitOptions.RemoveEmptyEntries);            
            
            foreach (string member in names)
            {
                int repeatingOccurances = 0;

                foreach (string word in wordsInTheSentence)
                {
                    if(member.ToLower() == word.ToLower())
                    {
                        repeatingOccurances++;
                    }
                }

                Console.WriteLine($"The name {member} is mentioned {repeatingOccurances} time/s in the sentence.");
            }

        }

    }
}
