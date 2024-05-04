using ConsoleApp.Classes;
using ConsoleApp.Interfaces;
using System.Diagnostics;
using static ConsoleApp.Classes.DatabaseSample;

namespace ConsoleApp;

internal class Program
{
    static void Main(string[] args)
    {



       
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

