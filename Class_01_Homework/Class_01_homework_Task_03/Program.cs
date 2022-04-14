using System;
using System.Collections.Generic;
using System.Linq;

namespace Class_01_homework_Task_03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //            3.Create a console application that plays rock -paper - scissors - BONUS🔹
            //There should be a menu with three options:
            //Play
            //The user picks rock paper or scissors option(rock, paper or scissors as strings)
            //The application picks rock paper scissors on random
            //The user pick and the application pick are shown on the screen
            //The application shows the winner
            //The application saves 1 score to the user or the computer in the background
            //When the user hits enter it returns to the main menu
            //Stats
            //It shows how many wins the user and how many wins the computer has
            //It shows percentage of the wins and loses of the user
            //When the user hits enter it returns to the main menu
            //Exit
            //It closes the application

            int playerScore = 0;
            int cpuScore = 0;
            int tieCount = 0;

            RockPaperScissors(playerScore, cpuScore, tieCount);

        }


        static void RockPaperScissors(int playerScore, int cpuScore, int tieCount)
        {
            Console.WriteLine("==== Main menu. Please pick one of the options below: ==== \n 1. Play \n 2. Stats \n 3. Exit");
            while (true)
            {
                try
                {
                    int choice = int.Parse(Console.ReadLine());

                    if (choice != 1 && choice != 2 && choice != 3)
                    {
                        throw new ArgumentOutOfRangeException("Invalid choice!");
                    }
                    else if (choice == 1)
                    {
                        PlayTheGame(playerScore, cpuScore, tieCount);
                    }
                    else if (choice == 2)
                    {                        
                        ShowScores(playerScore, cpuScore, tieCount);
                        RockPaperScissors(playerScore, cpuScore, tieCount);
                    }
                    else
                    {
                        Console.WriteLine("               :(");
                        Console.Write("\n Current score: You: ");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(playerScore);
                        Console.ResetColor();
                        Console.Write(" CPU: ");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write($"{cpuScore}\n\n");
                        Console.ResetColor();
                        Console.WriteLine("========== Thank you for playing! Have a nice day! ==========");
                        Environment.Exit(0);
                    }
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid number, you must enter a number between 1, 2 and 3!");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(ex);
                    Console.WriteLine(ex.Message);
                    Console.WriteLine(ex.StackTrace);
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid unput, you must enter a number between 1, 2 and 3!");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(ex);
                    Console.WriteLine(ex.Message);
                    Console.WriteLine(ex.StackTrace);
                }
                finally
                {
                    Console.ResetColor();
                }
            }

        }

        static void PlayTheGame(int playerScore, int cpuScore, int tieCount)
        {

            Console.WriteLine("\nPick your weapon: \n 1. Rock \n 2. Paper \n 3. Scissors");
            while (true)
            {
                Dictionary<int, string> weapons = new Dictionary<int, string>()
                {
                    { 1, "Rock" },
                    { 2, "Paper" },
                    { 3, "Scissors" }
                };

                int userWeaponInt = int.Parse(Console.ReadLine());
                string userWeapon = weapons[userWeaponInt];

                int cpuWeaponInt = new Random().Next(1, 4);
                string cpuWeapon = weapons[cpuWeaponInt];

                Console.WriteLine($"Player choice: {userWeapon} vs \nCPU choice: {cpuWeapon}\n");


                if (userWeapon == "Rock")
                {
                    switch (cpuWeapon)
                    {
                        case "Rock":
                            Console.WriteLine("A tie!");
                            tieCount++;
                            break;
                        case "Paper":
                            Console.WriteLine("CPU wins!");
                            cpuScore++;
                            break;
                        case "Scissors":
                            Console.WriteLine("You won!");
                            playerScore++;
                            break;
                    }
                }
                else if (userWeapon == "Paper")
                {
                    switch (cpuWeapon)
                    {
                        case "Rock":
                            Console.WriteLine("CPU wins!");
                            cpuScore++;
                            break;
                        case "Paper":
                            Console.WriteLine("A Tie!");
                            tieCount++;
                            break;
                        case "Scissors":
                            Console.WriteLine("You won!");
                            playerScore++;
                            break;
                    }
                }
                else
                {
                    switch (cpuWeapon)
                    {
                        case "Rock":
                            Console.WriteLine("CPU wins!");
                            cpuScore++;
                            break;
                        case "Paper":
                            Console.WriteLine("You won!");
                            playerScore++;
                            break;
                        case "Scissors":
                            Console.WriteLine("A tie!");
                            tieCount++;
                            break;
                    }
                }

                Console.Write("\n Current score: You: ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(playerScore);
                Console.ResetColor();
                Console.Write(" CPU: ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write($"{cpuScore}\n\n");
                Console.ResetColor();

                RockPaperScissors(playerScore, cpuScore, tieCount);

            }
        }

        static void ShowScores(int playerScore, int cpuScore, int tieCount)
        {
            if ((playerScore + cpuScore == 0) && tieCount == 0)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("No games have been played yet :( \n");
                Console.ResetColor();
            }
            else
            {
                Console.WriteLine("================= STATS =================");
                Console.Write("\n Current score: You: ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(playerScore);
                Console.ResetColor();
                Console.Write(" CPU: ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write($"{cpuScore}\n\n");
                Console.ResetColor();

                Console.WriteLine("=== Percentage of wins: ===\n");

                double playerWinsPercentage = (double)playerScore / (playerScore + cpuScore) * 100;
                double cpuWinsPercentage = 100 - playerWinsPercentage;

                if (double.IsNaN(playerWinsPercentage) && double.IsNaN(cpuWinsPercentage) && tieCount > 0)
                {
                    playerWinsPercentage = 0;
                    cpuWinsPercentage = 0;
                    Console.Write(" PLAYER: ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write($"{playerWinsPercentage} % ");
                    Console.ResetColor();
                    Console.Write(" CPU: ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write($"{cpuWinsPercentage} %\n\n");
                    Console.ResetColor();
                }

                else if (double.IsNaN(playerWinsPercentage))
                {
                    playerWinsPercentage = 0;
                    Console.Write("PLAYER: ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write($"{playerWinsPercentage} % ");
                    Console.ResetColor();
                    Console.Write(" CPU: ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write($"{100 - playerWinsPercentage} %\n\n");
                    Console.ResetColor();
                }
                else
                {
                    Console.Write("PLAYER: ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write($"{playerWinsPercentage} % ");
                    Console.ResetColor();
                    Console.Write(" CPU: ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write($"{100 - playerWinsPercentage} %\n\n");
                    Console.ResetColor();
                }
            }
            RockPaperScissors(playerScore, cpuScore, tieCount);
        }


    }
}
