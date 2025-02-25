using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module_3
{
    public class Fish : Animal
    {
        public Fish (string name, int age) : base(name, age)
        {
        }
        public override void MakeSound()
        {
            Console.WriteLine($"{Name} bubbles.");
        }
    }


}
