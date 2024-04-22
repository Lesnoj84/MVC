using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp.Interfaces;

namespace ConsoleApp.Classes
{
    internal class Dog : IAnimal
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public Dog(string name, int age)
        {
            Name = name;
            Age = age;
        }
        public void MakeSound()
        {
            Console.WriteLine($"{Name} the dog is doing Woof-woof");
        }
        
    }
}
