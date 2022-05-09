

namespace Homework_Class_04.Models
{
    internal class PetStore<T> where T : Pet
    {
        public List<T> AllPets = new List<T>();

        public PetStore()
        {
            AllPets = new List<T>();
        }

        public void PrintsPets()
        {
            if (AllPets.Count > 0)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"We have {AllPets.Count} {typeof(T).Name}/s in our store:");
                Console.ForegroundColor= ConsoleColor.White;
                int counter = 1;
                foreach (T pet in AllPets)
                {
                    Console.WriteLine($"{counter}. {pet.PrintInfo()}");
                    counter++;                    
                }
                
            }
            else
            {
                Console.WriteLine("We are sorry, we are out of pets. Come back after the mating season.");
            }
        }

        public void BuyPet(string name)
        {
            //if (AllPets.Count > 0)
            //{
            //    foreach (T item in AllPets)
            //    {
            //        if (item.Name.ToLower() == name.ToLower())
            //        {
            //            AllPets.Remove(item);
            //            Console.WriteLine($"Great, you have bought {name} and now you have a new family member!");
            //        }
            //        else
            //        {
            //            Console.WriteLine("Sorry, there is no pet with that name in our store.");
            //        }
            //    }
            //}

            //==ALTERNATIVE==
            if (AllPets.Count > 0)
            {
                try
                {
                    T pet = AllPets.First(x => x.Name.ToLower() == name.ToLower());
                    AllPets.Remove(pet);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"Great, you have bought {name.ToUpper()} and now you have a new family member! \n");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                catch 
                {
                    Console.WriteLine($"We are sorry, we don't have a pet with the name {name.ToUpper()} :( ");
                }
            }


        }

        public void Add(T pet)
        {
            AllPets.Add(pet);
        }


    }
}
