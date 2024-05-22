namespace ConsoleApp.Interfaces
{
    public interface IPassWordHasher
    {
        string Hash(string newPassword);
        bool Verify(string password, string inputPassword);

    }
}