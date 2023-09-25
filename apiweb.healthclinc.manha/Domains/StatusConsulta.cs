using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace apiweb.healthclinc.manha.Domains
{
    [Table(nameof(StatusConsulta))]
    public class StatusConsulta
    {
        [Key]
        public Guid IdStatusConsulta { get; set; } = Guid.NewGuid();

        [Column(TypeName = "VARCHAR(15)")]
        [Required(ErrorMessage = "Status obrigatório")]
        public string? Status { get; set; }
    }
}
