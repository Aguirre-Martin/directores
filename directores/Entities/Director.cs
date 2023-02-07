using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace directores.Entities
{
    public class Director
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]//#4 Esto lo hace autoincremental al Id, el Identity
        public int Id { get; set; }
        
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        //#3
        public Director(string name)//#6 Esta recomendación dice que se puede obviar, la de Director subrayada en verde
        {
            Name = name;
        }

        [MaxLength(250)]
        public string? Description { get; set; }

        public ICollection<Movie> Movies { get; set; }    
       
    }
}
