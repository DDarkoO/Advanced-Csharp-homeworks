using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_Class_04.Models
{
    internal class Cat : Pet
    {
        public bool Lazy { get; set; }
        private int _livesLeft;

        public int LivesLeft
        {
            get
            {
                return _livesLeft;
            }
            set
            {
                if (_livesLeft < 1 || _livesLeft > 9)
                {
                    _livesLeft = 9;
                }
                else
                {
                    _livesLeft = value;
                }
            }
        }


        public Cat(string name, string type, int age, bool lazyOrNot, int livesLeft) : base(name, type, age)
        {
            Lazy = lazyOrNot;
            LivesLeft = livesLeft;
        }

        public override string PrintInfo()
        {
            if (Lazy == false)
            {
                return $"Meow. I am the cat {Name}. I am {Age} years old {Type} with {LivesLeft} lives left. What was that? Lazy? You've got the wrong cat, human!\n";
            }
            else
            {
                return $"Meow. I am the cat {Name}. I am {Age} years old {Type} with {LivesLeft} lives left. What was that? Lazy? You've got me there, that's me!\n";
            }
        }

    }
}
