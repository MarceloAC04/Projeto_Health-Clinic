using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace apiweb.healthclinc.manha.Domains
{
    [Table(nameof(TiposEspecialidade))]
    public class TiposEspecialidade
    {
        [Key]
        public Guid IdTipoEspecialidade { get; set; } = Guid.NewGuid();

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "A Especialidade do tipo usuário é obrigatório!")]
        public string? Especialidade { get; set; }
    }
}
