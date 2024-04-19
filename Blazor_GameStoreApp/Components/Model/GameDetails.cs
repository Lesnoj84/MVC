namespace Blazor_GameStoreApp.Components.Model
{
    public class GameDetails
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? GenreId { get; set; }
        public decimal Price { get; set; }
        public DateOnly ReleasedDate { get; set; }




        public string[] GetGenreList()
        {
            string[] GenreList = ["Fight", "Racing", "Sport", "Arcade", "Shooter"];
            return GenreList.OrderBy(x => x).ToArray();
        }

        public void AddGame(GameDetails game)
        {
            GameClient GameClient = new GameClient();
            if (game != null && GameClient != null)
            {

                var newGame = new Game()
                {
                    Id = GameClient.gamesList.Count + 1,
                    Name = game.Name,
                    Genre = game.GenreId,
                    Price = game.Price,
                    ReleasedDate = game.ReleasedDate
                };

                GameClient.gamesList.Add(newGame);
            }
        }
    }
}
