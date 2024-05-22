using ConsoleApp.Classes;
using ConsoleApp.Interfaces;
using System.Diagnostics;
using static ConsoleApp.Classes.DatabaseSample;

namespace ConsoleApp;

internal class Program
{
    static void Main(string[] args)
    {
        PassWordHasher hasher = new PassWordHasher();

        Console.WriteLine("Create password");

        string password = Console.ReadLine();

        string hashedPassword = hasher.Hash(password);

        Console.WriteLine("Password was:{0}\n Hashed password is: {1} ", password, hashedPassword);


        Console.WriteLine("Do you want to verify the password? ");
        string answere = Console.ReadLine().ToLower();

        if (answere == "y")
        {
            Console.WriteLine("Enter your password");
            string enteredPassword = Console.ReadLine();

            if (!string.IsNullOrEmpty(enteredPassword))
            {
                bool isCorrect = hasher.Verify(hashedPassword, enteredPassword);
                Console.WriteLine(isCorrect ? "Your password is correct" : "Your password is incorrect");
            }
        }


    }
    #region IQueryable & IEnumerable
    //DatabaseSample databaseSample = new DatabaseSample();

    //Stopwatch swIQ = Stopwatch.StartNew();

    //IQueryable<Client> clients = databaseSample.CreateClients(20).AsQueryable();

    //foreach (var client in clients.Where(c=>c.Age>32))
    //{

    //    Console.WriteLine("Name: {0}, Age: {1}, Occupation: {2}",client.Name,client.Age, client.Occupation);
    //}
    //swIQ.Stop();
    //Console.WriteLine("IQueryable took {0} to build", swIQ.ElapsedMilliseconds);


    //Stopwatch swIE = Stopwatch.StartNew();

    //IEnumerable<Client> servers = databaseSample.CreateClients(20);
    //foreach (var item in servers.Where(c=>c.Age>32))
    //{
    //    Console.WriteLine("Name: {0}, Age: {1}, Occupation: {2}", item.Name, item.Age, item.Occupation);
    //}
    //swIE.Stop();
    //Console.WriteLine("IEnumerable took {0} to build", swIE.ElapsedMilliseconds);
    #endregion
}

