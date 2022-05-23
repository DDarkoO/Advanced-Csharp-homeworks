using Class_11_Homework.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace Class_11_Homework
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dog dog1 = ModelADog();
            Dog dog2 = ModelADog();
            Dog dog3 = ModelADog();
            Dog dog4 = ModelADog();

            List<Dog> ourDogs = new()
            {
                dog1,
                dog2,
                dog3,
                dog4
            };

            string filePath = "dogsDataBase.txt";

            if (!File.Exists(filePath))
            {
                File.Create(filePath).Close();
            }

            string ourDogsInJson = JsonConvert.SerializeObject(ourDogs);

            ReadDeserializePrint(ourDogsInJson);

        }


        public static Dog ModelADog()
        {
            Dog dog = new();

            Console.WriteLine("Please enter a name for your new dog");
            
            while (string.IsNullOrEmpty(dog.Name = Console.ReadLine()))
            {
                Console.WriteLine("You haven't entered a name, please name your dog.");
            };

            Console.WriteLine("How old is your dog?");
            int age;

            while (!int.TryParse(Console.ReadLine(), out age))
            {
                Console.WriteLine("Invalid value for the dog's age, please try again.");
            }

            dog.Age = age;

            Console.WriteLine("Which color is your dog?");
            
            while(string.IsNullOrEmpty(dog.Color = Console.ReadLine()))
            {
                Console.WriteLine("You haven't stated your dog's color, please let me know which color is it?");
            };

            return dog;

        }

        public static void ReadDeserializePrint(string dogsFile)
        {
            List<Dog> dogs = JsonConvert.DeserializeObject<List<Dog>>(dogsFile);

            Console.WriteLine("The following dogs are part of our family:");
            Console.WriteLine("==========================================");

            foreach (Dog dog in dogs)
            {
                Console.WriteLine($"Name: {dog.Name}");
                Console.WriteLine($"Age: {dog.Age}");
                Console.WriteLine($"Color: {dog.Color}");
                Console.WriteLine("-----------------------");
            }
        }
    }
}
