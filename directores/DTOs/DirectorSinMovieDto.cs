namespace directores.DTOs
{
    //lo creó el 01-06 Hace lo mismo que directores pero sin movie
    public class DirectorSinMovieDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
    }
}
