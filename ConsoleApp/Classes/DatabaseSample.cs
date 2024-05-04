using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Classes;

public class DatabaseSample
{
   public List<Client> CreateClients(int number)
    {
        List<Client> clients = new List<Client>();
        Random random = new Random();

        for (int i = 0; i < number; i++)
        {
            Client client = new Client
            {
                ID = clients.Count + 1,
                Name = GenerateRandomeName(),
                Age = random.Next(18, 80),
                Gender = (random.Next(2) == 0) ? "Male" : "Female",
                Occupation = GenerateRandomeOccupation()
            };
            clients.Add(client);
        }
        return clients;
    }


    public class Client
    {
        internal int ID { get; set; }
        internal string Name { get; set; }
        internal int Age { get; set; }
        internal string Gender { get; set; }
        internal string Occupation { get; set; }
    }

    private string GenerateRandomeName()
    {
        string[] names =  { "John","Mike","Tome","Alex","Kate","Marty","Alice"
                            ,"Bob", "Emma", "Michael", "Olivia", "David", "Sophia", "James"
                            ,"Emily","Tobiah","Philip" };
        Random rand = new Random();
        string returnesRndName = names[rand.Next(names.Length)];
        return returnesRndName;
    }

    private string GenerateRandomeOccupation()
    {
        string[] occupations = { "Engineer","Doctor", "Teacher", "Artist", "Lawyer", "Nurse"
                                ,"Developer","Chef", "Accountant", "Writer" };

        Random rand = new Random();
        string returnesRndOccup = occupations[rand.Next(occupations.Length)];
        return returnesRndOccup;
    }





}
