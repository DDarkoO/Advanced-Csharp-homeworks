using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_Class_04.Models
{
    internal class Fish : Pet
    {
        public string Color { get; set; }
        public int Size { get; set; }


        public Fish(string name, string type, int age, string color, int size) : base(name, type, age)
        {
            Color = color;
            Size = size;
        }


        public override string PrintInfo()
        {
            return $"I am the {Color} fish {Name}, {Age} years old. I am a {Type}. I am {Size} cm large. Or small, depends on the perspective. All's relative.\n";
        }

        
    }
}
