using ConsoleApp.Interfaces;

namespace ConsoleApp
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
