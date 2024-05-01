using ConsoleApp.Classes;
using ConsoleApp.Interfaces;

namespace ConsoleApp;

internal class Program
{
    static void Main(string[] args)
    {
        Cat cat = new ("Kitty",25);
        Dog dog = new ("Bogo",5);

        Animal animal = new Animal();


        animal.MakeSound(cat);



      
        


    }
}
   
