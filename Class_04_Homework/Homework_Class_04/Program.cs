using Homework_Class_04.Models;

namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //            ▸ Create 4 classes:
            //▹ Pet( abstract ) with Name, Type, Age and abstract PrintInfo()
            //▹ Dog(from Pet) with GoodBoi and FavoriteFood
            //▹ Cat(from Pet) with Lazy and LivesLeft
            //▹ Fish(from Pet) with color, size
            //▸ Create a PetStore generic class with :
            //▹ Generic list of pets - Dogs, Cats or Fish depending on what is passed as T
            //▹ Generic method printsPets() - Prints Dogs, Cats or Fish depending on what is passed as T
            //▹ BuyPet() - Method that takes ‘name’ as parameter, find the first pet by that name, removes
            //it from the list and gives a success message.If there is no pet by that name, inform the
            //customer
            //▸ Create a Dog, Cat and fish store with 2 pets each
            //▹ Buy a dog and a cat from the Dog and Cat store
            //▹ Call PrintPets() method on all stores


            PetStore<Dog> dogStore = new PetStore<Dog>();
            PetStore<Cat> catStore = new PetStore<Cat>();
            PetStore<Fish> fishStore = new PetStore<Fish>();

            Dog sharac = new Dog("Sharko", "Sharplaninec", 3, true, "Beef");
            Dog belec = new Dog("Crni", "Maltesse", 1, false, "rabbits");
            Cat garfield = new Cat("Garfild", "Siamic", 3, true, 5);
            Cat machor = new Cat("Machorot vo chizmi", "Tiger", 2, false, 10);
            Fish gabriel = new Fish("Gabriel", "dolphin", 4, "grey", 300);
            Fish nemo = new Fish("Nemo", "Gold fish", 2, "yellow", 10);

            dogStore.Add(sharac);
            dogStore.Add(belec);

            catStore.Add(garfield);
            catStore.Add(machor);

            fishStore.Add(gabriel);
            fishStore.Add(nemo);

            Console.WriteLine("=========== Before purchases:");
            dogStore.PrintsPets();
            catStore.PrintsPets();
            fishStore.PrintsPets();

            dogStore.BuyPet("sharko");
            catStore.BuyPet("garfild");
            fishStore.BuyPet("nemo");

            Console.WriteLine("=========== After purchases:");
            dogStore.PrintsPets();
            catStore.PrintsPets();
            fishStore.PrintsPets();

            dogStore.BuyPet("Angele");

            //sharac.PrintInfo();
            //belec.PrintInfo();
            //garfield.PrintInfo();
            //machor.PrintInfo();
            //gabriel.PrintInfo();
            //nemo.PrintInfo();

        }

    }
}
