using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace directores.Entities
{
    public class Movie
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]//#4
        public int Id { get; set; }
        
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        //#3
        public Movie(string name)
        {
            Name = name;
        }

        [MaxLength(250)]
        public string? Description { get; set; }
        
        [MaxLength(50)]
        public string? Location { get; set; }
        
        public int Year { get; set; }

        [ForeignKey("DirectorId")]
        public Director Director { get; set; }
        public int DirectorId { get; set; }
    }
}
