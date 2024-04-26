using GameStore.Api.Dtos;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

const string GetGameEndpointName = "GetGame";

List<GameDto> games = [
        new(1,"Street Fighter","Fighting",19.9M,new DateOnly(1992,3,15)),
        new(2,"Fifa","Sport",24.9M, new DateOnly(1993,7,11)),
        new(3,"Sonic","Arcade",21.9M,new DateOnly(1991,8,25)),
        new(4,"Contra","Shooter",25.9M,new DateOnly(1990, 10, 5))
        ];

//GET / games
app.MapGet("games",()=>games);

//GET / games/1
app.MapGet("games/{id}", (int id) => games.Find(game => game.Id == id))
    .WithName("GetGameEndpointName");

//POST / games
app.MapPost("games",(CreateGameDto newGame) =>
{
    GameDto game = new(games.Count + 1, newGame.Name, newGame.Genre, newGame.Price, newGame.ReleaseDate);
    games.Add(game);
    return Results.CreatedAtRoute("GetGameEndpointName", new { id=game.Id},game);
});

app.Run();
