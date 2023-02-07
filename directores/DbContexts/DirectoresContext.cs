using directores.Entities;
using Microsoft.EntityFrameworkCore;


namespace directores.DBContexts
{
    public class DirectoresContext : DbContext
    {
        public DbSet<Director> Directores { get; set; }
        //estas linea hacen que todo lo que hagamos con LinQ se traduzca a lenguaje de base de datos, para Director y Movie
        //gracias a esto no tenemos que usar SQL, lo hace todo EF
        public DbSet<Movie> Movies { get; set; }

        public DirectoresContext(DbContextOptions<DirectoresContext> options) : base(options)
            //esto llama al constructor de DbContext que es el que acepta las opciones
        {
                
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var directores = new Director[3]
            {
                //se le pasa aca el name porque nos hizo crear un constructor
                //el entity para que name no pudiera ser nulo
                new Director("Martin Scorsese")
                {
                    Id = 1,
                    Description = "Maffia movies",
                },
                new Director("Stanley Kubrick")
                {
                    Id = 2,
                    Description = "Adaptation movies",
                },
                new Director("Alfred Hitchcock")
                {
                    Id = 3,
                    Description = "Suspense movies",
                }
            };

            modelBuilder.Entity<Director>().HasData(directores);
            modelBuilder.Entity<Movie>().HasData
                (
                    new Movie("Goodfellas")
                    {
                        Id=1,
                        Description = "Maffia Code's movie",
                        Location = "Pittsburgh",
                        Year = 1990,
                        DirectorId = directores[0].Id
                    },
                    new Movie("Casino")
                    {
                        Id = 2,
                        Description = "Maffia and gambling movie",
                        Location = "Las vegas",
                        Year = 1995,
                        DirectorId = directores[0].Id
                    },
                    new Movie("A clockwork orange")
                    {
                        Id = 3,
                        Description = "Distopic movie",
                        Location = "United Kingdom",
                        Year = 1971,
                        DirectorId = directores[1].Id
                    },
                    new Movie("The shining")
                    {
                        Id = 4,
                        Description = "Psicological horror movie",
                        Location = "Overlock Hotel",
                        Year = 1980,
                        DirectorId = directores[1].Id
                    },
                    new Movie("Psycho")
                    {
                        Id = 5,
                        Description = "Mental ilness movie, split personality",
                        Location = "California",
                        Year = 1960,
                        DirectorId = directores[2].Id
                    },
                    new Movie("Notorious")
                    {
                        Id = 6,
                        Description = "Spy movie",
                        Location = "New York",
                        Year = 1946,
                        DirectorId = directores[2].Id
                    }
                );
            base.OnModelCreating(modelBuilder);
           
        }
    }
}
