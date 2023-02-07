using System.ComponentModel.DataAnnotations;

namespace directores.DTOs
{
    public class MovieToUpdateDto
    {
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
