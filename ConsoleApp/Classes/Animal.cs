using ConsoleApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ConsoleApp.Classes
{
    internal class Animal
    {

        public void MakeSound(IAnimal animal)
        {
            animal.MakeSound();
        }
    }
}
