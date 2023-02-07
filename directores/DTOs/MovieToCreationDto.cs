using System.ComponentModel.DataAnnotations;

namespace directores.DTOs
{
    public class MovieToCreationDto
    {
        //05-19 1.19:00 Explica como poner el Required
        //agregamos el using para que funcione using System.ComponentModel.DataAnnotations;
        [Required(ErrorMessage = "Agregá un nombre")] 
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;
        [MaxLength(255)]
        public string? Description { get; set; }
        [MaxLength(50)]
        public string? Location { get; set; }
        public int Year { get; set; }

    }
}
