using directores.DBContexts;
using directores.Entities;
using Microsoft.EntityFrameworkCore;

namespace directores.Services
{
    //hasta ahora implementamos la interfaz (05-26, parte final)
    public class DirectoresRepository : IDirectoresRepository
    {
        private readonly DirectoresContext _context;


        //ahora para poder usar EF tiene que hacer la inyección de dependencia en un constructor
        //una vez hecho esto _context pasa a ser el acceso a la base de datos
        public DirectoresRepository(DirectoresContext context)
        {
            _context = context;
        }
        public Director? GetDirector(int IdDirector)
        {
            // clase 06-01 minuto 20 aprox, consulta a la base de datos
            return _context.Directores.Include(c => c.Movies).Where(d => d.Id == IdDirector).FirstOrDefault();
         
            /* Va a cambiar esto ahora, ya que va a consultar en la base de datos
            //Para poner un ejemplo, podemos poner
            //_context.+LinQ eso lo traduce a SQL y pasa la data (y hacer cualquier consulta con LinQ)
           return _context.Directores.Where(d => d.Id == IdDirector).FirstOrDefault(); 
            */
        }

        public IEnumerable<Director> GetDirectores()
        {
            return _context.Directores.OrderBy(d => d.Name).ToList();
        }

        public Movie? GetMovie(int IdDirector, int IdMovie)
        {
            return _context.Movies.Where(d => d.Id == IdMovie && d.DirectorId == IdDirector).FirstOrDefault();
        }

        public IEnumerable<Movie> GetMovies(int IdDirector)
        {
            return _context.Movies.Where(d => d.DirectorId == IdDirector).ToList();
            
        }
        //va a crear el método ExisteDirector() - 06-01
        //Hay que hacerle ctrl+. al nombre del método (ExisteCiudad) para que lo agregue en la Interface IDirectoresRepository
        public bool ExisteDirector(int IdDirector)
        {
            return _context.Directores.Where(d => d.Id == IdDirector).Any();//Any devuelve verdadero si hay alguno y falso
                                                                            //si no hay ninguno
        }

        public void AgregarMovieADirectores(int idDirector, Movie movie)
        {
            var director = GetDirector(idDirector);
            if(director != null)
                director.Movies.Add(movie);          
        }
        //06-01 tengo que hacer el método guardar cambios
        public bool GuardarCambios()//tengo que recordar agregar el método a la interfaz
        {
            //lo que hace acá es retornar un número mayor a 0, eso significa que guarda. 
            //que dé un numero mayor a 0 es lo que pide el método SaveChanges();
            return (_context.SaveChanges() >= 0);
        }

        public void EliminarMovie(Movie movie)
        {
            _context.Movies.Remove(movie);
        }

        //metodos de martin

        public void AgregarDirector(Director director)
        {
            _context.Directores.Add(director);
        }
        public void EliminarDirector(Director director)
        {
            _context.Directores.Remove(director);
        }
    }
}
