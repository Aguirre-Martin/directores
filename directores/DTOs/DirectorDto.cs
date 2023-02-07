using directores.DTOs;

namespace directores.DTOs //cuando mapeo (06-01) tengo que cambiar lo que dice namespace directores.Entities por
                          //namespace directores.DTOs
{
    public class DirectorDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        
        //05-19 nota #4 nota importante: agregar la segunda parte (new List<MoviesDto>(); para que no quede en null.
        public IList<MovieDto> Movies { get; set; } = new List<MovieDto>(); 
        
        //05-19 nota #5 este método me va a contar la cantidad de movies que tiene un director
        public int CandidadDeMovies
        {
            get { return Movies.Count; }
        }
    }
}
