﻿namespace Blazor_GameStoreApp.Components.Model
{
    public class GameClient
    {
        public readonly List<Game> gamesList = [
        new(){Id=1,Name="Street Fighter",Genre="Fighting", Price=19.9M, ReleasedDate=new DateOnly(1992,3,15)},
        new(){Id=2,Name="Fifa",Genre="Sport", Price=24.9M, ReleasedDate=new DateOnly(1993,7,11)},
        new(){Id=3,Name="Sonic",Genre="Arcade", Price=21.9M, ReleasedDate=new DateOnly(1991,8,25)},
        new(){Id=4,Name = "Contra",Genre = "Shooter", Price = 25.9M, ReleasedDate = new DateOnly(1990, 10, 5)}];

        public Game[] GetGames()
        {
            return gamesList.ToArray();
        }
    }
}
