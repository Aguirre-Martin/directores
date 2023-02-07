using directores.Entities;

namespace directores.Services
{
    public interface IDirectoresRepository
    {
        public IEnumerable<Director> GetDirectores();
        public Director? GetDirector(int IdDirector);
        public IEnumerable<Movie> GetMovies(int IdDirector);
        public Movie? GetMovie(int IdDirector, int IdMovie);
        //Cuando hago ctrl+. en DirectoresRepository al nombre del método me permite agregar esta línea en la esta Interface
        bool ExisteDirector(int IdDirector);
        void AgregarMovieADirectores(int idDirector, Movie movie);
        bool GuardarCambios();
        void EliminarMovie(Movie movie);
        void AgregarDirector(Director director);
        void EliminarDirector(Director director);
    }
}
