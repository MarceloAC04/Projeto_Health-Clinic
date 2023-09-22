using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace apiweb.healthclinc.manha.Domains
{
    [Table(nameof(Medico))]
    public class Medico
    {
        [Key]
        public Guid IdMedico { get; set; } = Guid.NewGuid();

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = " O Nome do Médico é obrigatório!")]
        public string? NomeMedico { get; set; }

        [Column(TypeName = "CHAR(12)")]
        [Required(ErrorMessage = " O CRM do Médico é obrigatório!")]
        [StringLength(12)]
        public string? CRM { get; set; }

        //ref.tabela Usuario
        [Required(ErrorMessage = "Usuário obrigatório!")]
        public Guid IdUsuario { get; set; }

        [ForeignKey(nameof(IdUsuario))]
        public Usuario? Usuario { get; set; }

        //ref.tabela Clinica
        [Required(ErrorMessage = "Clínica Obrigatória")]
        public Guid IdClinica { get; set; }

        [ForeignKey(nameof(IdClinica))]
        public Clinica? Clinca { get; set; }

        //ref.tabela Especialidade
        [Required(ErrorMessage = "Especialidade obrigatória")]
        public Guid IdEspecialidade { get; set; }

        [ForeignKey(nameof(IdEspecialidade))]
        public TiposEspecialidade? TipoEspecialidade { get; set;}

    }
}
