namespace Blazor_GameStoreApp.Components.Model
{
    public class GameDb
    {
        public readonly List<Game> gamesList = [
        new(){Id=1,Name="Street Fighter",Genre=enumGameGenre.Fighting, Price=19.9M, ReleasedDate=new DateOnly(1992,3,15)},
        new(){Id=2,Name="Fifa",Genre=enumGameGenre.Sport, Price=24.9M, ReleasedDate=new DateOnly(1993,7,11)},
        new(){Id=3,Name="Sonic",Genre=enumGameGenre.Arcade, Price=21.9M, ReleasedDate=new DateOnly(1991,8,25)},
        new(){Id=4,Name = "Contra",Genre = enumGameGenre.Shooter, Price = 25.9M, ReleasedDate = new DateOnly(1990, 10, 5)}];



       public enumGameGenre GameGenre;
        public Game[] GetGames()
        {
            return gamesList.ToArray();
        }


        public void AddGame(Game game)
        {
            gamesList.Add(game);
        }
        public void RemoveGame(int id)
        {
            var game = gamesList.Find(x => x.Id == id);
            ArgumentNullException.ThrowIfNull(game);
            gamesList.Remove(game);
        }

    }
}
