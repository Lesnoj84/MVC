namespace ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter File name");

            string path = "C:\\Users\\Vitalij\\OneDrive - Auspi Europe s.r.o\\Dokumenty";

            string fileName = Console.ReadLine();

            Search(path, fileName);

        }

        static void Search(string path, string fileName)
        {


            var directory = Directory.GetFiles(path, "*", SearchOption.AllDirectories);
            List<string> result = new List<string>();

            foreach (string dir in directory)
            {
                if (Path.GetFileNameWithoutExtension(dir).ToLower().Contains(fileName))
                {
                    result.Add(dir);
                }
            }

            foreach (string dir in result)
            {
                Console.WriteLine(dir);
            }

        }

    }
}
