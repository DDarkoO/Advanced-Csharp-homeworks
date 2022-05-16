using System;
using System.IO;

namespace Class_09_Homework_FileSystem
{
    using System.IO;
    internal class Program
    {
        static void Main(string[] args)
        {
            // 1) Create a folder called Exercise
            string exerciseFolderPath = @"..\..\..\" + @"Exercise\";

            if (!Directory.Exists(exerciseFolderPath))
            {
                Directory.CreateDirectory(exerciseFolderPath);
            }

            // 2) Create a txt file in it called calculations.txt
            string myFile = exerciseFolderPath + @"calculations.txt";

            if (!File.Exists(myFile))
            {
                File.Create(myFile).Close();
            }
            

            // 6) Call the console 3 times and write 3 results in the txt file
            SumOfTwoNumbers(myFile);
            SumOfTwoNumbers(myFile);
            SumOfTwoNumbers(myFile);

        }

        // 3) Create a static method that sums 2 numbers and returns a string in the format: num1 + num2 = result(Ex: 2 + 3 = 5 )
        // 4) Ask the user to enter 2 numbers, call the calculate method and give the result
        public static void SumOfTwoNumbers(string filePath)
        {
            double numOne;
            double numTwo;

            Console.WriteLine("Enter a number:");
            while (!double.TryParse(Console.ReadLine(), out numOne))
            {
                Console.WriteLine("Wrong input, please re-enter the first number:");
            };

            Console.WriteLine("Enter another number:");
            while (!double.TryParse(Console.ReadLine(), out numTwo))
            {
                Console.WriteLine("Wrong input, please re-enter the second number:");
            };
                        
            string stringOfTheResult = $"{numOne} + {numTwo} = {numOne + numTwo}";
            Console.WriteLine(stringOfTheResult);
            
            AppendingLinesToFile(filePath, stringOfTheResult);

        }

        // 5) After the result is written in the console it should also be written in the calculations.txt file with a time stamp next to it
        public static void AppendingLinesToFile(string filePath, string result)
        {
            string toWriteInFile = "Calculation: "+ result + " ; Date and time of the execution: " + (string)DateTime.Now.ToString();
            
            using (StreamWriter sw = new StreamWriter(filePath, true))
            {
                sw.WriteLine(toWriteInFile);
            }
        }
    }
}
