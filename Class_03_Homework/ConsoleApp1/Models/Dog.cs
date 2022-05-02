using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Models
{
    internal class Dog
    {
        public int Id { get; set; }
        public string Name { get; set; }    
        public string Color { get; set; }

        public Dog(int id,string name, string color)
        {
            Id = id;
            Name = name;
            Color = color;
        }

        public void Bark()
        {
            Console.WriteLine($"{Name} is barking all night under the lemon tree.");
        }

        public static bool Validate(Dog dog)
        {
            if (dog.Id > 0 && dog.Name.Length > 1 && dog.Color != string.Empty)
            {
                return true;
            }
            return false;
        }
    }
}
