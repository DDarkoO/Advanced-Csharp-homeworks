using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Models
{
    internal static class DogShelter
    {
        public static List<Dog> AllDogs = new List<Dog>();
        
        public static void PrintAll(List<Dog> allDogs)
        {
            Console.WriteLine("All dogos in our shelter:");
            int counter = 1;
            foreach (Dog dog in allDogs)
            {
                Console.WriteLine($"{counter}. {dog.Name}");
                counter++;
            }            
        }

    }
}
