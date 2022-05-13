using Class_06_homework_advLinq.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Class_06_homework_advLinq
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Dog> dogs = new List<Dog>()
            {
                new Dog("Charlie", "Black", 3, Race.Collie), // 0
	            new Dog("Buddy", "Brown", 1, Race.Doberman),
                new Dog("Max", "Olive", 1, Race.Plott),
                new Dog("Archie", "Black", 2, Race.Mutt),
                new Dog("Oscar", "White", 1, Race.Mudi),
                new Dog("Toby", "Maroon", 3, Race.Bulldog), // 5
	            new Dog("Ollie", "Silver", 4, Race.Dalmatian),
                new Dog("Bailey", "White", 4, Race.Pointer),
                new Dog("Frankie", "Gray", 2, Race.Pug),
                new Dog("Jack", "Black", 5, Race.Dalmatian),
                new Dog("Chanel", "Black", 1, Race.Pug), // 10
	            new Dog("Henry", "White", 7, Race.Plott),
                new Dog("Bo", "Maroon", 1, Race.Boxer),
                new Dog("Scout", "Olive", 2, Race.Boxer),
                new Dog("Ellie", "Brown", 6, Race.Doberman),
                new Dog("Hank", "Silver", 2, Race.Collie), // 15
	            new Dog("Shadow", "Silver", 3, Race.Mudi),
                new Dog("Diesel", "Brown", 4, Race.Bulldog),
                new Dog("Abby", "Black", 1, Race.Dalmatian),
                new Dog("Trixie", "White", 8, Race.Pointer), // 19
            };

            List<Person> people = new List<Person>()
            {
                new Person("Nathanael", "Holt", 20, Job.Choreographer),
                new Person("Rick", "Chapman", 35, Job.Dentist),
                new Person("Oswaldo", "Wilson", 19, Job.Developer),
                new Person("Kody", "Walton", 43, Job.Sculptor),
                new Person("Andreas", "Weeks", 17, Job.Developer),
                new Person("Kayla", "Douglas", 28, Job.Developer),
                new Person("Richie", "Campbell", 19, Job.Waiter),
                new Person("Soren", "Velasquez", 33, Job.Interpreter),
                new Person("August", "Rubio", 21, Job.Developer),
                new Person("Rocky", "Mcgee", 57, Job.Barber),
                new Person("Emerson", "Rollins", 42, Job.Choreographer),
                new Person("Everett", "Parks", 39, Job.Sculptor),
                new Person("Amelia", "Moody", 24, Job.Waiter)
                    { Dogs = new List<Dog>() {dogs[16], dogs[18] } },
                new Person("Emilie", "Horn", 16, Job.Waiter),
                new Person("Leroy", "Baker", 44, Job.Interpreter),
                new Person("Nathen", "Higgins", 60, Job.Archivist)
                    { Dogs = new List<Dog>(){dogs[6], dogs[0] } },
                new Person("Erin", "Rocha", 37, Job.Developer)
                    { Dogs = new List<Dog>() {dogs[2], dogs[3], dogs[19] } },
                new Person("Freddy", "Gordon", 26, Job.Sculptor)
                    { Dogs = new List<Dog>() {dogs[4], dogs[5], dogs[10], dogs[12], dogs[13] } },
                new Person("Valeria", "Reynolds", 26, Job.Dentist),
                new Person("Cristofer", "Stanley", 28, Job.Dentist)
                    { Dogs = new List<Dog>() {dogs[9], dogs[14], dogs[15] } }
            };

            #region Task1
            // TASK 1) Find and print all persons firstnames starting with 'R', ordered by Age - DESCENDING ORDER
            Helper.HeaderColor("1) All persons firstnames starting with 'R', ordered by Age - DESCENDING ORDER");

            IEnumerable<Person> personsWhoseNameStartsWithRbyAgeDescending =
                from person in people
                where person.FirstName.StartsWith("R", StringComparison.InvariantCultureIgnoreCase)
                orderby person.Age descending
                select person;
                        
            foreach (Person person in personsWhoseNameStartsWithRbyAgeDescending)
            {
                Console.WriteLine($"Name: {person.FirstName}, Aged {person.Age}");
            }
            #endregion
            #region Task2
            // TASK 2) Find and print all brown dogs names and ages older than 3 years, ordered by Age - ASCENDING ORDER
            Helper.HeaderColor("\n2) All brown dogs names and ages older than 3 years, ordered by Age - ASCENDING ORDER");

            IEnumerable<Dog> brownDogsOlderThan3Names =
                from dog in dogs
                where dog.Color == "Brown"
                where dog.Age > 3
                orderby dog.Age
                select dog;
                        
            foreach (Dog dog in brownDogsOlderThan3Names)
            {
                Console.WriteLine($"I am the brown dog {dog.Name} and I am {dog.Age} years old.");
            }
            #endregion
            #region Task3
            // TASK 3) Find and print all persons with more than 2 dogs, ordered by Name - DESCENDING ORDER
            Helper.HeaderColor("\n3) Find and print all persons with more than 2 dogs, ordered by Name - DESCENDING ORDER");

            IEnumerable<Person> peopleWithMoreThan2Dogs =
                from person in people
                where person.Dogs.Count > 2
                orderby person.FirstName
                select person;

            peopleWithMoreThan2Dogs.Print();
            #endregion
            #region Task4
            // TASK 4) Find and print all Freddy`s dogs names older than 1 year
            Helper.HeaderColor("\n4) All Freddy`s dogs names older than 1 year");

            IEnumerable<Dog> freddyDogsOlderThan1Names = null;

            if (people.Any(person => person.FirstName == "Freddy"))
            {
                freddyDogsOlderThan1Names = people
                    .Where(person => person.FirstName == "Freddy")
                    .SelectMany(freddiesDogs => freddiesDogs.Dogs)
                    .Where(dogs => dogs.Age > 1);
            };
            
            //freddyDogsOlderThan1Names.Print();
            foreach (Dog dog in freddyDogsOlderThan1Names)
            {
                Console.WriteLine($"I am Freddie's dog {dog.Name} and I am {dog.Age} years old. Woof!");
            }
            #endregion
            #region Task5
            // TASK 5) Find and print Nathen`s first dog
            Helper.HeaderColor("\n5) Nathen`s first dog");

            IEnumerable<Dog> nathensFirstDog = people
                .Where(person => person.FirstName == "Nathen")
                .Select(person => person.Dogs.First());

            nathensFirstDog.Print();
            #endregion
            #region Task6
            // TASK 6) Find and print all white dogs names from Cristofer, Freddy, Erin and Amelia, ordered by Name -ASCENDING ORDER
            Helper.HeaderColor("\n6) All white dogs names from Cristofer, Freddy, Erin and Amelia, ordered by Name -ASCENDING ORDER");

            IEnumerable<Dog> allWhiteDogs = people
                .Where(person => person.FirstName == "Cristofer" ||
                                 person.FirstName == "Freddy" ||
                                 person.FirstName == "Erin" ||
                                 person.FirstName == "Amelia")
                .SelectMany(person => person.Dogs)
                .Where(dogs => dogs.Color == "White")
                .OrderBy(dogs => dogs.Name);

            //allWhiteDogs.Print();
            foreach (Dog dog in allWhiteDogs)
            {
                Console.WriteLine($"I am the white dog {dog.Name}.");
            }
            #endregion

        }
    }
}
