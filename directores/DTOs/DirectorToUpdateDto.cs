using System.ComponentModel.DataAnnotations;

namespace directores.DTOs
{
    public class DirectorToUpdateDto
    {
        [Required(ErrorMessage = "Agregá un nombre")]
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;
        [MaxLength(255)]
        public string? Description { get; set; }
    }
}
