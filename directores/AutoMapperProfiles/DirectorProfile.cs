using AutoMapper;

namespace directores.AutoMapperProfiles
{
    //06-01 por cada clase de la entidad se crea un profile nuevo
    public class DirectorProfile  : Profile
    {
        //06-01 hago un constructor
        public DirectorProfile()
        {
            //acá mapeo los Dto de director (Director sin movie y Director, se llama a DTOs, no a models como en la diapositiva)
            CreateMap<Entities.Director, DTOs.DirectorSinMovieDto>();//esto dice te puedo pedir que mapees desde Director
                                                                     //hasta DirectorSinMovieDto
            CreateMap<Entities.Director, DTOs.DirectorDto>();
            
            //creation
            CreateMap<DTOs.DirectorToCreationDto, Entities.Director>();
            CreateMap<Entities.Director, DTOs.DirectorToCreationDto>();

            //update
            CreateMap<DTOs.DirectorToUpdateDto, Entities.Director>();
            CreateMap<Entities.Director, DTOs.DirectorToUpdateDto>();

        }
    }
}
