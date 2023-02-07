using AutoMapper;
using directores.DTOs;
using directores.Entities;
using directores.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace directores.Controllers
{
    //05-19 nota #1 {[Route("api/[controller]")]} 
    //05-19 nota#2 {[Route("api/movies")]}

    [Route("api/directores/{idDirector}/movies")] //05-19 nota#3 forma correcta 
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IDirectoresRepository _repository;
        private readonly IMapper _mapper;
        public MoviesController(IDirectoresRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }


        [HttpGet] //este es el GetAll obtener todo
        //esto es lo que va a devolver, hace una accion result que crea una lista de peliculas
        public ActionResult<List<MovieDto>> GetMovies(int idDirector)//05-19 nota#4 
        {
            //nueva forma 06-01 min 29
            if (!_repository.ExisteDirector(idDirector))
                return NotFound();

            List<Entities.Movie> movies = _repository.GetMovies(idDirector).ToList();
            return Ok(_mapper.Map<List<MovieDto>>(movies));





            /*hasta el 06-01 se hacía así
            //el 06-01 cambia esta línea pero luego lo comenta
            var director = _repository.GetMovies(IdDirector);
            
            //antes de cambiar eso era así
            var director = _directoresData.Directores.Where(d => d.Id == IdDirector).FirstOrDefault();
            //05-19 nota #6
            if (director == null)
            {
                return NotFound();
            }
            return Ok(director.Movies);
            */
            //el códido de la clase llegó hasta acá min 32.20, ahora va a agregar Movies en la data(PuntosDeInteres, porque no había)
            //esto lo va a hacer en DirectoresData
        }

        //ahora el get por id se hace así desde el 06-01
        [HttpGet("{idMovie}", Name = "GetMovies")] //paso el id de la pelicula  *1 de acá se sacan los datos del post

        public ActionResult<MovieDto> GetMovies(int idDirector, int idMovie)
        {
            //pregunta con el nuevo método si existe idDrector
            if (!_repository.ExisteDirector(idDirector))
                return NotFound();
            //usa el método GetMovie y le pasa el idDirector y el IdMovie
            Entities.Movie? movie = _repository.GetMovie(idDirector, idMovie);

            if (movie == null)
                return NotFound();
            return Ok(_mapper.Map<MovieDto>(movie));


            //esto no se hace más desde el 06-01
            //var director = _directoresData.Directores.Where(d => d.Id == IdDirector).FirstOrDefault();

            //if (director == null)
            //{
            //    return NotFound();
            //}
            ////si encontró al director creo la variale movie y le paso el IdMovie del director que busqué antes, arriba
            ////if (director == null) ese director
            //var movie = director.Movies.Where(d => d.Id == IdMovie).FirstOrDefault();

            //if (movie == null)
            //{
            //    return NotFound();
            //}
            //return Ok(movie);

        }

        //ahora voy a hacer el post 06-01

        [HttpPost]
        public ActionResult<MovieDto> CreateMovies(int idDirector, MovieToCreationDto movieToCreate)
        {
            if (!_repository.ExisteDirector(idDirector))
                return NotFound();

            Movie movieNew = _mapper.Map<Movie>(movieToCreate);

            //06-01 una vez que hicimos esto vamos a tener que crear un método
            //en el repositorio (DirectoresRepository para agregar la movie a la ciudad)
            //en esta línea lo llamamos a ese método que creamos
            _repository.AgregarMovieADirectores(idDirector, movieNew);
            //ahora tengo que guardar los cambios con el método GuardarCambios de Repository
            //se hace así

            _repository.GuardarCambios();
            //aparte, y a lo último hasta que no hago el return no acepta el método CreateMovies

            return CreatedAtRoute(
                        "getmovies",
                        new
                        {
                            idDirector,
                            idMovie = movieNew.Id
                        },
                        _mapper.Map<MovieDto>(movieNew));
        }

        [HttpPut("{idMovie}")]
        public ActionResult UpdateMovies(int idDirector, int idMovie, MovieToUpdateDto movieUpdated)
        {
            //primero como siempre hay que comprobar que el director exista
            {
                if (!_repository.ExisteDirector(idDirector))
                    return NotFound();

                var movieAActualizar = _repository.GetMovie(idDirector, idMovie);

                if (movieAActualizar == null)
                    return NotFound();

                _mapper.Map(movieUpdated, movieAActualizar);
                _repository.GuardarCambios();

                return NoContent();
            }
        }

        [HttpDelete("{idMovie}")]
        public ActionResult DeleteMovies(int idDirector, int idMovie)
        {
            //primero como siempre hay que comprobar que el director exista
            {
                if (!_repository.ExisteDirector(idDirector))
                    return NotFound();

                var movieAEliminar = _repository.GetMovie(idDirector, idMovie);
                if (movieAEliminar == null)
                    return NotFound();

                _repository.EliminarMovie(movieAEliminar);
                _repository.GuardarCambios();

                return NoContent();

            }

        }
    }
}




        //Esto antes del 06-01 se hacía así
        //traigo movie por id
        //        [HttpGet("{IdMovie}", Name = "GetMovies")] //paso el id de la pelicula  *1 de acá se sacan los datos del post

        //        public ActionResult<MovieDto> GetMovies(int IdDirector, int IdMovie)
        //        {
        //            var director = _directoresData.Directores.Where(d => d.Id == IdDirector).FirstOrDefault();

        //            if (director == null)
        //            {
        //                return NotFound();
        //            }
        //            //si encontró al director creo la variale movie y le paso el IdMovie del director que busqué antes, arriba
        //            //if (director == null) ese director
        //            var movie = director.Movies.Where(d => d.Id == IdMovie).FirstOrDefault();

        //            if (movie == null)
        //            {
        //                return NotFound();
        //            }
        //            return Ok(movie);

        //        }
        //        //ahora hay que agregar el método post. va a separar consulta, creación y update
        //        [HttpPost]
        //        public ActionResult<MovieDto> CreateMovies(int IdDirector, MovieToCreationDto MovieToCreate)
        //        {
        //            //primero como siempre hay que comprobar que el director exista
        //            var director = _directoresData.Directores.Where(d => d.Id == IdDirector).FirstOrDefault();

        //            if (director == null)
        //            {
        //                return NotFound();
        //            }
        //            //se va a usar SelectMany que va a hacer una lista de las películas de cada director
        //            //Con max se va a traer el id más alto (que como es autoincremental sería el último)

        //            var idMaximoMovie = _directoresData.Directores.SelectMany(m => m.Movies).Max(m => m.Id);

        //            //ahora vamos a crear una nueva película con id, le vamos a sumar 1 al id más alto
        //            //tambien vamos a asignar el nombre y la descripcion del Dto
        //            var nuevaMovie = new MovieDto
        //            {
        //                Id = ++idMaximoMovie,
        //                //le paso el name del Dto
        //                Name = MovieToCreate.Name,
        //                //le paso la descripcion del Dto
        //                Description = MovieToCreate.Description,
        //                //le paso la locacion del Dto
        //                Location = MovieToCreate.Location,
        //                //y el año
        //                Year = MovieToCreate.Year
        //            };
        //            //ahora hay qye agregarlo a la base de datos, ya está creado en memoria
        //            director.Movies.Add(nuevaMovie);
        //            //ahora lo tengo que retornar al usuario, hasta ahora marca error en CreateMovies() porque no lo estamos retornando
        //            //se hace con el método CreatedAtRoute()que recibe tres parámetros

        //            //el primero es el nombre del get de lo que quiero retornar, en este caso movies. le pongo al get el Name para llamarlo
        //            //en los parámetros, pongo [HttpGet("{IdMovie}", Name = "GetMovies")]  y lo llamo entre comillas en los parámetros
        //            //"GetMovies"    *1
        //            //el segundo en son los parámetros que toma este verbo Http, en este caso IdDirector (que es de donde salen las Movies)
        //            //y el nuevo Id de la película que se creó
        //            //el tercero es el objeto que se creó (nuevaMovie)

        //            return CreatedAtRoute(
        //                "GetMovies",
        //                new
        //                {
        //                    IdDirector,
        //                    IdMovie = nuevaMovie.Id
        //                },
        //                nuevaMovie);
        //        }
        //        [HttpPut("{IdMovie}")]
        //        public ActionResult UpdateMovies(int IdDirector, int IdMovie, MovieToUpdateDto MovieUpdated)
        //        {
        //            //primero como siempre hay que comprobar que el director exista
        //            var director = _directoresData.Directores.Where(d => d.Id == IdDirector).FirstOrDefault();

        //            if (director == null)
        //            {
        //                return NotFound();
        //            }
        //            var MovieAActulizar = director.Movies.Where(m => m.Id == IdMovie).FirstOrDefault();
        //            if (MovieAActulizar == null)
        //            {
        //                return NotFound();
        //            }
        //            MovieAActulizar.Name = MovieUpdated.Name;
        //            MovieAActulizar.Description = MovieUpdated.Description;
        //            MovieAActulizar.Location = MovieUpdated.Location;
        //            MovieAActulizar.Year = MovieUpdated.Year;

        //            return NoContent();

        //        }

        //        [HttpDelete("{IdMovie}")]
        //        public ActionResult DeleteMovies(int IdDirector, int IdMovie)
        //        {
        //            //primero como siempre hay que comprobar que el director exista
        //            var director = _directoresData.Directores.Where(d => d.Id == IdDirector).FirstOrDefault();

        //            if (director == null)
        //            {
        //                return NotFound();
        //            }
        //            var MovieAEliminar = director.Movies.Where(m => m.Id == IdMovie).FirstOrDefault();
        //            if (MovieAEliminar == null)
        //            {
        //                return NotFound();
        //            }
        //            director.Movies.Remove(MovieAEliminar);

        //            return NoContent();

        //        }

    

