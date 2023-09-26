using System.ComponentModel.DataAnnotations;

namespace apiweb.healthclinc.manha.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Email é obrigatório")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Senha é obrigatória")]
        public string? Senha { get; set; }
    }
}
