namespace directores.DTOs
{
    public class MovieDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string? Location { get; set; }

        public int Year { get; set; }

    }
}
