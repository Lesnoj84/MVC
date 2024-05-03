using ConsoleApp.Classes;
using ConsoleApp.Interfaces;

namespace ConsoleApp;

internal class Program
{
    static void Main(string[] args)
    {
        //Cat cat = new ("Kitty",25);
        //Dog dog = new ("Bogo",5);
        //Animal animal = new Animal();
        //animal.MakeSound(cat);

        Category category = new Category();
        var myArr = category.Categories;
        myArr[0] = new Category { Id = 1, Name = "Action", DisplayOrder = 1 };
        myArr[1] = new Category { Id = 2, Name = "SciFi", DisplayOrder = 2 };
        myArr[2] = new Category { Id = 3, Name = "History", DisplayOrder = 3 };

        //IEnumerable<Category> categories = myArr;
        foreach (var item in myArr.Where(u=>u.Name.ToLower().Contains("s")))
        {
            Console.WriteLine(item.Name);
        }


    }

    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int DisplayOrder { get; set; }
        public Category[] Categories { get; set; } = new Category[3];
    }
}

