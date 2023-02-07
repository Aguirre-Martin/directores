using directores.DTOs;
//using directores.Entidades;esto lo borra cuando quiere hacer el mapeo (clase 06-01 aprox minuto 20

namespace directores
{
    public class DirectoresData
    {
        public List<DirectorDto> Directores { get; set; }

        //forma de usar instancia unica (le pusimos Instance pero le podemos poner como queramos)
        //para que guarde cambios cada vez que corremos la aplicacion hasta que se finaliza

        //se crea una instancia dentro de ella misma
        //esto ahora que usa inyección de dependencia no lo va a usar más
        //inyeccion de dependencia - primero se saca la autoinstancia de acá abajo
        //IDD #1 05-26 se saca la autoinstanciacion de ciudades data, se borra lo de más abajo

        //public static DirectoresData Instance { get; } = new DirectoresData();   esto se comenta y no se usa más

        //IDD #2 va a agregar el servicio a program, el singleton
        //en este constructor inicializamos los directores, queda como una clase comun y corriente
        public DirectoresData()
        {
            Directores = new List<DirectorDto>
            {
                new DirectorDto()
                {
                    Id = 1,
                    Name= "Martin Scorsese",
                    Description = "Maffia Movies",
                    //nota 05-19 #7
                    Movies= new List<MovieDto>
                    {
                        new MovieDto()
                        {
                            Id=1,
                            Name = "Goodfellas",
                            Description = "Maffia code's movie",
                            Location = "Pittsburgh",
                            Year = 1990
                        },
                        new MovieDto()
                        {
                            Id=2,
                            Name = "Casino",
                            Description = "Maffia and gambling movie",
                            Location = "Las Vegas",
                            Year = 1995
                        }

                    }
                },
                new DirectorDto()
                {   Id = 2,
                    Name = "Stanley Kubrick",
                    Description = "Adaptation Movies",
                    Movies = new List<MovieDto>
                    {
                        new MovieDto 
                        { 
                            Id = 3, 
                            Name = "A Clockwork Orange",
                            Description = "Distopic Movie",
                            Location = "United Kingdom",
                            Year = 1971

                        },
                        new MovieDto()
                        {
                            Id = 4,
                            Name = "The Shining",
                            Description = "Psicologig Horror Movie",
                            Location = "Overlock Hotel",
                            Year = 1980
                        }

                    }
                },
                new DirectorDto()
                {
                    Id = 3,
                    Name = "Alfred Hitchcock",
                    Description = "Suspense Movies",
                    Movies = new List<MovieDto>()
                    {
                        new MovieDto
                        {
                            Id = 5,
                            Name =  "Psycho",
                            Description = "Mental ilness movie, split personality",
                            Location= "California",
                            Year = 1960
                        },
                        new MovieDto
                        {
                            Id = 6,
                            Name =  "Notorious",
                            Description = "Spy movie",
                            Location= "New York",
                            Year = 1946
                        }
                    }
                    //minuto 35:49 del 05-19, hecho hasta buscar películas 
                    //luego empieza a explicar el gui para crear Id's
                }
            };
        }

         
        
    }
}
