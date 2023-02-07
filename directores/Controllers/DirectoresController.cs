using AutoMapper;
using directores.DTOs;
using directores.Entities;
using directores.Services;
using Microsoft.AspNetCore.Mvc;

namespace directores.Controllers
{
    //*1 creando este controlador puedo empezar a acceder al servidor a traves de los verbos http 

    [ApiController] //05-05 nota#3
    //controller tiene muchos métodos definidos, algunos de vista. pero como no vamos a usar métodos de vista ni otros, sólo heredamos de
    //ControllerBase
    //Esto dejó de comportarse con una clase para ser un controlador (qué permite esto: *1)
    [Route("api/directores")] //creo la ruta de la que voy a hablar más abajo
    public class DirectoresController : ControllerBase //05-05 nota#3 
                                                       //al heredar de ControllerBase se convierte en un controlador. es base, no tiene todo
    {
        //nueva inyección de dependencia de la base de datos, con la interaz de Services (IDirectoresRepository)
        //06-01 voy a agregar el Mapper a la inyección de dependencia, agregando IMapper y mapper _mapper = mapper
        private readonly IDirectoresRepository _repository;
        private readonly IMapper _mapper;

        public DirectoresController(IDirectoresRepository repository, IMapper mapper)//ese repository podemos poner lo que queramos
        {
            _repository = repository;
            _mapper = mapper;
        }


        //hasta acá usaba fake data, ahora va a cambiar esto y va a inyectar la base de datos, con la interfaz de los servicios
        //IDirectoresRepository
        /*
        private readonly DirectoresData _directoresData;
        public DirectoresController (DirectoresData directoresData)
        {
            _directoresData = directoresData;
        }*/


        [HttpGet]//1.1
        public JsonResult GetDirectores()//*1.2
        {
            //ahora con la inyección del repositorio (_repository) se retorna así NUEVO
            return new JsonResult(_repository.GetDirectores());

            //buscar directores con la instancia y pasarlo como parámetro (esto se hacía antes de la inyecíón de dependencia)

            //esto ya no se usa más, ahora se usa distinto, como arriba, se llama directamente al método de services
            //que provee la inyección de dependencia
            //return new JsonResult(_directoresData.Directores); //antes se hacía así
        }
        [HttpGet("{idDirector}")]
        public IActionResult GetDirector(int idDirector)

        //nueva logica 05/12 final
        {
            //esta linea desaparece
            //var director = _directoresData.Directores.Where(d => d.Id == idDirector).FirstOrDefault();

            //06-01 definitivo
            Entities.Director? director = _repository.GetDirector(idDirector);
            if (director is null)
            {
                return NotFound();
            }
            //06-01 más adelante. ahora esto lo comento, como esto ya sabe mapear
            //Director a DirectorDto y Movie a MoviesDto ya va a mapear todo
            //return Ok(_mapper.Map<DirectorSinMovieDto>(director));

            //esto es lo ultimo, lo que queda
            return Ok(_mapper.Map<DirectorDto>(director));//mapeo un director no una lista

            //return Ok(director);esto ya no lo retorno, ahora retorno el mapper
        }
        [HttpPost(Name = "GetDirectores")]
        public ActionResult<DirectorDto> CreateDirectores(DirectorToCreationDto directorToCreate)
        {


            Director directorNew = _mapper.Map<Director>(directorToCreate);

            _repository.AgregarDirector(directorNew);

            _repository.GuardarCambios();


            return CreatedAtRoute(
                        "getdirectores",
                        new
                        {
                            idDirector = directorNew.Id

                        },
                        _mapper.Map<DirectorDto>(directorNew));
        }

        [HttpPut("{idDirector}")]
        public ActionResult UpdateDirectores(int idDirector, DirectorToUpdateDto directorUpdated)
        {
            //primero como siempre hay que comprobar que el director exista
            {
                if (!_repository.ExisteDirector(idDirector))
                    return NotFound();

                var directorAActualizar = _repository.GetDirector(idDirector);

                if (directorAActualizar == null)
                    return NotFound();

                _mapper.Map(directorUpdated, directorAActualizar);
                _repository.GuardarCambios();

                return NoContent();
            }

        }

        [HttpDelete("{idDirector}")]
        public ActionResult DeleteDirectores(int idDirector)
        {
            //primero como siempre hay que comprobar que el director exista
            {
                if (!_repository.ExisteDirector(idDirector))
                    return NotFound();

                var directorAEliminar = _repository.GetDirector(idDirector);
                if (directorAEliminar == null)
                    return NotFound();

                _repository.EliminarDirector(directorAEliminar);
                _repository.GuardarCambios();

                return NoContent();

            }
        }
    }
}

        //clase 06-01 para que mapee hay que reemplazar esto por Entities, no estaba en el código
        /*
        //y se reemplaza por ésta
        var director = _repository.GetDirector(idDirector);
        if (director is null)
        {
            return NotFound();
        }
        return Ok(director);
    }
        */


        /*esto ya no se hace así, ahora el Linq se usa en services   
           //nueva logica 05/12 final
       {
           var director = _directoresData.Directores.Where(d => d.Id == idDirector).FirstOrDefault();

           //esta parte queda
           if (director is null)
           {
               return NotFound();
           }
           return Ok(director);
       }*/


    
 



/*
        //*2 al poner [ApiController] y heredar de ControllerBase ya convierto a la clase en un controlador pero para poder obtener algo
        //debo hacer unos métodos. el más fácil es hacer un GetAll
        //para lograr *2 debo hacer que devuelva un json

        //1.1[HttpGet] este HttpGet no es el mismo que pide por id, que sería [HttpGet("{id}")], con la misma ruta implícita
        //con el HttpGet no alcanza, por lo que le debo poner la ruta. Esto se hace poniendo api/nombre del controlador
        //se hace entre paréntesis y comillas dobles, como parámetro. podria poner otra cosa, pero para claridad del código es mejor hacerlo así.
        //entonces ("api/directores")
        //PERO, para resumir: para no tener que repetir y hacer todos los verbos más cómodos, puede optimizarse y ponerse:[Route("api/directores)]
        //y ese [Route("api/directores")] vale para todos

        //indico que quiero un json result, le pongo el nombre que quiero, en este caso Get y el nombre del namespace,
        //para ayudarnos a ubicarnos
        /*1.2public JsonResult GetDirectores()
        {
            //pido que me retorne un json con una lista de strings
            return new JsonResult(new List<string>
            {
                "Martin Scorsese",
                "Stanley Kubrick",
                "Alfred Hitchcock"
            });
        }

        /*esto primero lo mostró como ejemplo, después lo borró
        [HttpGet("{id}")]
        public JsonResult GetDirector(int id)
        {
            return new JsonResult(new List<string>
            {
                "Enyaso id"
            });
        }
        */
/*
//la serialización es pasar un objeto a texto (por ejemplo pasar a un json una clase instanciada).
//es sacar un objeto de adentro de c#
//un DTO es un Data Transfer Objetc, es un objeto que vamos a mandar desde las API sin ninguna lógica de negocio
//los DTO deben ser serializables, por ejemplo en un json
//La entidad por otra parte es la representación de la base de datos en el código. Una entidad es lo que se va a guardar en la db
//la diferencia entre entidad y DTO es que entidad tiene la misma cantidad de datos como columnas de la base de datos
//en el DTO podemos elegir qué datos tener, es lo que vos le querés mandar al cliente
//Tanto en una entidad como en un DTO no podemos tener más datos que los que tenemos en la base de datos
//El modelo tiene lógica

//hasta acá clase del 05/05
//a partir de acá 05/12
*/
