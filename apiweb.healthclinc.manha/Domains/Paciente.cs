using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace apiweb.healthclinc.manha.Domains
{
    [Table(nameof(Paciente))]
    [Index(nameof(CPF), IsUnique = true)]
    public class Paciente
    {
        [Key]
        public Guid IdPaciente { get; set; } = Guid.NewGuid();

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "O nome do paciente é obrigatório")]
        public string? NomePaciente { get; set; }

        [Column(TypeName = "CHAR(16)")]
        [Required(ErrorMessage = "O CPF do paciente é obrigatório")]
        [StringLength(16)]
        public string? CPF { get; set; }

        [Column(TypeName = "CHAR(16)")]
        [Required(ErrorMessage = "O Telefone do paciente é obrigatório")]
        public string? Telefone { get; set; }

        [Column(TypeName = "CHAR(3)")]
        [Required(ErrorMessage = "A idade do paciente é obrigatória")]
        public string? Idade { get; set; }

        //ref.tabela Usuario
        [Required(ErrorMessage = "Usuário obrigatório!")]
        public Guid IdUsuario { get; set; }

        [ForeignKey(nameof(IdUsuario))]
        public Usuario? Usuario { get; set; }
    }
}
