using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace apiweb.healthclinc.manha.Domains
{
    [Table(nameof(Consulta))]
    public class Consulta
    {
        [Key]
        public Guid IdConsulta { get; set; } = Guid.NewGuid();

        [Column(TypeName = "DATE")]
        [Required(ErrorMessage = "A Data da consulta é obrigatória")]
        public DateTime DataConsulta { get; set; }

        [Column(TypeName = "TIME")]
        [Required(ErrorMessage = "O Horário é obrigatório")]
        public TimeSpan Horario { get; set; }

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "A Descrição da consulta é obrigatória")]
        public string? Descricao { get; set; }

        //ref.tabela StatusConsulta
        [Required(ErrorMessage = "Informe o status da consulta")]
        public Guid IdStatusConsulta { get; set; }

        [ForeignKey(nameof(IdStatusConsulta))]
        public StatusConsulta? StatusConsulta { get; set; } 
        
        //ref.tabela Paciente
        [Required(ErrorMessage = "Informe o paciente da consulta")]
        public Guid IdPaciente { get; set; }

        [ForeignKey(nameof(IdPaciente))]
        public Paciente? Paciente { get; set; } 
        
        //ref.tabela Medico
        [Required(ErrorMessage = "Informe o médico da consulta")]
        public Guid IdMedico { get; set; }

        [ForeignKey(nameof(IdMedico))]
        public Medico? Medico { get; set; }

        //ref.tabela Clinica
        [Required(ErrorMessage = "Informe a clinica da consulta")]
        public Guid IdClinica { get; set; }

        [ForeignKey(nameof(IdClinica))]
        public Clinica? Clinica { get; set; }

    }
}
