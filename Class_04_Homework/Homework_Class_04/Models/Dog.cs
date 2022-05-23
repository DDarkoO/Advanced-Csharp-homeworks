
namespace Homework_Class_04.Models
{
    public class Dog : Pet
    {
        public bool GoodBoi { get; set; }
        public string FavoriteFood { get; set; }

        public override string PrintInfo()
        {
            if (GoodBoi == false)
            {
                return $"Hi, I am the dog {Name}. My breed is {Type} and I am {Age} years old. \nMy favorite food is {FavoriteFood}, but they won't give it to me because I am a bad boi for life! Woof!\n";
            }
            else
            {
                return $"Hi, I am the dog {Name}. My breed is {Type} and I am {Age} years old. \nMy favorite food is {FavoriteFood} and I consume 5kg of it each day before my daily workout! Woof!\n";
            }
        }

        public Dog(string name, string type, int age, bool goodOrBad, string favFood) : base(name, type, age)
        {
            GoodBoi = goodOrBad;
            FavoriteFood = favFood;
        }


    }
}
