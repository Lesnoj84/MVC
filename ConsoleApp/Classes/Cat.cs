using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp.Interfaces;

namespace ConsoleApp.Classes
{
    internal class Cat : IAnimal
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public Cat(string name, int age)
        {
            Name = name;
            Age = age;
        }
        public void MakeSound()
        {
            Console.WriteLine($"{Name} the cat is doing Mow-mow");
        }
    }
}
