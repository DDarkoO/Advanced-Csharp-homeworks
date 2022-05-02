using ConsoleApp1.Models;
using System;


namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dog sharko = new Dog(3, "Sharko", "Black and white");
            Dog belko = new Dog(1, "Belcho", "white");
            Dog snoopy = new Dog(2, "Snoopy", "yellow");

            sharko.Bark();
            belko.Bark();
            snoopy.Bark();

            Console.WriteLine(Dog.Validate(sharko));
            Console.WriteLine(Dog.Validate(belko));
            Console.WriteLine(Dog.Validate(snoopy));

            DogShelter.AllDogs.Add(sharko);
            DogShelter.AllDogs.Add(belko);
            DogShelter.AllDogs.Add(snoopy);

            DogShelter.PrintAll(DogShelter.AllDogs);

        }
    }


}