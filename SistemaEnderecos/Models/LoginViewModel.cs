using System.ComponentModel.DataAnnotations;

namespace SistemaEnderecos.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Informe o usuario")]
        public string Login {get; set;} = string.Empty;

        [Required(ErrorMessage ="Digite a senha")]
        public string Senha { get; set;} = string.Empty;
    }
}