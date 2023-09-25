using apiweb.healthclinc.manha.Domains;
using Microsoft.EntityFrameworkCore;

namespace apiweb.healthclinc.manha.Contexts
{
    public class HealthClinicContext : DbContext
    {
        public DbSet<TiposUsuario> TiposUsuario { get; set; }
        public DbSet<Usuario> Usuario { get; set; } 
        public DbSet<TiposEspecialidade> TiposEspecialidades { get; set; }
        public DbSet<Medico> Medico { get; set; } 
        public DbSet<Paciente> Paciente { get; set; }
        public DbSet<StatusConsulta> StatusConsulta { get; set; } 
        public DbSet<Consulta> Consulta { get; set; }
        public DbSet<Prontuario> Prontuario { get; set; }
        public DbSet<Clinica> Clinica { get; set; }
        public DbSet<Comentario> Comentario { get; set; }

        /// <summary>
        /// Define as opções de contrusção do banco(String Conexão)
        /// </summary>
        /// <param name="optionsBuilder">Objeto com as configurações definidas</param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=NOTE23-S15; Database=Health_Clinic_manha; User Id=sa; Pwd=Senai@134; TrustServerCertificate=True;");
            base.OnConfiguring(optionsBuilder);
        }

    }
}
