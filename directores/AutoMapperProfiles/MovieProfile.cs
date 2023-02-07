//using AutoMapper; esto lo comento porque Activo el AutoMapper antes de Profile y funciona igual

namespace directores.AutoMapperProfiles 
{
    public class MovieProfile : AutoMapper.Profile //en vez de agregar el using AutoMapper también se puede hacer así
    {
        public MovieProfile()
        {
            //mapeo de entidad a Dto
            CreateMap<Entities.Movie, DTOs.MovieDto>();
            //mapeo de Dto a entidad 
            CreateMap<DTOs.MovieDto, Entities.Movie>();

            //para que funcione el HttpPost y mapee de Dto de creación a entidad hay que agregar esto de abajo
            //agregar el Dto de creación
            //no funcionaba porque no había mapeado MovieToCreationDto a Entities.Movie 06-01 ,minuto 50
            CreateMap<DTOs.MovieToCreationDto, Entities.Movie>();
            //no funcionaba porque no había mapeado MovieToUpdateDto a Entities.Movie 06-01 ,minuto 50
            CreateMap<DTOs.MovieToUpdateDto, Entities.Movie>();
        }
    }
}
