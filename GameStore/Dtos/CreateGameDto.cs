namespace GameStore.Api.Dtos
{
    public record CreateGameDto(
    //int Id,on Id because the Id will be provided by Database.
    string Name,
    string Genre,
    decimal Price,
    DateOnly ReleaseDate);
    
}
